﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Bootcamp.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
		public string LastName { get; set; }
		
		public string Email { get; set; }
		
		public string Password { get; set; }
		
		
		public List<PhoneNumber> PhoneNumber { get; set; } = new List<PhoneNumber>();
        public List<BillingAddress> BillingAddress  { get; set; } = new List<BillingAddress>();

    }
}
