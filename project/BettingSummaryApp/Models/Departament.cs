using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BettingSummaryApp.Models
{
    [Table("DepartamentTable")]
    class Departament
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int DepartId { get; set; }

        public string DepartamentName { get; set; }
    }
}
