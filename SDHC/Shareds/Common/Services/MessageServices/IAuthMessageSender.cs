using Common.Services.EmailServices;
using Common.Services.SmsServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Services.MessageServices
{
  // This class is used by the application to send Email and SMS
  // when you turn on two-factor authentication in ASP.NET Identity.
  // For more details see this link http://go.microsoft.com/fwlink/?LinkID=532713
  public interface IAuthMessageSender : IEmailService, ISmsService
  {

  }
}
