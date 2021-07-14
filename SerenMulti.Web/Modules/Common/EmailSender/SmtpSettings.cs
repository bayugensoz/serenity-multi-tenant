
namespace SerenMulti.Common
{
    public class SmtpSettings
    {
        public const string SectionKey = "SmtpSettings";

        public string Host { get; set; }
        public int Port { get; set; }
        public bool UseSsl { get; set; }
        public string From { get; set; }
        public string PickupPath { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
    }
}