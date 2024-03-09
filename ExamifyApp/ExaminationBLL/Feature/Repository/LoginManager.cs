using ExaminationDAL.Entities;
using ExaminationBLL.Feature.Interface;
using ExaminationBLL.Mapping.UserMapping;
using ExaminationBLL.ModelVM.Authentication;
using ExaminationBLL.ModelVM.UserVM;
using ExaminationDAL.Context;
using Microsoft.EntityFrameworkCore;

namespace ExaminationBLL.Feature.Repository
{
    public class LoginManager : ILoginRepo
    {
        private readonly ApplicationDbContext _context;
        private UserMapper userMapper;
        public LoginManager(ApplicationDbContext context)
        {
            _context = context;
            userMapper = new UserMapper();
        }

        public User CheckIfUserFound(string username)
        {
            var user = new User();
            user = _context.Users.Where(x => x.UserName == username).Include(a => a.Role).FirstOrDefault();
            return user;
        }
        public UserVM IsValid(LoginVM loginVM)
        {
            var user = CheckIfUserFound(loginVM.UserName);
            if (user != null)
            {
                if (user.Password == loginVM.Password)
                    return userMapper.Mapping(user);
            }
            return null;

        }
    }
}
