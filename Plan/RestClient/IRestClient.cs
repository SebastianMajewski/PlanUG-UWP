namespace Plan.RestClient
{
    using System.Threading.Tasks;

    public interface IRestClient
    {
        Task<string> GetRequest(string uri);

        Task<string> PostRequest(string uri, object obj);
    }
}