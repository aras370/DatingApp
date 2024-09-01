using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.User
{
    public class PhotoDTO
    {

        [Key]
        public int PhotoId { get; set; }

        public string Url { get; set; }

        public bool IsMain { get; set; }


    }
}
