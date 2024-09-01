using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTOs.Public
{
    public class ResponseResult
    {

        public bool IsSuccess { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }

        public ResponseResult(bool issuccess)
        {
            IsSuccess = issuccess;
        }

        public ResponseResult(bool issuccess,string message)
        {
            IsSuccess = issuccess;
            Message = message;
        }

        public ResponseResult(bool issuccess, string message,object data)
        {
            IsSuccess = issuccess;
            Message = message;
            Data = data;
        }

    }
}
