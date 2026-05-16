using EasySystems.Bookings.Data;
using EasySystems.Bookings.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text.Encodings.Web;

namespace EasySystems.Bookings.Services;

public class EmailSettings
{
    public string Host { get; set; } = "";
    public int Port { get; set; } = 587;
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string DisplayName { get; set; } = "EasySystems";
    public bool EnableSsl { get; set; } = true;
    public string CompanyName { get; set; } = "EasySystems";
}

public class SmtpEmailSender : IEmailSender<ApplicationUser>, IBookingEmailSender
{
    private readonly EmailSettings _settings;
    private readonly HtmlEncoder _htmlEncoder;
    private readonly IDbContextFactory<ApplicationDbContext> _dbFactory;
    private readonly IEmailQueue _emailQueue;

    public SmtpEmailSender(
        IOptions<EmailSettings> options,
        HtmlEncoder htmlEncoder,
        IDbContextFactory<ApplicationDbContext> dbFactory,
        IEmailQueue emailQueue)
    {
        _settings = options.Value;
        _htmlEncoder = htmlEncoder;
        _dbFactory = dbFactory;
        _emailQueue = emailQueue;
    }

    public async Task SendConfirmationLinkAsync(ApplicationUser user, string email, string confirmationLink)
    {
        var businessName = await GetBusinessNameAsync(user.Id);
        var safeLink = _htmlEncoder.Encode(confirmationLink);

        await SendEmailAsync(
            email,
            businessName,
            $"Bekräfta din e-post | {businessName}",
            $"Välkommen till {businessName}.",
            "Välkommen, ditt bokningskonto är redo",
            $"""
            <p>Hej!</p>
            <p>Vi är glada att välkomna dig till <strong>{Encode(businessName)}</strong>.</p>
            <p>Bekräfta din e-postadress för att aktivera ditt konto och hantera dina bokningar tryggt.</p>
            """,
            "Bekräfta e-post",
            safeLink,
            null,
            $"Detta mail skickades av {_settings.CompanyName} för {businessName}."
        );
    }

    public async Task SendPasswordResetLinkAsync(ApplicationUser user, string email, string resetLink)
    {
        var businessName = await GetBusinessNameAsync(user.Id);
        var safeLink = _htmlEncoder.Encode(resetLink);

        await SendEmailAsync(
            email,
            businessName,
            $"Återställ lösenord | {businessName}",
            $"Återställ lösenordet för ditt konto hos {businessName}.",
            "Återställ ditt lösenord",
            $"""
            <p>Vi har fått en begäran om att återställa lösenordet för ditt konto hos <strong>{Encode(businessName)}</strong>.</p>
            <p>Klicka på knappen nedan för att skapa ett nytt säkert lösenord.</p>
            """,
            "Återställ lösenord",
            safeLink,
            null,
            "Om du inte begärde detta kan du ignorera mailet."
        );
    }

    public async Task SendPasswordResetCodeAsync(ApplicationUser user, string email, string resetCode)
    {
        var businessName = await GetBusinessNameAsync(user.Id);

        await SendEmailAsync(
            email,
            businessName,
            $"Din återställningskod | {businessName}",
            "Använd koden för att återställa lösenordet.",
            "Din återställningskod",
            """
            <p>Använd koden nedan för att fortsätta återställningen av ditt lösenord.</p>
            <p>Dela inte koden med någon.</p>
            """,
            null,
            null,
            resetCode,
            $"Powered by {_settings.CompanyName}."
        );
    }

    public async Task SendBookingCreatedToCustomerAsync(Booking booking)
    {
        if (string.IsNullOrWhiteSpace(booking.CustomerEmail))
            return;

        await SendEmailAsync(
            booking.CustomerEmail,
            booking.Business.Name,
            $"Din bokningsförfrågan är mottagen | {booking.Business.Name}",
            $"Vi har tagit emot din bokningsförfrågan hos {booking.Business.Name}.",
            "Din bokningsförfrågan är mottagen",
            BuildBookingCustomerMessage(booking),
            null,
            null,
            null,
            $"Du får ett nytt mail när {booking.Business.Name} uppdaterar statusen på din bokning."
        );
    }

    public async Task SendBookingCreatedToBusinessAsync(Booking booking)
    {
        if (string.IsNullOrWhiteSpace(booking.Business.Email))
            return;

        await SendEmailAsync(
            booking.Business.Email,
            booking.Business.Name,
            $"Ny bokningsförfrågan | {booking.CustomerName}",
            "En ny kund har skickat en bokningsförfrågan.",
            "Ny bokningsförfrågan",
            BuildBookingBusinessMessage(booking),
            null,
            null,
            null,
            "Logga in i EasySystems för att bekräfta, ändra eller avboka bokningen."
        );
    }

