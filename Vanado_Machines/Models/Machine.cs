namespace Vanado_Machines.Models
{
    public class Machine
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Failure> failures { get; set; } = new List<Failure>();

    }
}
