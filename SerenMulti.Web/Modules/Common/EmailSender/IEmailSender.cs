using MimeKit;

namespace SerenMulti.Common
{
    public interface IEmailSender
    {
        void Send(MimeMessage message, bool skipQueue = false);
    }
}