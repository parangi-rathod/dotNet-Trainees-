using Microsoft.EntityFrameworkCore;
using Sports.Interface;
using Sports.Model;

namespace Sports.Repository
{
    public class CaptainRepo : ICaptainRepo
    {
        private readonly AppDbContext _context;
        public CaptainRepo(AppDbContext context)
        {
            _context= context;
        }
        public async Task UpdateUserIsMem(int id)
        {
            var user = await _context.UserModel.FirstOrDefaultAsync(u => u.UserId == id);

            if (user != null)
            {
                user.isMember = true; 
                await _context.SaveChangesAsync();
            }
        }
    }
}
