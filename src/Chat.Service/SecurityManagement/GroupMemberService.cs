using System.Collections.Generic;
using System.Linq;

using Chat.Core.Data;
using Chat.Core.Domain.SecurityManagement;
using Chat.Data.DatabaseContext;
using System.Data.SqlClient;

namespace Chat.Service.SecurityManagement
{
    public class GroupMemberService : BaseService<SecurityManagementContext, GroupMember, int>, IGroupMemberService
    {
        public GroupMemberService(IRepository<SecurityManagementContext, GroupMember, int> repository) : base(repository)
        {

        }

        public GroupMember StoreFind(int id)
        {
            var sId = new SqlParameter("Id", id);
            var query = this._repository.FromSql("Store_Inside_GroupMember_Find @Id", sId);
            var query1 = this._repository.FromSql($"Store_Inside_GroupMember_Find {id}");
            return query.SingleOrDefault();
        }

        public IEnumerable<GroupMember> StoreFindAll()
        {
            var query = this._repository.FromSql("Store_Inside_GroupMember_All");
            return query.ToList();
        }
    }
}
