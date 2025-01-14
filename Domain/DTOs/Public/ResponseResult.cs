using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Public
{
    public class ResponseResult
    {

        public bool Issuccess { get; set; }

        public string? Message { get; set; }

        public UserDTO? Data { get; set; }

        public ResponseResult(bool issuccess)
        {
            Issuccess = issuccess;
        }

        public ResponseResult(bool issuccess,string message)
        {
            Issuccess = issuccess;
            Message = message;
        }

        public ResponseResult(bool issuccess, string message,UserDTO data)
        {
            Issuccess = issuccess;
            Message = message;
            Data = data;
        }

    }
}
