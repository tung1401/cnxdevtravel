using CNXDevTravel.Model.Entities;
using MFEC.SQ.Repository.Bases;
using Microsoft.EntityFrameworkCore;


namespace CNXDevTravel.Repository.Implements
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context) { }
    }
}
