using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using SwaggerAPITesting.Models;
using BaseTest;

namespace SwaggerAPITesting.Tests{

    [TestFixture]
    public class PetTests : TestBase{

        [Test]
        public void PetsCRUDTest(){

            try
            {
                // The tests will be executed with the actual data. Mock api doesn't provides data
                // Pet not created on the backend which is why the test is failing
                var newPetAdded = petHelper.CreatePet("Cookie", PetStatus.available);
                var newPetData = petHelper.FindPetById(newPetAdded.Id);
                newPetAdded.Name = "My Sweet Cookie";
                var updatePetData = petHelper.UpdateAnExistingPet(newPetAdded);
                var updatePet = petHelper.FindPetById(newPetAdded.Id);

                // Verifying the pet is created with the given data
                Assert.That(newPetData.Name.Equals(updatePet.Name));

                var deletedPetMessage = petHelper.DeleteAPet(newPetAdded.Id);
                Assert.That(newPetData.Id.Equals(updatePet.Id));
            }
            catch (NullReferenceException) {
                Assert.Fail("Test Exception occurred!!!");
            }

        }

        [Test]
        [TestCase(PetStatus.available)]
        [TestCase(PetStatus.pending)]
        [TestCase(PetStatus.sold)]
        public void VerifyFindPetByStatus(PetStatus petStatus){

            try
            {
                // Requiring the data exists : General test to check pet status exists
                var statusResponse = petHelper.FindPetByStatus(petStatus);
                Assert.That(statusResponse.Count > 0);
                Assert.That(statusResponse[0].Status.Contains(petStatus.ToString()));
            }

            catch (NullReferenceException)
            {
                Assert.Fail("Test Exception occurred!!!");
            }
        }

        [Test]
        // We can add more test cases with different tags
        [TestCase("petStore")]
        public void VerifyFindPetByTags(string petTag){

            try { 
                var response = petHelper.FindPetByTags(petTag);
                Assert.That(response.Count > 0);
                // Verifying the pet is found with the given tag
                Assert.That(response[0].Tags.Equals(petTag));
            }
            catch (NullReferenceException)
            {
                Assert.Fail("Test Exception occurred!!!");
            }
        }

        [Test]
        public void VerifyUploadAnImageToAPet(){

            try {
                var newPet = petHelper.InitializePet("Cake", PetStatus.available);
                newPet.PhotoUrls = new List<string> { };
                petHelper.AddNewPetToStore(newPet);
                var file = File.ReadAllBytes("../../Resources/petsImage.jpg");
                var response = petHelper.UploadAnImageToAPet(newPet.Id, file);

                // Assertion can be made on the basis of the URL created
                Assert.That(response.PhotoUrls[0] != null);
            }
            catch (NullReferenceException) {
                Assert.Fail("Test Exception occurred!!!");
            }
            }
    }
}