    public async Task SendBookingStatusChangedToCustomerAsync(Booking booking)
    {
        if (string.IsNullOrWhiteSpace(booking.CustomerEmail))
            return;

        await SendEmailAsync(
            booking.CustomerEmail,
            booking.Business.Name,
            $"Din bokning är {TranslateStatus(booking.Status).ToLower()} | {booking.Business.Name}",
            "Statusen för din bokning har uppdaterats.",
            $"Din bokning är {TranslateStatus(booking.Status).ToLower()}",
            BuildBookingStatusMessage(booking),
            null,
            null,
            null,
            $"Detta mail skickades av {_settings.CompanyName} för {booking.Business.Name}."
        );
    }

    public async Task SendBookingConfirmedToCustomerAsync(Booking booking)
    {
        if (string.IsNullOrWhiteSpace(booking.CustomerEmail))
            return;

        booking.Status = "Confirmed";

        await SendEmailAsync(
            booking.CustomerEmail,
            booking.Business.Name,
            $"Din bokning är bekräftad | {booking.Business.Name}",
            "Din bokning har blivit bekräftad.",
            "Din bokning är bekräftad",
            $"""
            <p>Hej <strong>{Encode(booking.CustomerName)}</strong>,</p>
            <p>Din bokning har nu blivit <strong>bekräftad</strong>.</p>
            {BuildBookingDetailsBox(booking)}
            <p>Vi ser fram emot ditt besök hos <strong>{Encode(booking.Business.Name)}</strong>.</p>
            """,
            null,
            null,
            null,
            $"Tack för att du bokar hos {booking.Business.Name}."
        );
    }

    public async Task SendBookingCancelledToCustomerAsync(Booking booking)
    {
        if (string.IsNullOrWhiteSpace(booking.CustomerEmail))
            return;

        booking.Status = "Cancelled";

        await SendEmailAsync(
            booking.CustomerEmail,
            booking.Business.Name,
            $"Din bokning har avbokats | {booking.Business.Name}",
            "Din bokning har blivit avbokad.",
            "Din bokning har avbokats",
            $"""
            <p>Hej <strong>{Encode(booking.CustomerName)}</strong>,</p>
            <p>Din bokning har blivit <strong>avbokad</strong>.</p>
            {BuildBookingDetailsBox(booking)}
            {BuildCancellationReasonBox(booking)}
            """,
            null,
            null,
            null,
            "Kontakta verksamheten om du har frågor kring avbokningen."
        );
    }

    public async Task SendBookingCancelledToBusinessAsync(Booking booking)
    {
        if (string.IsNullOrWhiteSpace(booking.Business.Email))
            return;

        booking.Status = "Cancelled";

        await SendEmailAsync(
            booking.Business.Email,
            booking.Business.Name,
            $"Kunden avbokade en tid | {booking.CustomerName}",
            "En kund har avbokat sin bokning.",
            "Bokning avbokad av kund",
            $"""
            <p>Kunden <strong>{Encode(booking.CustomerName)}</strong> har avbokat sin bokning.</p>
            {BuildBookingDetailsBox(booking)}
            {BuildCancellationReasonBox(booking)}
            <div style="margin:22px 0 0;padding:18px;border-radius:22px;background:#f9fafb;border:1px solid #e5e7eb;">
              <p style="margin:0 0 8px;"><strong>Kundens kontakt</strong></p>
              <p style="margin:0 0 6px;">E-post: {Encode(booking.CustomerEmail ?? "Saknas")}</p>
              <p style="margin:0;">Telefon: {Encode(booking.CustomerPhone ?? "Saknas")}</p>
            </div>
            """,
            null,
            null,
            null,
            "Logga in i EasySystems för att hantera bokningen."
        );
    }

    private async Task<string> GetBusinessNameAsync(string userId)
    {
        await using var db = await _dbFactory.CreateDbContextAsync();

        var businessName = await db.Set<BusinessUser>()
            .AsNoTracking()
            .Where(x => x.UserId == userId && x.Business.IsActive)
            .OrderBy(x => x.Id)
            .Select(x => x.Business.Name)
            .FirstOrDefaultAsync();

        return string.IsNullOrWhiteSpace(businessName)
            ? "EasySystems Bookings"
            : businessName;
    }

