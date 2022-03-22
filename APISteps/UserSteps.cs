using System;
using System.Net;
using RestSharp;
using SwaggerAPITesting.Helper;
using SwaggerAPITesting.Models;

namespace SwaggerAPITesting.APISteps{

    public class UserSteps{

        public UserModel CreateUser(UserModel body, string userName, string password, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.AuthenticateUser(APIUrls.CreateUser, userName, password);
            var jsonBody = JsonHelper.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);

            return rawRequest.GetResponseContent<UserModel>(response);
        }

        // Create User using authenticator
        public UserModel CreateUser(UserModel body, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.AuthenticateUser(APIUrls.CreateUser, body.UserName, body.Password);
            var jsonBody = JsonHelper.Serialize(body);
            var request = rawRequest.PreparePOSTRequest(jsonBody);
            var response = rawRequest.GetResponse(url, request);

            return rawRequest.GetResponseContent<UserModel>(response);
        }



        public IRestResponse LogIn(string userName, string password, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.SetUrl(APIUrls.LogInUser);
            var request = rawRequest.PrepareGETRequest();
            request.AddQueryParameter("username", userName);
            request.AddQueryParameter("password", password);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);

            return response;
        }

        public IRestResponse LogOut(HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.SetUrl(APIUrls.LogOutUser);
            var request = rawRequest.PrepareGETRequest();
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);
            // Return complete response
            return response;
        }

        public UserModel GetUserByUsername(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.SetUrl(APIUrls.GetUserByUsername);
            var request = rawRequest.PrepareGETRequest();
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);
            // Return UserModel
            return rawRequest.GetResponseContent<UserModel>(response);
        }

        public IRestResponse GetUserResponseByUsername(string userName){

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.SetUrl(APIUrls.GetUserByUsername);
            var request = rawRequest.PrepareGETRequest();
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            // Return Complete response
            return response;
        }


        public UserModel UpdateUser(UserModel body, string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.SetUrl(APIUrls.GetUserByUsername);
            var jsonBody = JsonHelper.Serialize(body);
            var request = rawRequest.PreparePUTRequest(jsonBody);
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);
            // Return 
            return rawRequest.GetResponseContent<UserModel>(response);
        }

        public IRestResponse DeleteUser(string userName, HttpStatusCode expectedStatusCode = HttpStatusCode.OK){

            var rawRequest = new PetStoreHelper<UserModel>();
            var url = rawRequest.SetUrl(APIUrls.GetUserByUsername);
            var request = rawRequest.PrepareDELETERequest();
            request.AddUrlSegment("username", userName);
            var response = rawRequest.GetResponse(url, request);
            response.StatusCode.Equals(expectedStatusCode);
            // Return Complete Response
            return response;
        }

    }




}
