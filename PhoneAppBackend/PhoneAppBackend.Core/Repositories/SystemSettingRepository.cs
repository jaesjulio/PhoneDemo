using PhoneAppBackend.Core.DB;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Repositories.Framework;
using PhoneAppBackend.Core.Services.Framework;
using System.Collections.Generic;
using System.Linq;

namespace PhoneAppBackend.Core.Repositories
{
    public class SystemSettingRepository: BaseRepository<SystemSetting>,ISystemSettingRepository
    {
        public SystemSettingRepository(ApplicationDbContext database) : base(database)
        {

        }


    }
    public interface ISystemSettingRepository : IBaseRepository<SystemSetting>
    {

    }
}