    private string BuildBookingCustomerMessage(Booking booking)
    {
        return $"""
        <p>Hej <strong>{Encode(booking.CustomerName)}</strong>,</p>
        <p>Vi har tagit emot din bokningsförfrågan. Bokningen är just nu <strong>väntande</strong>.</p>
        {BuildBookingDetailsBox(booking)}
        <p>Du får ett nytt mail när bokningen bekräftas, ändras eller avbokas.</p>
        """;
    }

    private string BuildBookingBusinessMessage(Booking booking)
    {
        return $"""
        <p>En ny bokningsförfrågan har kommit in.</p>
        {BuildBookingDetailsBox(booking)}
        <div style="margin:22px 0 0;padding:18px;border-radius:22px;background:#f9fafb;border:1px solid #e5e7eb;">
          <p style="margin:0 0 8px;"><strong>Kundens kontakt</strong></p>
          <p style="margin:0 0 6px;">E-post: {Encode(booking.CustomerEmail ?? "Saknas")}</p>
          <p style="margin:0;">Telefon: {Encode(booking.CustomerPhone ?? "Saknas")}</p>
        </div>
        """;
    }

    private string BuildBookingStatusMessage(Booking booking)
    {
        return $"""
        <p>Hej <strong>{Encode(booking.CustomerName)}</strong>,</p>
        <p>Statusen för din bokning har uppdaterats till <strong>{Encode(TranslateStatus(booking.Status))}</strong>.</p>
        {BuildBookingDetailsBox(booking)}
        {BuildCancellationReasonBox(booking)}
        """;
    }

    private string BuildCancellationReasonBox(Booking booking)
    {
        if (booking.Status != "Cancelled" || string.IsNullOrWhiteSpace(booking.CancellationReason))
            return "";

        return $"""
        <div style="margin-top:22px;padding:18px;border-radius:22px;background:#fff7ed;border:1px solid #fed7aa;">
            <p style="margin:0;">
                <strong>Orsak:</strong>
                {Encode(booking.CancellationReason)}
            </p>
        </div>
        """;
    }

    private string BuildBookingDetailsBox(Booking booking)
    {
        return $"""
        <div style="margin:24px 0;padding:22px;border-radius:26px;background:#fffaf4;border:1px solid #eadfd3;">
          <table role="presentation" width="100%" cellpadding="0" cellspacing="0">
            <tr>
              <td style="padding:8px 0;color:#7a6f63;font-size:13px;font-weight:700;">Tjänst</td>
              <td align="right" style="padding:8px 0;color:#151515;font-size:14px;font-weight:800;">{Encode(booking.Service.Name)}</td>
            </tr>
            <tr>
              <td style="padding:8px 0;color:#7a6f63;font-size:13px;font-weight:700;">Personal</td>
              <td align="right" style="padding:8px 0;color:#151515;font-size:14px;font-weight:800;">{Encode(booking.StaffMember.FullName)}</td>
            </tr>
            <tr>
              <td style="padding:8px 0;color:#7a6f63;font-size:13px;font-weight:700;">Datum</td>
              <td align="right" style="padding:8px 0;color:#151515;font-size:14px;font-weight:800;">{booking.StartTime:yyyy-MM-dd}</td>
            </tr>
            <tr>
              <td style="padding:8px 0;color:#7a6f63;font-size:13px;font-weight:700;">Tid</td>
              <td align="right" style="padding:8px 0;color:#151515;font-size:14px;font-weight:800;">{booking.StartTime:HH:mm} - {booking.EndTime:HH:mm}</td>
            </tr>
            <tr>
              <td style="padding:8px 0;color:#7a6f63;font-size:13px;font-weight:700;">Status</td>
              <td align="right" style="padding:8px 0;color:#151515;font-size:14px;font-weight:900;">{Encode(TranslateStatus(booking.Status))}</td>
            </tr>
          </table>
        </div>
        """;
    }

    private async Task SendEmailAsync(
        string toEmail,
        string businessName,
        string subject,
        string preHeader,
        string title,
        string message,
        string? buttonText = null,
        string? buttonUrl = null,
        string? code = null,
        string? footerNote = null)
    {
        ValidateSettings();

        var htmlBody = BuildHtmlTemplate(
            businessName,
            preHeader,
            title,
            message,
            buttonText,
            buttonUrl,
            code,
            footerNote);

        await _emailQueue.QueueEmailAsync(toEmail, subject, htmlBody);
    }

