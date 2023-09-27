namespace Vanado_Machines.Models.Dto
{
    public class MachineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> FailureIds { get; set; }
        public double AverageFailureDuration { get; set; }
    }
}
