﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain
{
    public class UserRoles
    {

        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserID { get; set; }



        [ForeignKey("Role")]
        public int RoleId { get; set; }



        public User User { get; set; }

        public Role Role{ get; set; }

    }
}
