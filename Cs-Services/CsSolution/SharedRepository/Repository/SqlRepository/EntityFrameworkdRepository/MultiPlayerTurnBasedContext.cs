using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedRepository.Repository.SqlRepository.EntityFrameworkdRepository
{
    public class MultiPlayerTurnBasedContext : DbContext
    {
        public DbSet<InitialProgress> InitialProgress{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql("Host=localhost;Database=multiplayer_turnbased;Username=moeen;Password=moeen777");
      

    }
}
