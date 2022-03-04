using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public UserProfile UserProfile { get; set; }

    }
}
