using Chat.Core.Domain.LogManagement;
using Chat.Core.Service;
using Chat.Data.DatabaseContext;

namespace Chat.Service.LogManagement
{
    public interface ISystemLogService : IService<LogManagementContext, SystemLog, int>
    {
    }
}
