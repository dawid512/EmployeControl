using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeControl.Models
{
    public class EmployeeDayStatus
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data od")]
       
        public DateTime CheckIn { get; set; } = DateTime.Now;

        [Display(Name = "Data do")]
   
        public DateTime? CheckOut { get; set; } 

        [Display(Name = "Notatka")]
        public string Notes { get; set; }
        [Display(Name = "Status")]
        public string Status { get; set; }
        [Display(Name = "Status Rozpoczęcie Pracy")]
        public bool statusStartWork { get; set; }
        [Display(Name = "Status Zakończenie Pracy")]
        public bool statusEndWork { get; set; }



    
        [Display(Name = "Pracownik")]
        public virtual ApplicationUser Idusera { get; set; }
    }
}
