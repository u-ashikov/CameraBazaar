namespace CameraBazaar.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
		public List<Camera> Cameras { get; set; } = new List<Camera>();

		public DateTime? LastLoginTime { get; set; }

		public DateTime? FirstLoginTime { get; set; }

		public bool IsRestricted { get; set; }
    }
}
