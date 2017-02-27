namespace Plan.RestClient
{
    using System;
    using System.Net.Http;
    using System.Runtime.InteropServices.WindowsRuntime;
    using System.ServiceModel;
    using System.Text;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using HttpClient = Windows.Web.Http.HttpClient;

    public class RestClient : IRestClient
    {
        public async Task<string> GetRequest(string uri)
        {
            try
            {
                using (var http = new HttpClient())
                {
                    var request = await http.GetBufferAsync(new Uri(uri));
                    return Encoding.UTF8.GetString(request.ToArray());
                }
            }
            catch (Exception)
            {
                throw new CommunicationException("Nie udało się połączyć z serwerem.");
            }
        }

        public async Task<string> PostRequest(string uri, object obj)
        {
            try
            {
                var requestUri = new Uri(uri);
                var json = JsonConvert.SerializeObject(obj);
                using (var client = new System.Net.Http.HttpClient())
                {
                    var response = client.PostAsync(requestUri, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                throw new CommunicationException("Nie udało się połączyć z serwerem.");
            }          
        }
    }
}
