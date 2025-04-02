using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Microsoft.VisualBasic;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;


namespace ClassLibrary
{
    public class List
    {

    }
    public class Ideal
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Mov_1 { get; set; }
        public string? Mov_2 { get; set; }
        public string? Desc { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<Ideal> Ideals { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Red_Stone_15;Username=postgres;Password=123");
        }
    }

}
