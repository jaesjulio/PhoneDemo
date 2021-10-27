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
        HttpClient client;
        JsonSerializerOptions serializerOptions;
        public async Task<GenericApiResonse> SendMessage(Message _message)
        {
            var httpClientHandler = new HttpClientHandler();

           
                httpClientHandler.ServerCertificateCustomValidationCallback =
                    (message, certificate, chain, sslPolicyErrors) => true;
            

           var localApi = Refit.RestService.For<IMessageApi>(
                        new HttpClient(httpClientHandler)
                        {
                            BaseAddress = new Uri("https://10.0.2.2:44361")
                        });


            var messagesent = await localApi.SendMessage(_message);

            return messagesent;
        }

        public async Task<List<Message>> GetMessages()
        {
            var Items = new List<Message>();
            client = new HttpClient(new HttpClientHandler()
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
                {
                    //bypass
                    return true;
                },
            }
            , false);

            Uri uri = new Uri("https://10.0.2.2:44361/api/Message/GetMessages");
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Items = JsonSerializer.Deserialize<List<Message>>(content, serializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"\tERROR {0}", ex.Message);
            }

            var httpClientHandler = new HttpClientHandler();

            httpClientHandler.ServerCertificateCustomValidationCallback =
                (message, certificate, chain, sslPolicyErrors) => true;

            //var localApi = RestService.For<IMessageApi>(
            //           new HttpClient(httpClientHandler)
            //           {
            //               BaseAddress = new Uri("https://10.0.2.2:44361")
            //           });
            //var messages = await restService.GetMessages();

            return Items;
        }
    }

    public interface IMessageService
    {
        Task<GenericApiResonse> SendMessage(Message message);
        Task<List<Message>> GetMessages();
    }
}
