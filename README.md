# EasySystems Bookings

![.NET](https://img.shields.io/badge/.NET-9.0-purple?style=flat-square)
![Blazor](https://img.shields.io/badge/Blazor-Server-blueviolet?style=flat-square)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red?style=flat-square)
![Identity](https://img.shields.io/badge/Auth-ASP.NET%20Identity-green?style=flat-square)
![Booking](https://img.shields.io/badge/Platform-Booking%20System-orange?style=flat-square)

---

# EasySystems Bookings

EasySystems Bookings is a modern online booking platform built with Blazor Server and ASP.NET Core.

The system is designed for a single business that wants a professional website where customers can view services, choose staff members, and request appointments online.

The platform includes a public booking website and a secure admin panel for managing the business, services, staff, bookings, calendar, and working hours.

Each business can manage:

* Public booking page
* Business profile
* Services
* Staff members
* Online bookings
* Daily calendar
* Working hours
* Booking intervals
* Customer contact information
* Booking status
* Payments status
* Admin permissions

The goal is to provide small and medium sized service businesses with a complete online booking system without requiring technical knowledge.

---

## 🎯 Purpose & Vision

Many small service businesses manage bookings manually through phone calls, messages, social media, and paper calendars.

EasySystems Bookings centralizes the full booking process into one simple platform.

Business owners can:

* Manage business information
* Set opening and closing hours
* Control online booking availability
* Add and edit services
* Add and edit staff members
* Manage customer bookings
* View bookings in a calendar
* Prevent booking conflicts
* Track payment status
* Manage permissions securely

Customers can:

* Visit the business website
* View available services
* View staff members
* Select a service
* Select a staff member
* Choose date and time
* Send a booking request
* Add notes and contact information

---

## 🧩 Key Features

### Business Website

✔ Public booking page

✔ Single business website

✔ Business name and description

✔ Business type

✔ Logo support

✔ Cover image support

✔ City and contact information

✔ Opening and closing hours

✔ Mobile responsive layout

✔ Customer friendly booking experience

---

### Online Booking System

✔ Customer booking form

✔ Service selection

✔ Staff member selection

✔ Date selection

✔ Time selection

✔ Customer name

✔ Customer email

✔ Customer phone

✔ Booking notes

✔ Pending booking status

✔ Conflict prevention

✔ Business hours validation

✔ Future time validation

✔ Booking request creation

---

### Business Management

✔ Business settings page

✔ Business profile editing

✔ Slug management

✔ Contact information

✔ Address and city

✔ Opening time

✔ Closing time

✔ Booking interval minutes

✔ Enable or disable online bookings

✔ Active or inactive business status

✔ Logo URL

✔ Cover image URL

---

### Services Management

✔ Create services

✔ Edit services

✔ Service name

✔ Service description

✔ Price

✔ Duration in minutes

✔ Sort order

✔ Active or inactive status

✔ Business specific services

✔ Public service display

---

### Staff Management

✔ Create staff members

✔ Edit staff members

✔ Full name

✔ Email

✔ Phone

✔ Specialization

✔ Bio

✔ Image URL

✔ Sort order

✔ Active or inactive status

✔ Allow online bookings

✔ Business specific staff

✔ Public staff display

---

### Booking Management

✔ Admin booking list

✔ Create bookings manually

✔ Edit bookings

✔ Customer contact information

✔ Service information

✔ Staff information

✔ Booking date and time

✔ Booking status

✔ Booking notes

✔ Payment status

✔ Paid amount

✔ Payment method

✔ Cancellation reason

✔ Conflict detection

✔ Working hours validation

---

### Calendar System

✔ Business daily calendar

✔ Calendar based on business working hours

✔ Booking interval support

✔ Daily schedule view

✔ Bookings grouped by time slots

✔ Customer details inside calendar

✔ Service and staff details

✔ Booking status badges

✔ Edit booking from calendar

---

### Permissions & Access Control

✔ ASP.NET Identity

✔ Role based authorization

✔ PlatformSuperAdmin role

✔ BusinessOwner role

✔ BusinessAdmin role

✔ Staff role

✔ Customer role

✔ Business specific access system

✔ BusinessAccessService

✔ BusinessPermissionResult

✔ AdminBusinessPageBase

✔ Permission based admin navigation

✔ Prevents unauthorized business access

---

### Admin Experience

✔ Admin navbar

✔ Business overview page

✔ Services management

✔ Staff management

✔ Bookings management

✔ Calendar management

✔ Business settings

✔ Responsive admin UI

✔ Mobile friendly navigation

✔ Secure logout

✔ Permission based menu items

---

## 🛠️ Tech Stack

* .NET 9
* Blazor Server
* ASP.NET Core
* Entity Framework Core
* SQL Server
* ASP.NET Identity
* Role Based Authorization
* Razor Components
* Bootstrap
* HTML
* CSS

---

## 💼 Main Areas

### Public Website

* Home page
* Business profile
* Services
* Staff members
* Booking form
* Customer contact form
* Appointment request

### Admin Area

* Business Overview
* Business Settings
* Services
* Staff
* Bookings
* Calendar

### Access System

* Platform Super Admin
* Business permissions
* Business access validation
* Permission based navigation
* Protected admin pages

---

## 🔐 Roles & Permissions

### PlatformSuperAdmin

Has full access to the entire platform.

Can manage:

* Businesses
* Services
* Staff
* Bookings
* Calendar
* Settings
* Permissions

### BusinessOwner

Can manage assigned business areas depending on permissions.

### BusinessAdmin

Can manage selected business features depending on assigned permissions.

### Staff

Can access assigned business areas depending on assigned permissions.

### Customer

Can use the public booking page and request appointments.

---

## 🏢 Business Permissions

The system uses business specific permissions through `BusinessUser`.

Each business user can have:

* CanManageServices
* CanManageStaff
* CanManageBookings
* CanManageCalendar
* CanManageSettings

This allows fine grained access control per business.

---

## 🧱 Project Architecture

The project is organized with a clean structure.

### Data

Contains the database context and main application data layer.

### Data / Entities

Contains core entities such as:

* Business
* Service
* StaffMember
* Booking
* BusinessUser
* ApplicationUser

### Data / Access

Contains business access and permission logic:

* BusinessAccessService
* BusinessPermissionResult

### Data / Identity

Contains identity and role definitions:

* AppRoles

### Components / Admin

Contains shared admin page base logic:

* AdminBusinessPageBase

### Components / Layout

Contains shared layout and navigation:

* AdminNavbar

### Components / Pages

Contains public and admin pages.

---

## 📅 Booking Flow

Customer booking flow:

1. Customer opens the public website
2. Customer selects a service
3. Customer selects a staff member
4. Customer selects date and time
5. Customer enters contact information
6. System validates business hours
7. System checks staff booking conflicts
8. Booking is created with Pending status

Admin booking flow:

1. Admin opens business bookings
2. Admin creates or edits booking
3. Admin selects service and staff
4. System calculates end time automatically
5. System prevents overlapping bookings
6. Admin manages status and payment information

---

## 📊 Business Overview

The business overview page shows important business information such as:

* Today bookings
* Upcoming bookings
* Active services
* Active staff
* Today schedule
* Quick actions

It acts as the main control center for the business.

---

## 🎨 Design System

The system includes a modern responsive interface for both public and admin areas.

### Public Website

* Hero section
* Business cover image
* Business logo
* Service cards
* Staff cards
* Booking form
* Mobile responsive layout

### Admin Area

* Sticky admin navbar
* Responsive menu
* Cards
* Tables
* Badges
* Forms
* Calendar layout
* Mobile friendly navigation

---

## 🚀 Current Platform Status

The platform currently includes:

* Single business public booking website
* Business admin panel
* Business overview
* Services management
* Staff management
* Booking management
* Calendar management
* Business settings
* Online booking form
* Staff conflict prevention
* Business hours validation
* Booking interval support
* Payment status fields
* Permission based admin system
* Responsive public and admin UI

The project has evolved into a complete booking system for service based businesses.

---

## 🔮 Future Improvements

Planned improvements may include:

* Email notifications
* SMS notifications
* Customer accounts
* Online payments
* Booking confirmation emails
* Staff availability rules
* Weekly calendar view
* Customer booking history
* Admin analytics
* Image upload system
* Public theme customization
* Multi language support

---

## 👨‍💻 Developers

Built by Saher Zaid and Samer Zaid

📧 [Saherzaid1997@gmail.com](mailto:Saherzaid1997@gmail.com)

📧 [Smooory2012@gmail.com](mailto:Smooory2012@gmail.com)

🔗 LinkedIn:

https://www.linkedin.com/in/saher-zaid-4584842a7/

https://www.linkedin.com/in/samer-zaid-32370a289/

📞 +46 738 785 036

📞 +46 738 785 236

---
