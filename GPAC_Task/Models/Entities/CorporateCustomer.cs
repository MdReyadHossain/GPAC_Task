using System.ComponentModel.DataAnnotations;

namespace GPAC_Task.Models.Entities
{
    public class CorporateCustomer
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public virtual required ICollection<MeetingMinutesMaster> MeetingMinutesMasters { get; set; }

        public CorporateCustomer()
        {
            MeetingMinutesMasters = new List<MeetingMinutesMaster>();
        }
    }
}
