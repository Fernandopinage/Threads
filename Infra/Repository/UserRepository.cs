using System;
using System.Linq.Expressions;
using Domain.Entity;
using Infra.Repository.BaseRepository;
using Infra.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context){}
               
    }
}
