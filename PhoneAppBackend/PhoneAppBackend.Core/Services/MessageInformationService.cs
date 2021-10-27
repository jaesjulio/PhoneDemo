using PhoneAppBackend.Core.Framework;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneAppBackend.Core.Services
{
     public class MessageInformationService : BaseService<MessageInformation>, IMessageInformationService
    {
        private readonly IMessageInformationRepository _messageInformationRepository;

        public MessageInformationService(IMessageInformationRepository messageInformationRepository)
        {
            _messageInformationRepository = messageInformationRepository;
        }
        public override TaskResult Create(MessageInformation entity)
        {
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _messageInformationRepository.Insert(entity);
                    _messageInformationRepository.CommitChanges();
                    TaskResult.AddMessage("Message has been created");
                }
                catch (Exception exception)
                {
                    TaskResult.ExecutedSuccesfully = false;
                    TaskResult.Exception = exception;
                }
            }
            return TaskResult;
        }

        public override TaskResult Delete(int entityId)
        {
            var account = _messageInformationRepository.GetById(entityId);
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _messageInformationRepository.SoftDelete(entityId);
                    _messageInformationRepository.CommitChanges();
                    TaskResult.AddMessage($"Message has been deleted");
                }
                catch (Exception exception)
                {
                    TaskResult.ExecutedSuccesfully = false;
                    TaskResult.Exception = exception;
                }
            }
            return TaskResult;
        }

        public override TaskResult Update(MessageInformation entity)
        {
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _messageInformationRepository.Update(entity, entity.Id);
                    _messageInformationRepository.CommitChanges();

                    TaskResult.AddMessage("Message has been Updated");
                }
                catch (Exception exception)
                {
                    TaskResult.ExecutedSuccesfully = false;
                    TaskResult.Exception = exception;
                }
            }
            return TaskResult;
        }

        public override TaskResult ValidateOnCreate(MessageInformation entity)
        {
            throw new NotImplementedException();
        }

        public override TaskResult ValidateOnDelete(MessageInformation entity)
        {
            throw new NotImplementedException();
        }

        public override TaskResult ValidateOnUpdate(MessageInformation entity)
        {
            throw new NotImplementedException();
        }
    }

    public interface IMessageInformationService : IBaseService<MessageInformation>
    {
    }
}
