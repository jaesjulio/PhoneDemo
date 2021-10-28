using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PhoneAppMobile.Mobile.Data;
using PhoneAppMobile.Models;
using Refit;

namespace PhoneAppMobile.Services
{
    public class MessageService : IMessageService
    {
    
        public async Task<GenericApiResonse> SendMessage(Message _message)
        {
             var httpClientHandler = new HttpClientHandler();


                 httpClientHandler.ServerCertificateCustomValidationCallback =
                     (message, certificate, chain, sslPolicyErrors) => true;


            var localApi = RestService.For<IMessageApi>(
                        new HttpClient(httpClientHandler)
                         {
                             BaseAddress = new Uri("https://10.0.2.2:44361")
                         });
          
            var messagesent = await localApi.SendMessage(_message);

            return messagesent;
        }

        public async Task<List<Message>> GetMessages()
        {
            
            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;

            var localApi = Refit.RestService.For<IMessageApi>(
                       new HttpClient(httpClientHandler)
                       {
                           BaseAddress = new Uri("https://10.0.2.2:44361")
                       });
            var messages = await localApi.GetMessages();

            return messages;
        }
    }

    public interface IMessageService
    {
        Task<GenericApiResonse> SendMessage(Message message);
        Task<List<Message>> GetMessages();
    }
}
