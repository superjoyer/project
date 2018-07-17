using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace BettingSummaryApp.Models
{
    //Должность
    [Table("PositionTable")]
    class Position
    {
    
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int IdPosition { get; set; }

        public string PositionName { get; set; }

    }
}
