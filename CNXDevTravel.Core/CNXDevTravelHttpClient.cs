using CNXDevTravel.Model.ResponseModel;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CNXDevTravel.Core
{
    public class CNXDevTravelHttpClient
    {
        private HttpClient _httpClient;
        public CNXDevTravelHttpClient(IHttpContextAccessor HttpContextAccessor)
        {
            _httpClient = new HttpClient();
            try
            {
                var token = HttpContextAccessor.HttpContext.User.Claims.FirstOrDefault(m => m.Type == "Token")?.Value;
                if (!string.IsNullOrWhiteSpace(token))
                {
                    _httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {token}");
                }
            }
            catch
            {

            }
        }
        public async Task<ResponseModel<T>> Request<T>(HttpMethod httpMethod, string endPoint,  object requestBody = null)
        {            
            var requestMessage = new HttpRequestMessage(httpMethod, endPoint);
            if (requestBody != null)
            {
                var json = System.Text.Json.JsonSerializer.Serialize(requestBody);
                var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
                requestMessage.Content = httpContent;
            }
            var response = await _httpClient.SendAsync(requestMessage);
            var responseString = await response.Content.ReadAsStringAsync();
            var responseModel = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseModel<T>>(responseString);
            return responseModel;
        }
    }
}
