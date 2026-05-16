using EasySystems.Bookings.Data.Entities;

namespace EasySystems.Bookings.Services;

public interface IBookingEmailSender
{
    Task SendBookingCreatedToCustomerAsync(Booking booking);

    Task SendBookingCreatedToBusinessAsync(Booking booking);

    Task SendBookingStatusChangedToCustomerAsync(Booking booking);

    Task SendBookingConfirmedToCustomerAsync(Booking booking);

    Task SendBookingCancelledToCustomerAsync(Booking booking);

    Task SendBookingCancelledToBusinessAsync(Booking booking);
}