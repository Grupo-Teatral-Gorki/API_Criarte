using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_Criarte.Domain
{
    public class ApiResponse<T>
    {
        public bool Error { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(bool error, string message, T data = default(T))
        {
            Error = error;
            Message = message;
            Data = data;
        }

        public ApiResponse(bool error, string message)
        {
            Error = error;
            Message = message;
        }
    }
}
