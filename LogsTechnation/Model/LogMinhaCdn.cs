using System.ComponentModel.DataAnnotations;
using System;

namespace LogsTechnation.Model
{
    public class LogMinhaCdn
    {
        [Key]
        public long id { get; set; }
        public string log { get; set; }
        public DateTime data { get; set; }
    }
}
