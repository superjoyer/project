using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp.Models
{
    //Отчет
    [Table("ReportTable")]
    class Report
    {

        public int reportId { get; set; }


        public Departament departament { get; set; }


        public DateTime? actionStartDate { get; set; }


        public DateTime? actionEndDate { get; set; }


        public int FOTdepartament { get; set; }

    }
}
