using Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }


        [Required(ErrorMessage = "نام را وارد کنید")]
        [MaxLength(50)]
        [Display(Name = "نام")]

        public string UserName { get; set; }

        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(50)]
        [EmailAddress(ErrorMessage = "فرمت ایمیل وارد شده صحیح نیست")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Password { get; set; }


        [Display(Name = "تاریخ تولد")]
        public DateTime? DateOfBirth { get; set; } = DateTime.Now;


        [Display(Name = "آخرین بازدید")]
        public DateTime? LastSeen { get; set; } = DateTime.Now;


        [Display(Name = "طریق آشنایی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]

        public string? KnowAs { get; set; }


        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Gender { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Mobile { get; set; }




        public string? Introduction { get; set; }


       

        public string? LookingFor { get; set; }


        

        public string? Intrests { get; set; }


        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? City { get; set; }


        [Display(Name = "کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string? Country { get; set; }



        public string? AvatarName { get; set; }

        [Display(Name = "وضعیت")]
        public bool? IsActiveEmail { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime? RegisterDate { get; set; }



        #region Relations

        public ICollection<Photo> Photos{ get; set; }

        #endregion


    }
}
