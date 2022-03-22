using System.Net;
using RestSharp;
using SwaggerAPITesting.Helper;
using SwaggerAPITesting.Models;

namespace SwaggerAPITesting.APISteps{

    public class OrderSteps{

        public OrderModel PlaceAnOrderForAPet(OrderModel body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<OrderModel>();
            var url = rawRequest.SetUrl(APIUrls.PlaceOrderForAPet);
            var jsonBody = JsonHelper.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);

            return rawRequest.GetResponseContent<OrderModel>(response);
        }

        public IRestResponse PetInventoryByStatus(HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<PetStatus>();
            var url = rawRequest.SetUrl(APIUrls.GetPetInventoryByStatus);
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);

            return response;
        }

        public IRestResponse FindPurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<OrderModel>();
            var url = rawRequest.SetUrl(APIUrls.PurchaseOrderById);
            var request = rawRequest.PrepareGETRequest();
            request.AddUrlSegment("orderId", orderId);
            var response = rawRequest.GetResponse(url, request);

            return response;
        }

        public IRestResponse DeletePurchaseOrderById(int orderId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<OrderModel>();
            var url = rawRequest.SetUrl(APIUrls.PurchaseOrderById);
            var request = rawRequest.PrepareDELETERequest();
            request.AddUrlSegment("orderId", orderId);
            var response = rawRequest.GetResponse(url, request);

            return response;
        }

        
    }
}
