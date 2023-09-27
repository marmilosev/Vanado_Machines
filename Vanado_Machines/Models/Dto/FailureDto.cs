using System.ComponentModel.DataAnnotations.Schema;

namespace Vanado_Machines.Models.Dto
{
    public class FailureDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> MachineIds { get; set; }
        public string Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
