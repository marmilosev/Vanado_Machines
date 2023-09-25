﻿namespace Vanado_Machines.Models
{
    public class Failure
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Machine> Machines { get; set; } = new List<Machine>();
        public string Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}