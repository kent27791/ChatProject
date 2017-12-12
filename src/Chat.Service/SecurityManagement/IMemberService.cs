using Chat.Core.Domain.SecurityManagement;
using Chat.Core.Service;
using Chat.Data.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chat.Service.SecurityManagement
{
    public interface IMemberService : IService<SecurityManagementContext, Member, int>
    {

    }
}
