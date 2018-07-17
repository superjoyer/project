using BettingSummaryApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace BettingSummaryApp.Classes
{
    class DataContextProvider : DbContext
    {
        public DataContextProvider() 
            : base("DbConnection")
        { }

        public DbSet<Departament> DepartamentTable { get; set; }

        public DbSet<Position> PositionTable { get; set; }

        public DbSet<Bettings> BettingsTable { get; set; }

        public DbSet<Shedule> SheduleTable { get; set; }

        public DbSet<Report> ReportTable { get; set; }
    }
}
