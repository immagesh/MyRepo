using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TableReservation.Models
{
    public class Users
    {
        public int UserId { get; set; }

        public int ResturantId { get; set; }

        public int ResgistrationId { get; set; }

        public int StatusId { get; set; }

        public int GuestCount { get; set; }

        public System.DateTime ApptDate { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public string Email { get; set; }

        public System.DateTime CreatedDate { get; set; }

    }
}