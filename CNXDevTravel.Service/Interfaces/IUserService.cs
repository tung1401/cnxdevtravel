using CNXDevTravel.Model.RequestModel;
using CNXDevTravel.Model.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace CNXDevTravel.Service.Interfaces
{
    public interface IUserService
    {
        AuthenModel Authen(LoginModel loginModel);
    }
}
