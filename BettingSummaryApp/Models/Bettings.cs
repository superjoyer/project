using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp.Models
{
    [Table("BettingsTable")]
    class Bettings
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int BettingId { get; set; }

        public string position{ get; set; }

        public DateTime? actionStartDate{ get; set;}

        public int? Salary { get; set; }

    }
}
