using Chat.Core.Data;
using Chat.Core.Domain.LogManagement;
using Chat.Data.DatabaseContext;

namespace Chat.Service.LogManagement
{
    public class SystemLogService : BaseService<LogManagementContext, SystemLog, int>, ISystemLogService
    {
        public SystemLogService(IRepository<LogManagementContext, SystemLog, int> repository) : base(repository)
        {

        }
    }
}
