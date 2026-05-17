using System.ComponentModel.DataAnnotations;

namespace EasySystems.Bookings.Data.Entities;

public class Business
{
    public int Id { get; set; }

    [Required]
    [MaxLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [MaxLength(150)]
    public string Slug { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? BusinessType { get; set; }

    [MaxLength(180)]
    public string? Tagline { get; set; }

    [MaxLength(1000)]
    public string? Description { get; set; }

    [MaxLength(250)]
    public string? Address { get; set; }

    [MaxLength(100)]
    public string? City { get; set; }

    [MaxLength(30)]
    public string? Phone { get; set; }

    [MaxLength(150)]
    [EmailAddress]
    public string? Email { get; set; }

    [MaxLength(500)]
    public string? WebsiteUrl { get; set; }

    [MaxLength(500)]
    public string? InstagramUrl { get; set; }

    [MaxLength(500)]
    public string? FacebookUrl { get; set; }

    [MaxLength(500)]
    public string? TikTokUrl { get; set; }

    [MaxLength(500)]
    public string? LogoUrl { get; set; }

    [MaxLength(1000)]
    public string? CoverImageUrl { get; set; }

    public bool IsActive { get; set; } = true;

    public bool AllowOnlineBookings { get; set; } = true;

    // Legacy/default fallback hours.
    // These can still be used as fallback if a specific day has missing values.
    public TimeSpan OpeningTime { get; set; } = new(9, 0, 0);

    public TimeSpan ClosingTime { get; set; } = new(21, 0, 0);

    public int BookingIntervalMinutes { get; set; } = 15;

    // Weekly opening hours
    public bool MondayIsOpen { get; set; } = true;

    public TimeSpan MondayOpeningTime { get; set; } = new(9, 0, 0);

    public TimeSpan MondayClosingTime { get; set; } = new(18, 0, 0);

    public bool TuesdayIsOpen { get; set; } = true;

    public TimeSpan TuesdayOpeningTime { get; set; } = new(9, 0, 0);

    public TimeSpan TuesdayClosingTime { get; set; } = new(18, 0, 0);

    public bool WednesdayIsOpen { get; set; } = true;

    public TimeSpan WednesdayOpeningTime { get; set; } = new(9, 0, 0);

    public TimeSpan WednesdayClosingTime { get; set; } = new(18, 0, 0);

    public bool ThursdayIsOpen { get; set; } = true;

    public TimeSpan ThursdayOpeningTime { get; set; } = new(9, 0, 0);

    public TimeSpan ThursdayClosingTime { get; set; } = new(18, 0, 0);

    public bool FridayIsOpen { get; set; } = true;

    public TimeSpan FridayOpeningTime { get; set; } = new(9, 0, 0);

    public TimeSpan FridayClosingTime { get; set; } = new(18, 0, 0);

    public bool SaturdayIsOpen { get; set; } = true;

    public TimeSpan SaturdayOpeningTime { get; set; } = new(10, 0, 0);

    public TimeSpan SaturdayClosingTime { get; set; } = new(16, 0, 0);

    public bool SundayIsOpen { get; set; }

    public TimeSpan SundayOpeningTime { get; set; } = new(10, 0, 0);

    public TimeSpan SundayClosingTime { get; set; } = new(16, 0, 0);

    [MaxLength(30)]
    public string PrimaryColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string SecondaryColor { get; set; } = "#C9A46A";

    [MaxLength(30)]
    public string PageBackgroundColor { get; set; } = "#F8F4ED";

    [MaxLength(30)]
    public string SectionBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string CardBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string HeadingTextColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string BodyTextColor { get; set; } = "#4B5563";

    [MaxLength(30)]
    public string MutedTextColor { get; set; } = "#7A6F63";

    [MaxLength(30)]
    public string ButtonBackgroundColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string ButtonTextColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string SecondaryButtonBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string SecondaryButtonTextColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string NavbarBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string NavbarTextColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string FooterBackgroundColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string FooterTextColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string HeroTextColor { get; set; } = "#FFFFFF";

    [MaxLength(80)]
    public string HeroOverlayColor { get; set; } = "rgba(0,0,0,.55)";

    [MaxLength(30)]
    public string ServiceCardBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string PriceTextColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string StaffCardBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string BookingPanelBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string SuccessColor { get; set; } = "#087443";

    [MaxLength(30)]
    public string WarningColor { get; set; } = "#B45309";

    [MaxLength(30)]
    public string DangerColor { get; set; } = "#B42318";

    [MaxLength(30)]
    public string InputBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string InputTextColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string InputBorderColor { get; set; } = "#E5E7EB";

    [MaxLength(30)]
    public string InputFocusColor { get; set; } = "#C9A46A";

    [MaxLength(30)]
    public string LabelTextColor { get; set; } = "#374151";

    [MaxLength(30)]
    public string TimeSlotBackgroundColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string TimeSlotTextColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string TimeSlotActiveBackgroundColor { get; set; } = "#151515";

    [MaxLength(30)]
    public string TimeSlotActiveTextColor { get; set; } = "#FFFFFF";

    [MaxLength(30)]
    public string CustomerPortalCardColor { get; set; } = "#FFFFFF";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public string? PrivacyPolicyHtml { get; set; }

    public string? TermsAndConditionsHtml { get; set; }

    public ICollection<BusinessUser> Users { get; set; } = [];

    public ICollection<Service> Services { get; set; } = [];

    public ICollection<StaffMember> StaffMembers { get; set; } = [];

    public ICollection<Booking> Bookings { get; set; } = [];
}