using GPAC_Task.Models.Entities;

namespace GPAC_Task.Models
{
    public class MeetingPayload
    {
        public required MeetingMinutesMaster meetingMinutesMaster { get; set; }
        public List<MeetingMinutesDetail>? meetingMinutesDetail { get; set; }
    }
}
