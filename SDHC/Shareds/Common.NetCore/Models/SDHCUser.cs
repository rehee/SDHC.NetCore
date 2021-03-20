using Common.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.NetCore.Models
{
  public class SDHCUser : IdentityUser, IUserBase
  {
    public virtual string DisplayName()
    {
      return String.IsNullOrEmpty(this.UserName) ? this.Id : this.UserName;
    }
    public override string ToString()
    {
      return this.DisplayName();
    }

    [IgnoreEdit]
    public virtual TUser GetCustomUser<TUser>() where TUser : SDHCUser
    {
      return this as TUser;
    }

    private DateTime? _createDate { get; set; }

    [InputType(EditorType = EnumInputType.DateTime)]
    [HideEdit]
    public virtual DateTime? CreateDate
    {
      get
      {
        if (_createDate == null)
        {
          _createDate = DateTime.UtcNow;
        }
        return _createDate;
      }
      set
      {
        if (value.HasValue)
          _createDate = value;
      }
    }

    [IgnoreEdit]
    public string WeChatOpenId { get; set; }

    //public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

    public string GetUserName()
    {
      return this.UserName;
    }
    public string GetEmail()
    {
      return this.Email;
    }
  }
}
