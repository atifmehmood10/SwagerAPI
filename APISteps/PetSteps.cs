using System.Collections.Generic;
using System.Net;
using SwaggerAPITesting.Helper;
using SwaggerAPITesting.Models;
namespace SwaggerAPITesting.APISteps{

    public class PetSteps{

        public PetModel FindPetById(long petId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<PetModel>();
            var url = rawRequest.SetUrl(APIUrls.FindPetById);
            var request = rawRequest.PrepareGETRequest();
            request.AddUrlSegment("petId", petId);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);

            return rawRequest.GetResponseContent<PetModel>(response);
        }

        public PetModel AddNewPetToStore(PetModel body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<PetModel>();
            var url = rawRequest.SetUrl(APIUrls.AddNewPetToStore);
            var jsonBody = JsonHelper.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);

            return rawRequest.GetResponseContent<PetModel>(response);
        }

        public PetModel UpdateAnExistingPet(PetModel body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<PetModel>();
            var url = rawRequest.SetUrl(APIUrls.AddNewPetToStore);
            var jsonBody = JsonHelper.Serialize(body);
            var request = rawRequest.PreparePUTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);
        

            return rawRequest.GetResponseContent<PetModel>(response);
        }

        public string DeleteAPet(long petId, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<PetModel>();
            var url = rawRequest.SetUrl(APIUrls.FindPetById);
            var request = rawRequest.PrepareDELETERequest();
            request.AddUrlSegment("petId", petId);
            var response = rawRequest.GetResponse(url, request);

            return response.Content;
        }

        public List<PetModel> FindPetByStatus(PetStatus petStatus, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<PetModel>();
            var url = rawRequest.SetUrl(APIUrls.FindPetByStatus);
            var request = rawRequest.PrepareGETRequest();
            request.AddQueryParameter("status", petStatus.ToString());
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);

            return rawRequest.GetResponseContent<List<PetModel>>(response);
        }

        public List<PetModel> FindPetByTags(string petTags, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<PetModel>();
            var url = rawRequest.SetUrl(APIUrls.FindPetByTags);
            var request = rawRequest.PrepareGETRequest();
            request.AddQueryParameter("tags", petTags.ToString());
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);

            return rawRequest.GetResponseContent<List<PetModel>>(response);
        }

        public PetModel UploadAnImageToAPet(long petId, byte[] file, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            // Unable to upload image as we can't get pet via id on mock API
            var rawRequest = new PetStoreHelper<PetModel>();
            var url = rawRequest.SetUrl(APIUrls.UploadAnImageToAPet);
            var request = rawRequest.PreparePOSTRequest(file);
            request.AddHeader("Content-Type", "application/octet-stream");
            request.AddUrlSegment("petId", petId);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);

            return rawRequest.GetResponseContent<PetModel>(response);
        }
    }
}
