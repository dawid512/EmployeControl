using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EmployeeControl.Models
{

    public class ApplicationUser : IdentityUser
    {   
        [PersonalData]
        [Display(Name = "Imię")]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Display(Name = "Nazwisko")]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string Rola { get; set; }

    }
}
