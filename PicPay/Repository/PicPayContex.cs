using Microsoft.EntityFrameworkCore;
using PicPay.SharedKernel.Models;

namespace PicPay.Repository
{
    public class PicPayContex : DbContext
    {
        public PicPayContex(DbContextOptions<PicPayContex> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
