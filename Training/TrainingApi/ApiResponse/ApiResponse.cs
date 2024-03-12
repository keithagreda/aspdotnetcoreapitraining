using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.ApiResponse
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }
        public bool isSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
