using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessoSeletivoAPI.Helpers
{
    public class CustomResponse<T>
    {
        public bool IsSuccess { get; set; }
        public string[] Message { get; set; }
        public T ResponseData { get; set; }

        public CustomResponse()
        {
        }

        public CustomResponse(bool status, string[] message, T data)
        {
            IsSuccess = status;
            Message = message;
            ResponseData = data;
        }

        public CustomResponse(bool status, T data)
        {
            IsSuccess = status;
            ResponseData = data;
        }

        public CustomResponse(bool status, string[] message)
        {
            IsSuccess = status;
            Message = message;
        }

        public CustomResponse(bool status)
        {
            IsSuccess = status;
        }
    }
}
