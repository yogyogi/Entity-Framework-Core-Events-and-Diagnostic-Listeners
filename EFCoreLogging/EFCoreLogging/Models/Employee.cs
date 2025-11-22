using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreLogging.Models
{
    public class Employee : IHasTimestamps
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Designation { get; set; }

        [NotMapped]
        public DateTime? Added { get; set; }

        [NotMapped]
        public DateTime? Deleted { get; set; }

        [NotMapped]
        public DateTime? Modified { get; set; }

        public override string ToString() => $"Employee {Id}{this.ToStampString()}";

    }
}