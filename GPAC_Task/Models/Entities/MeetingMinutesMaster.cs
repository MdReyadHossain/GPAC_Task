using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPAC_Task.Models.Entities
{
    public class MeetingMinutesMaster
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string CustomerType { get; set; }

        [ForeignKey("CorporateCustomer")]
        public int? CorporateCustomerId { get; set; }
        public virtual CorporateCustomer? CorporateCustomer { get; set; }

        [ForeignKey("IndividualCustomer")]
        public int? IndividualCustomerId { get; set; }
        public virtual IndividualCustomer? IndividualCustomer { get; set; }

        public DateTime MeetingDate { get; set; }

        [Required]
        public required string Place { get; set; }

        [Required]
        public required string ClientSide { get; set; }

        [Required]
        public required string HostSide { get; set; }

        [Required]
        public required string Agenda { get; set; }

        [Required]
        public required string Discussion { get; set; }

        [Required]
        public required string Decision { get; set; }
    }
}
