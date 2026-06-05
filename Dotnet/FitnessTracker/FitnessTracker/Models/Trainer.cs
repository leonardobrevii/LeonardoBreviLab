using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Trainer
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Specialization { get; set; }

        public List<Training>? Trainings { get; set; }
    }
}