using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Services.SmsServices
{
  public interface ISmsService
  {
    Task SendSmsAsync(string number, string message);
  }
  public class SmsService : ISmsService
  {
    public Task SendSmsAsync(string number, string message)
    {
      return Task.CompletedTask;
    }
  }
}
