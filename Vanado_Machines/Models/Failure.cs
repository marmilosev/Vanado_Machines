using System.ComponentModel.DataAnnotations.Schema;

namespace Vanado_Machines.Models
{
    public class Failure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Machine Machine { get; set; }
        public string Priority { get; set; }
        [Column("start_time")]
        public DateTime StartTime { get; set; }
        [Column("end_time")]
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
