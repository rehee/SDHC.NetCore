using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.EmailServices
{
  public interface IEmailService
  {
    Task SendEmailAsync(string email, string subject, string message);
    string Host { get; set; }
    int Port { get; set; }
    string User { get; set; }
    string Password { get; set; }
    bool SSL { get; set; }
    void UpdateEmailSetting(string host, string port, string user, string password, string ssl);
    void SendEmail(string toUser, string title, string body, string fromUser);
  }
}
