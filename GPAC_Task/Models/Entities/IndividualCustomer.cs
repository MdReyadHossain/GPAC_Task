using System.ComponentModel.DataAnnotations;

namespace GPAC_Task.Models.Entities
{
    public class IndividualCustomer
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public virtual required ICollection<MeetingMinutesMaster> MeetingMinutesMasters { get; set; }

        public IndividualCustomer()
        {
            MeetingMinutesMasters = new List<MeetingMinutesMaster>();
        }
    }
}
