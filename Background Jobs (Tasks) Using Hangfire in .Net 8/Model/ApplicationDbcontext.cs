using Microsoft.EntityFrameworkCore;

namespace Background_Jobs__Tasks__Using_Hangfire_in_.Net_8.Model
{
    public class ApplicationDbcontext : DbContext
    {
        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : base(options)
        {

        }
    }
}
