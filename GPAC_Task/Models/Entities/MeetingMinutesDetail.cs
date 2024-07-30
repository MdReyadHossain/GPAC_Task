using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GPAC_Task.Models.Entities
{
    public class MeetingMinutesDetail
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MeetingMinutesMaster")]
        public int MeetingMinutesMasterId { get; set; }
        public virtual required MeetingMinutesMaster MeetingMinutesMaster { get; set; }

        [ForeignKey("ProductService")]
        public int ProductServiceId { get; set; }
        public virtual required ProductService ProductService { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
