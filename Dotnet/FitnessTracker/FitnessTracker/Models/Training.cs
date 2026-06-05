using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Training
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nazwa treningu jest wymagana")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Rodzaj treningu jest wymagany")]
        [StringLength(30)]
        public string Type { get; set; }

        [Required(ErrorMessage = "Intensywność jest wymagana")]
        [StringLength(20)]
        public string Intensity { get; set; }

        public int? TrainerId { get; set; }

        public Trainer? Trainer { get; set; }
    }
}