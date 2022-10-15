using Newtonsoft.Json;
using PresentaionLayer.DTO_s;
using System.Net.Http;

namespace PresentaionLayer.Repository
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        private readonly string apiBaseUrl;

        public EmailSenderRepository(IConfiguration configuration)
        {
            //get the api base url from app settings
            apiBaseUrl = configuration.GetValue<string>("WebApiUrl");
        }
        public async Task<Message> GetMessage(int Id)
        {
            //send request to api to get message by id
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(apiBaseUrl + $"/GetMessage?Id={Id}");
            //check the response
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<Message>();
            }
            return null;
        }

        public async Task<IEnumerable<Message>> GetMessages()
        {
            //send request to api to get all messages
            using HttpClient client = new HttpClient();
            var response = await client.GetAsync(apiBaseUrl + "/GetMessages");
            //check the response
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<List<Message>>();
            }
            return null;
        }

        public async Task<Message> SaveMessage(string subject, string content)
        {
            //send request to api to post a message
            using HttpClient client = new HttpClient();
            Message message = new Message() 
            { 
                Subject = subject,
                MessageContent = content 
            };    
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(message), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiBaseUrl + "/SaveMessage", stringContent);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return await response.Content.ReadFromJsonAsync<Message>();
            }
            return null;
        }
        public async Task SendMail(int id,List<string> emails)
        {
            using HttpClient client = new HttpClient();
            StringContent stringContent = new StringContent(JsonConvert.SerializeObject(new {id = id,emails = emails}), System.Text.Encoding.UTF8, "application/json");
            var response = await client.PostAsync(apiBaseUrl + "/SendMessage",stringContent);
        }
    }
}
