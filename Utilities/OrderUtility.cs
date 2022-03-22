using SwaggerAPITesting.APISteps;
using SwaggerAPITesting.Models;

namespace SwaggerAPITesting.Utilities{

    public class OrderUtility : OrderSteps{

        public OrderModel InitializeOrder(long petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete){

            return new OrderModel(){

                Id = int.Parse(RandomDataGenerator.GenerateId()),
                PetId = petId,
                Quantity = quantity,
                ShipDate = shipDate,
                Status = orderStatus.ToString(),
                Complete = complete
            };
        }

        public OrderModel CreateOrder(long petId, string shipDate, OrderStatus orderStatus, int quantity, bool complete, OrderModel order = null){

            var orderToCreate = order;
            if (orderToCreate == null) orderToCreate = InitializeOrder(petId, shipDate, orderStatus, quantity, complete);
            return PlaceAnOrderForAPet(orderToCreate);
        }
    }
}
