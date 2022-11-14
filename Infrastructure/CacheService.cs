using _2ndProblemApp.Contracts;
using _2ndProblemApp.Object;

namespace Infrastructure
{
    public class MockyService : IMockyService
    {
        private static MockyResponse _mockyResponse;

        public async Task<MockyResponse> GetMockyResponseAsync()
        {
            if (_mockyResponse != null)
                return _mockyResponse;

            HttpClient http = new();

            var response = await http.SendAsync(new() { RequestUri = new Uri("https://run.mocky.io/v3/8cc1b858-2e3e-4249-a025-c0c52053d618") });

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error fetching data");
            }

            _mockyResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<MockyResponse>(await response.Content.ReadAsStringAsync());

            if (_mockyResponse == null)
            {
                throw new Exception("GetMockyResponseAsync: Invalid response object");
            }

            return _mockyResponse;
        }
    }
}