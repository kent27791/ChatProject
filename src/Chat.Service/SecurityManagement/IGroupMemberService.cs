using System.Collections.Generic;

using Chat.Core.Domain.SecurityManagement;
using Chat.Core.Service;
using Chat.Data.DatabaseContext;

namespace Chat.Service.SecurityManagement
{
    public interface IGroupMemberService : IService<SecurityManagementContext, GroupMember, int>
    {
        IEnumerable<GroupMember> StoreFindAll();

        GroupMember StoreFind(int id);
    }
}
