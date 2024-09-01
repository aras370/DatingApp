using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Account
{
    public class ForgotPasswordDTO
    {


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }


    }
}
