using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TTrackerDemo.Models
{
    public class Ticket
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Creation Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Required]
        public SeverityLevel Severity { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Resolved { get; set; }

        [Required]
        public string Issue { get; set; }

        public string Resolution { get; set; }
    }

    public enum SeverityLevel
    {
        Low,
        Medium,
        Urgent
    }
}