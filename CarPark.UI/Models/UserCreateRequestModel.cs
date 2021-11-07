using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarPark.UI.Models
{
    public class UserCreateRequestModel
    {
        [Required(ErrorMessage = "NameSurname_Required")]
        [DisplayName("NameSurname")]
        public string NameSurname { get; set; }
        [Required(ErrorMessage = "This is required")]
        [DisplayName("JobTitle_Required")]
        public string JobTitle { get; set; }
    }
}
