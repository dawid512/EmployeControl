using EmployeeControl.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeControl.ViewModels
{
    public class EmployeeDayStatusUsersListViewModel :EmployeeDayStatus
    {
        public ICollection<EmployeeDayStatus> EmployeeDayStatus { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }

        [Display(Name = "Pracownik")]
        public string userID { get; set; }
    }
}
