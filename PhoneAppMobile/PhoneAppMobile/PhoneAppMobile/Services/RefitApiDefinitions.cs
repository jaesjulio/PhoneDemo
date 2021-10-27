using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using PhoneAppMobile.Models;
using PhoneAppMobile.Services;
using Refit;

namespace PhoneAppMobile.Mobile.Data
{
    public class GenericApiResonse
    {
        public bool ExecutedSuccesfully { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        public object Exception { get; set; }
        public int CreatedObjectId { get; set; }
    }


    public interface IMessageApi
    {
        [Post("/api/Message/SendMessage")]
        Task<GenericApiResonse> SendMessage([Body]Message message);

        [Get("/api/Message/GetMessages")]
        Task<List<Message>> GetMessages();

    }

    public interface IMessageInformationApi
    {
        [Post("/api/MessageInformation/SaveMessage")]
        Task<GenericApiResonse> SaveMessage(MessageInformation message);


    }
}
