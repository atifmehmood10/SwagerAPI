using System;
using System.Net;
using NUnit.Framework;
using SwaggerAPITesting.Models;
using BaseTest;

namespace SwaggerAPITesting.Tests{

    // 
    [TestFixture]
    public class OrderTests : TestBase
    {
        [Test]
        [TestCase(PetStatus.available)]
        [TestCase(PetStatus.pending)]
        [TestCase(PetStatus.sold)]
        public void VerifyPetInventoryOrderStatus(PetStatus petStatus) {
            try
            {
                var pet = petHelper.CreatePet("Cocoa", PetStatus.available);

                var response = orderHelper.PetInventoryByStatus();
                // Verifying available pets
                Assert.That(response.Content.Contains(petStatus.ToString()));

            }
            catch (NullReferenceException)
            {
                Assert.Fail("Test Exception occurred!!!");

            }
        }

        [Test]
        public void VerifyCreateOrder() {

            try
            {
                var pet = petHelper.CreatePet("Cocoa", PetStatus.available);

                var orderCreated = orderHelper.CreateOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.delivered, 1, true);
                // Verifying the order is placed

                Assert.That(orderCreated.Complete.Equals(true));

                // After placing the order the status should be placed initially
                Assert.That(orderCreated.Status.Equals(OrderStatus.placed));
            }
            catch (NullReferenceException) {
                Assert.Fail("Test Exception occurred!!!");
            }

        }

        [Test]
        public void OrderCRUDTest(){
            try
            {
                //Log.Information("Verify Order can be created/Updated/Deleted");
                var pet = petHelper.CreatePet("Jelly", PetStatus.available);
                var orderCreated = orderHelper.CreateOrder(pet.Id, DateTime.Now.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fff+00:00"), OrderStatus.placed, 1, true);

                Assert.That(orderCreated.Complete.Equals(true));

                var order = orderHelper.FindPurchaseOrderById(orderCreated.Id);
                //order.Id.Should().Be(orderCreated.Id);
                Assert.That(order.Content.Contains(orderCreated.Id.ToString()));

                var deleteOrder = orderHelper.DeletePurchaseOrderById(orderCreated.Id, HttpStatusCode.OK);
                Assert.That(deleteOrder.Content.Contains("200"));

                // If we get the deleted order it should return not found
                var getDeletedOrder = orderHelper.FindPurchaseOrderById(orderCreated.Id);
                Assert.That(getDeletedOrder.StatusCode.Equals(HttpStatusCode.NotFound));
            }
            catch (NullReferenceException) {
                Assert.Fail("Test Exception occurred!!!");
            }
        }
    }
}
