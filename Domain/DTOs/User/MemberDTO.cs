using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public class MemberDTO
    {

        #region Properties

        [Key]
        public int UserId { get; set; }

       
        public string UserName { get; set; }

        public string Email { get; set; }

      
        public int Age{ get; set; }


        public string KnowAs { get; set; }

        public string Mobile { get; set; }


        public string Gender { get; set; }


        public string Introduction { get; set; }


        public string LookingFor { get; set; }




        public string Intrests { get; set; }


        [Display(Name = "شهر")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string City { get; set; }


        [Display(Name = "کشور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Country { get; set; }



        public string AvatarName { get; set; }

        [Display(Name = "وضعیت")]
        public bool IsActiveEmail { get; set; }

        [Display(Name = "تاریخ ثبت نام")]
        public DateTime RegisterDate { get; set; }

        #endregion


        #region Relations

        public ICollection<PhotoDTO> PhotoDTOs { get; set; }

        #endregion

    }
}
