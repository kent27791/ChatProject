using Chat.Core.Data;
using Chat.Core.Domain.SecurityManagement;
using Chat.Data.DatabaseContext;

namespace Chat.Service.SecurityManagement
{
    public class GroupMemberService : BaseService<SecurityManagementContext, GroupMember, int>, IGroupMemberService
    {
        public GroupMemberService(IRepository<SecurityManagementContext, GroupMember, int> repository) : base(repository)
        {

        }
    }
}
