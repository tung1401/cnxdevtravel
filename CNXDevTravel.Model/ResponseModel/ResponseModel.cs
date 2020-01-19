using System;
using System.Collections.Generic;
using System.Text;

namespace CNXDevTravel.Model.ResponseModel
{
    public class ResponseModel<T>
    {
        public string Status { get; set; }
        public string Description { get; set; }
        public T Data { get; set; }
    }
}
