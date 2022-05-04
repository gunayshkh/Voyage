using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voyage.Areas.Admin.Models.ViewModels
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string Image { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public bool IsActivated { get; set; }
        public List<string> Roles { get; set; }
        public bool IsArchived { get; set; }

    }
}
