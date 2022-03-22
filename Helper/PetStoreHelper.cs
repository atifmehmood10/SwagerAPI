using System.IO;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators;

namespace SwaggerAPITesting.Helper{

    public class PetStoreHelper<Model>{

        public RestClient restClient;
        public RestRequest restRequest;

        // Base API URL
        public string baseUrl = "https://petstore.swagger.io/v2/";

        public RestClient SetUrl(string endpoint){

            var url = Path.Combine(baseUrl, endpoint);
            var restClient = new RestClient(url);
            return restClient;
        }

        public RestRequest PrepareGETRequest(){

            var restRequest = new RestRequest(Method.GET);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        //Post request having dynamic request body: Will be resolved at runtime
        public RestRequest PreparePOSTRequest(dynamic requestBody){

            var restRequest = new RestRequest(Method.POST);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest PreparePUTRequest(string requestBody){

            var restRequest = new RestRequest(Method.PUT);
            restRequest.AddHeader("Accept", "application/json");
            restRequest.AddParameter("application/json", requestBody, ParameterType.RequestBody);
            return restRequest;
        }

        public RestRequest PrepareDELETERequest(){

            var restRequest = new RestRequest(Method.DELETE);
            restRequest.AddHeader("Accept", "application/json");
            return restRequest;
        }

        public IRestResponse GetResponse(RestClient client, RestRequest request){

            return client.Execute(request);
        }

        public Entities GetResponseContent<Entities>(IRestResponse response){

            var content = response.Content;
            Entities entitiesObject = JsonConvert.DeserializeObject<Entities>(content);
            return entitiesObject;
        }

        public RestClient AuthenticateUser(string endpoint, string userName, string password)
        {
            var url = Path.Combine(baseUrl, endpoint);
            var restClient = new RestClient(url);
            restClient.Authenticator = new HttpBasicAuthenticator(userName, password);
            return restClient;
        }
    }
}
