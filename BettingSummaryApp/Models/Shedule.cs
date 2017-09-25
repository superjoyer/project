using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp.Models
{
    //Расписание
    [Table("SheduleTable")]
    class Shedule
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int SheduleId { get; set; }

        public Departament departament { get; set; }

        public Position position { get; set; }

        public DateTime? actionStartDate { get; set; }

        public int countPerson { get; set; }
    }
}
