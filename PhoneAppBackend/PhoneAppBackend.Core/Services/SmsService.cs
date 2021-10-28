using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PhoneAppBackend.Core.Framework;
using PhoneAppBackend.Core.Models.Constants;
using PhoneAppBackend.Core.Services;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Rest.Lookups.V1;
using Twilio.Types;

namespace PhoneAppBackend.Core.Services
{
    public class SmsService : ISmsService
    {
        private readonly ISystemSettingService _systemSettingService;

        public SmsService(ISystemSettingService systemSettingService)
        {
            _systemSettingService = systemSettingService;
        }

        public TaskResult SendSms(string Phonenumber, string Message)
        {
            var res = new TaskResult();
            try
            {
                var TwilioSid = _systemSettingService.GetById(SystemSettingConstants.TwilioSIDKey);
                var TwilioToken = _systemSettingService.GetById(SystemSettingConstants.TwilioSecretKey);
                var TwilioPhoneNumber = _systemSettingService.GetById(SystemSettingConstants.TwilioPhoneNumberKey);

                string accountSid = TwilioSid != null ? TwilioSid.Value : "";

                string authToken = TwilioToken != null ? TwilioToken.Value : "";

                string messageSid = TwilioPhoneNumber != null ? TwilioPhoneNumber.Value : "";

                TwilioClient.Init(accountSid, authToken);

                var type = new List<string> {
                 "carrier"
                };

                var messageOptions = new CreateMessageOptions(
                    new PhoneNumber(Phonenumber));
                messageOptions.MessagingServiceSid = messageSid;
                messageOptions.Body = Message;

                var message = MessageResource.Create(messageOptions);
                Console.WriteLine(message.Body);
                res.ExecutedSuccesfully = true;
                res.AddMessage(message.Status.ToString());
                res.AddMessage(message.DateCreated.ToString());
                res.AddMessage(message.Body);

            }
            catch (Exception exception)
            {
                res.ExecutedSuccesfully = false;
                res.Exception = exception;
                res.AddMessage($"An error has ocurred sending the Sms");
            }
                return res;
        }
    }

    public interface ISmsService
    {
        TaskResult SendSms(string Phonenumber, string Message);
    }
}
