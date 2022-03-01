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

        public MultiPlayerTurnBasedContext(DbContextOptions options) : base(options)
        {

        }


    public DbSet<InitialProgress> InitialProgress{ get; set; }

     protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        } 

    }
}
