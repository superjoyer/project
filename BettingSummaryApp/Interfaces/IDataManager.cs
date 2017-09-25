using BettingSummaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp
{
    interface IDataManager
    {
        event EventHandler changeList;

        IEnumerable<DateDependencyModel> ListPropertyDependPosition { get; set;}

        IEnumerable<Departament> DepartamentProperty { get; set; }

        IEnumerable<Bettings> BettingProperty { get; set; }

        List<Position> PositionProperty { get; set; }

        IEnumerable<Shedule> SheduleProperty { get; set; }

        IEnumerable<Report> ReportProperty { get; set; }

      





        void Load();

        void InsertToBetting(object obj);

        void InsertToShedule(object obj);

        void InsertToReports(object parameter);
    }
}
