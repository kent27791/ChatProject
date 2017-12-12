using System.Collections.Generic;
using System.Linq;

using Chat.Core.Data;
using Chat.Core.Domain.SecurityManagement;
using Chat.Data.DatabaseContext;
using System.Data.SqlClient;

namespace Chat.Service.SecurityManagement
{
    public class MemberService : BaseService<SecurityManagementContext, Member, int>, IMemberService
    {
        public MemberService(IRepository<SecurityManagementContext, Member, int> repository) : base(repository)
        {
            
        }
    }
}
