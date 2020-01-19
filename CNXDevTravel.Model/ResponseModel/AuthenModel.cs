using System;
using System.Collections.Generic;
using System.Text;

namespace CNXDevTravel.Model.ResponseModel
{
    public class AuthenModel
    {
        public string Name { get; set; }
        public string ProfileImage { get; set; }
        public string Token { get; set; }
        public string TokenType { get; set; } = "Bearer";
    }
}
