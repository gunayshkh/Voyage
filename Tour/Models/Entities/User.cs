﻿using Microsoft.AspNetCore.Identity;

namespace Voyage.Models.Entities
{
    public class User: IdentityUser
    {
        public int Id{ get; set; }
        public string FullName { get; set; }
        public string ImageURL { get; set; }
    }
}
