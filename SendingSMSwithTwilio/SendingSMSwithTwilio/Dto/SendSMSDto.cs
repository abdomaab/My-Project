using System.ComponentModel.DataAnnotations;

namespace SendingSMSwithTwilio.Dto
{
    public class SendSMSDto
    {
        public string MobileNumber { get; set; }
        public string Body { get; set; }
    }
}
