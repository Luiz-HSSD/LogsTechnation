using System.ComponentModel.DataAnnotations;
using System;

namespace LogsTechnation.Model
{
    public class LogAgoraAntes
    {
        [Key]
        public long id { get; set; }
        public string log { get; set; }
        public DateTime data { get; set; }
        public long idAgora { get; set; }
    }
}
