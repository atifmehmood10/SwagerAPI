using SwaggerAPITesting.Models;
using SwaggerAPITesting.APISteps;

namespace SwaggerAPITesting.Utilities{

    public class PetUtility : PetSteps{

        public PetModel InitializePet(string name, PetStatus petStatus){

            return new PetModel(){

                Id = int.Parse(RandomDataGenerator.GenerateId()),
                Name = name,
                Status = petStatus.ToString(),
                Category = new CategoryModel()
                {
                    ID = int.Parse(RandomDataGenerator.GenerateId()),
                    Name = RandomDataGenerator.GenerateString()
                }
            };
        }

        public PetModel CreatePet(string name, PetStatus petStatus, PetModel pet = null){

            var petToCreate = pet;
            if (petToCreate == null) petToCreate = InitializePet(name, petStatus);
            return AddNewPetToStore(petToCreate);
        }
    }
}
