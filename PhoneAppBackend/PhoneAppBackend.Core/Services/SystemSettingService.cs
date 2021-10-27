using PhoneAppBackend.Core.Framework;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneAppBackend.Core.Services
{
    public class SystemSettingService : BaseService<SystemSetting>, ISystemSettingService
    {
        private ISystemSettingRepository _systemSettingRepository;

        public SystemSettingService(ISystemSettingRepository systemSettingRepository)
        {
            _systemSettingRepository = systemSettingRepository;
        }
        public override TaskResult Create(SystemSetting entity)
        {
            try
            {
                ValidateOnCreate(entity);

                if (TaskResult.ExecutedSuccesfully)
                {
                    entity.IsActive = true;
                    _systemSettingRepository.Insert(entity);
                    _systemSettingRepository.CommitChanges();
                    TaskResult.AddMessage($"The SystemSetting {entity.Code} has been created.");
                }
            }
            catch (Exception exception)
            {
                TaskResult.ExecutedSuccesfully = false;
                TaskResult.Exception = exception;
            }

            return TaskResult;
        }

        public IEnumerable<SystemSetting> GetSystemSettings()
        {
            return _systemSettingRepository.Get(x => !x.IsDeleted).ToList();
        }

        public override TaskResult Delete(int entityId)
        {
            try
            {
                var systemSetting = GetById(entityId);

                ValidateOnDelete(systemSetting);

                if (TaskResult.ExecutedSuccesfully)
                {
                    _systemSettingRepository.SoftDelete(entityId);
                    _systemSettingRepository.CommitChanges();
                    TaskResult.AddMessage($"The SystemSetting {systemSetting.Code} has been deleted.");
                }
            }
            catch (Exception exception)
            {
                TaskResult.ExecutedSuccesfully = false;
                TaskResult.Exception = exception;
            }

            return TaskResult;
        }

        public override TaskResult Update(SystemSetting entity)
        {
            try
            {
                ValidateOnUpdate(entity);

                if (TaskResult.ExecutedSuccesfully)
                {
                    _systemSettingRepository.Update(entity, entity.Id);
                    _systemSettingRepository.CommitChanges();
                    TaskResult.AddMessage($"The SystemSetting {entity.Code} has been updated");
                }
            }
            catch (Exception exception)
            {
                TaskResult.ExecutedSuccesfully = false;
                TaskResult.Exception = exception;
            }

            return TaskResult;
        }

        public override TaskResult ValidateOnCreate(SystemSetting entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Code))
                TaskResult.AddErrorMessage("The SystemSetting code cannot be empty.");

            if (_systemSettingRepository.Get(x => !x.IsDeleted && x.Code.ToLower().Equals(entity.Code.ToLower())).Any())
                TaskResult.AddErrorMessage("A SystemSetting with this code already exists.");

            return TaskResult;
        }

        public override TaskResult ValidateOnDelete(SystemSetting entity)
        {
            if (entity == null)
                TaskResult.AddErrorMessage("This SystemSetting does not exists.");

            if (entity != null && entity.IsDeleted)
                TaskResult.AddErrorMessage("This SystemSetting is already deleted.");

            return TaskResult;
        }

        public override TaskResult ValidateOnUpdate(SystemSetting entity)
        {
            if (string.IsNullOrWhiteSpace(entity.Code))
                TaskResult.AddErrorMessage("The SystemSetting code cannot be empty.");

            if (_systemSettingRepository.Get(x => !x.IsDeleted && x.Id != entity.Id && x.Code.ToLower().Equals(entity.Code.ToLower())).Any())
                TaskResult.AddErrorMessage("A SystemSetting with this code already exists.");

            return TaskResult;
        }

        public SystemSetting GetById(int id)
        {
            return _systemSettingRepository.GetById(id);
        }
    }

    public interface ISystemSettingService : IBaseService<SystemSetting>
    {
        IEnumerable<SystemSetting> GetSystemSettings();
        SystemSetting GetById(int id);

    }
}
