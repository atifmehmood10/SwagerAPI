namespace SwaggerAPITesting.Helper{

    public class APIUrls{

        // Store Endpoints
        internal const string PlaceOrderForAPet = @"store/order";
        internal const string GetPetInventoryByStatus = @"store/inventory";
        internal const string PurchaseOrderById = @"store/order/{orderId}";

        // User Endpoints
        internal const string CreateUser = @"user";
        internal const string LogInUser = @"user/login";
        internal const string LogOutUser = @"user/logout";
        internal const string GetUserByUsername = @"user/{username}";

        // Pet Endpoints
        internal const string AddNewPetToStore = @"pet";
        internal const string FindPetById = @"pet/{petId}";
        internal const string FindPetByStatus = @"pet/findByStatus";
        internal const string FindPetByTags = @"pet/findByTags";
        internal const string UploadAnImageToAPet = @"pet/{petId}/uploadImage";
    }
}