    private string BuildHtmlTemplate(
        string businessName,
        string preHeader,
        string title,
        string message,
        string? buttonText,
        string? buttonUrl,
        string? code,
        string? footerNote)
    {
        var companyName = Encode(_settings.CompanyName);
        var safeBusinessName = Encode(businessName);

        var buttonHtml = !string.IsNullOrWhiteSpace(buttonText) && !string.IsNullOrWhiteSpace(buttonUrl)
            ? $"""
              <tr>
                <td align="center" style="padding:30px 0 10px;">
                  <a href="{buttonUrl}"
                     style="display:inline-block;background:#c9a46a;color:#151515;text-decoration:none;
                            padding:15px 30px;border-radius:999px;font-weight:900;font-size:15px;
                            box-shadow:0 14px 34px rgba(201,164,106,.26);">
                    {Encode(buttonText)}
                  </a>
                </td>
              </tr>
              """
            : "";

        var codeHtml = !string.IsNullOrWhiteSpace(code)
            ? $"""
              <tr>
                <td align="center" style="padding:28px 0 12px;">
                  <div style="display:inline-block;letter-spacing:8px;background:#fffaf4;color:#151515;
                              padding:18px 26px;border-radius:22px;font-size:30px;font-weight:900;
                              border:1px solid #eadfd3;">
                    {Encode(code)}
                  </div>
                </td>
              </tr>
              """
            : "";

        return $$"""
        <!doctype html>
        <html lang="sv">
        <head>
          <meta charset="utf-8">
          <meta name="viewport" content="width=device-width, initial-scale=1">
          <title>{{Encode(title)}}</title>
        </head>

        <body style="margin:0;padding:0;background:#f8f4ed;font-family:Arial,Helvetica,sans-serif;color:#151515;">
          <div style="display:none;max-height:0;overflow:hidden;opacity:0;">
            {{Encode(preHeader)}}
          </div>

          <table role="presentation" width="100%" cellpadding="0" cellspacing="0" style="background:#f8f4ed;padding:38px 16px;">
            <tr>
              <td align="center">
                <table role="presentation" width="100%" cellpadding="0" cellspacing="0"
                       style="max-width:660px;background:#ffffff;border-radius:34px;overflow:hidden;
                              box-shadow:0 28px 80px rgba(34,24,18,.12);border:1px solid #eadfd3;">

                  <tr>
                    <td style="background:linear-gradient(135deg,#fffaf4,#ffffff);padding:38px 36px;color:#151515;border-bottom:1px solid #eadfd3;">
                      <div style="font-size:12px;text-transform:uppercase;letter-spacing:2.4px;color:#9a7b4f;font-weight:900;">
                        {{companyName}}
                      </div>

                      <div style="font-size:32px;font-weight:900;margin-top:10px;line-height:1.2;color:#151515;">
                        {{safeBusinessName}}
                      </div>

                      <div style="font-size:14px;margin-top:10px;color:#7a6f63;">
                        Smarta bokningar, enkelt hanterade.
                      </div>
                    </td>
                  </tr>

                  <tr>
                    <td style="padding:40px 36px 18px;">
                      <h1 style="margin:0;font-size:29px;line-height:1.25;color:#151515;">
                        {{Encode(title)}}
                      </h1>

                      <div style="margin-top:18px;font-size:16px;line-height:1.8;color:#4b5563;">
                        {{message}}
                      </div>
                    </td>
                  </tr>

                  {{buttonHtml}}
                  {{codeHtml}}

                  <tr>
                    <td style="padding:28px 36px 38px;">
                      <div style="border-top:1px solid #eadfd3;padding-top:22px;font-size:13px;line-height:1.7;color:#7a6f63;">
                        {{Encode(footerNote ?? $"Skickat av {_settings.CompanyName} för {businessName}.")}}
                      </div>
                    </td>
                  </tr>
                </table>

                <div style="font-size:12px;color:#9b9288;margin-top:18px;">
                  © {{DateTime.Now.Year}} {{companyName}}. Byggt för moderna serviceverksamheter.
                </div>
              </td>
            </tr>
          </table>
        </body>
        </html>
        """;
    }

    private string Encode(string? value)
    {
        return _htmlEncoder.Encode(value ?? "");
    }

    private static string TranslateStatus(string status)
    {
        return status switch
        {
            "Pending" => "Väntande",
            "Confirmed" => "Bekräftad",
            "Cancelled" => "Avbokad",
            _ => status
        };
    }

    private void ValidateSettings()
    {
        if (string.IsNullOrWhiteSpace(_settings.Host))
            throw new InvalidOperationException("EmailSettings:Host is missing.");

        if (string.IsNullOrWhiteSpace(_settings.Email))
            throw new InvalidOperationException("EmailSettings:Email is missing.");

        if (string.IsNullOrWhiteSpace(_settings.Password))
            throw new InvalidOperationException("EmailSettings:Password is missing.");
    }
}