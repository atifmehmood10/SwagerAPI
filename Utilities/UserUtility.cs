using SwaggerAPITesting.APISteps;
using SwaggerAPITesting.Models;

namespace SwaggerAPITesting.Utilities{

    public class UserUtility : UserSteps{

        public UserModel InitializeUser(string firstName, string lastName, string userName){
            return new UserModel(){

                Id = int.Parse(RandomDataGenerator.GenerateId()),
                FirstName = firstName,
                LastName = lastName,
                UserName = userName,
                Email = RandomDataGenerator.GenerateEmail(),
                Password = RandomDataGenerator.GenerateString(),
                Phone = RandomDataGenerator.GeneratePhoneNumber(),
                UserStatus = 1
            };
        }


        // Create user with only FirstName, LastName and UserName
        public UserModel CreateUserModel(string firstName, string lastName, string userName, UserModel user = null){
            //var userToCreate = user;
            //if (userToCreate == null)
            //    userToCreate = InitializeUser(firstName, lastName, userName);
            //return CreateUser(userToCreate);

            return InitializeUser(firstName, lastName, userName);

        }

    }
}
