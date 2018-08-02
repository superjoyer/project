using BettingSummaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp
{
    interface IDataContract
    {
     
        void SetInsertValue(object param);

        IEnumerable<Departament> GetListDepartments();

        IEnumerable<Position> GetListPositions();
    }
}
