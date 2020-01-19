using CNXDevTravel.Model.Entities;
using CNXDevTravel.Repository.Implements;
using CNXDevTravel.Service.Implements;
using CNXDevTravel.Service.Interfaces;
using System;

namespace CNXDevTravel.Service
{
    public class ServiceFactory : IDisposable
    {
        private CNXDevTravelDataContext _cnxDevTravelDb;

        public ServiceFactory(CNXDevTravelDataContext cnxDevTravelDb)
        {
            _cnxDevTravelDb = cnxDevTravelDb;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IUserService User()
        {
            return new UserService(new UserRepository(_cnxDevTravelDb));
        }
    }
}
