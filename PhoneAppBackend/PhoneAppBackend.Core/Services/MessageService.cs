using PhoneAppBackend.Core.Framework;
using PhoneAppBackend.Core.Models;
using PhoneAppBackend.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneAppBackend.Core.Services
{
    public class MessageService : BaseService<Message>, IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly ISmsService _smsService;
        private readonly IMessageInformationService _messageInformationService;

        public MessageService(IMessageRepository messageRepository, ISmsService smsService, IMessageInformationService messageInformationService)
        {
            _messageRepository = messageRepository;
            _smsService = smsService;
            _messageInformationService = messageInformationService;
        }
        public override TaskResult Create(Message entity)
        {
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _messageRepository.Insert(entity);
                    var a = _messageRepository.CommitChanges();
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
            var account = _messageRepository.GetById(entityId);
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _messageRepository.SoftDelete(entityId);
                    _messageRepository.CommitChanges();
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

        public override TaskResult Update(Message entity)
        {
            if (TaskResult.ExecutedSuccesfully)
            {
                try
                {
                    _messageRepository.Update(entity, entity.Id);
                    _messageRepository.CommitChanges();

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

        public override TaskResult ValidateOnCreate(Message entity)
        {
            throw new NotImplementedException();
        }

        public override TaskResult ValidateOnDelete(Message entity)
        {
            throw new NotImplementedException();
        }

        public override TaskResult ValidateOnUpdate(Message entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Message> GetMessages()
        {
            return _messageRepository.Get(x => !x.IsDeleted).ToList();
        }

        public TaskResult CreateandSend(Message message)
        {
            var created = Create(message);

            if (created.ExecutedSuccesfully) 
            {
                var sms = _smsService.SendSms(message.ToNumber.ToString(), message.TextMessage);

                var msginfo = new MessageInformation()
                {
                    SentDateTime = DateTime.Parse(sms.Messages[1]),
                    TwilioConfirmation = sms.Messages[0],
                    TwilioMessage = sms.Messages[2],
                    MessageId = _messageRepository.GetAllActive().Last().Id
                };

                _messageInformationService.Create(msginfo);

                return sms;
            }

            return created;
        }
    }

    public interface IMessageService : IBaseService<Message>
    {
        IEnumerable<Message> GetMessages();

        TaskResult CreateandSend(Message message);
    }
}
