using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMangment;

namespace UserMangment_test
{
    public class UserTest
    {
        // ---------------------Boolean Assertions
        [Fact]
        public void Activate_InactiveUser_True()
        {
            // Arrange
            var user = new User { IsActive = false };

            // Act
            bool result = user.Activate();

            // Assert
            Assert.True(result);
        }

        ///----------------------- String Assertions
        [Fact]
        public void GetUserInfo_Format()
        {
            // Arrange
            var user = new User { Id = 1, Username = "Nesreen", Email = "nesreen@gmail.com" };
            string expected = "UserID: 1, Username: Nesreen, Email: nesreen@gmail.com";

            // Act
            string result = user.GetUserInfo();

            // Assert
            Assert.Equal(expected, result);
        }

        [Fact]
        public void GetUserInfo_StartsWithUserName_false()
        {
            // Arrange
            var user = new User { Id = 1, Username = "Nesreen", Email = "nesreen@gmail.com" };

            // Act
            string result = user.GetUserInfo();

            // Assert
            Assert.StartsWith("Username", result);
        }

        [Fact]
        public void GetUserInfo_EndsWithEmail_true()
        {
            // Arrange
            var user = new User { Id = 1, Username = "Nesreen", Email = "nesreen@gmail.com" };

            // Act
            string result = user.GetUserInfo();

            // Assert
            Assert.EndsWith("nesreen@gmail.com", result);
        }


        //---------------- Regex Assertions
        [Fact]
        public void ValidEmail_Matches_EmailRegex_true()
        {
            // Arrange
            string email = "nesreen@example.com";
            var regEx = @"\A[A-Z0-9+_.-]+@[A-Z0-9.-]+\Z";

            // Assert
            Assert.Matches(regEx, email);
        }

        public void InvalidEmail_DoesNotMatch_EmailRegex_true()
        {
            // Arrange
            string notAnEmail = "this is a text";
            var regEx = @"\A[A-Z0-9+_.-]+@[A-Z0-9.-]+\Z";

            // Assert
            Assert.DoesNotMatch(regEx, notAnEmail);
        }


        // -----------------Equality Assertions
        [Fact]
        public void UserAge_Equal_SettingAge_true()
        {
            // Arrange
            var user = new User();

            // Act
            user.Age = 25;

            // Assert
            Assert.Equal(25, user.Age);
        }

        //---------- Numeric Range Assertions
        [Fact]
        public void UserAge_ValidRange()
        {
            // Arrange
            var user = new User { Age = 30 };

            // Assert
            Assert.InRange(user.Age, 0, 60);
        }

        [Fact]
        public void UserAge_InValidRange()
        {
            // Arrange
            var user = new User { Age = -5 };

            // Assert
            Assert.InRange(user.Age, 0, 60);
        }

        //--------- Reference Assertions
        [Fact]
        public void NewUser_PermissionsList_NotBeNull()
        {
            // Arrange
            var user = new User();

            // Assert
            Assert.NotNull(user.Permissions);
        }


        [Fact]
        public void TwoUsers_DifferentPermissionLists_true()
        {
            // Arrange
            var user1 = new User();
            var user2 = new User();

            // Assert
            Assert.NotSame(user1.Permissions, user2.Permissions);
        }

        //----------------------- Type Assertions

        [Fact]
        public void UserObject_BeAssignableFromBase_true()
        {
            // Arrange
            object obj = new User();

            // Assert
            Assert.IsAssignableFrom<User>(obj);
        }

        //-------------------------- Collection Assertions
        [Fact]
        public void NewUser_PermissionsList_Empty_true()
        {
            // Arrange
            var user = new User();

            // Assert
            Assert.Empty(user.Permissions);
        }



        [Fact]
        public void AddPermission_ContainPermission_true()
        {
            // Arrange
            var user = new User();

            // Act
            user.AddPermission("read");

            // Assert
            Assert.Contains("read", user.Permissions);
        }


        // ------------------Exception Assertions
        [Fact]
        public void UpdateEmail_NullEmail_ThrowsArgumentNullException()
        {
            // Arrange
            var user = new User();

            // Assert 
            var exception = Assert.Throws<ArgumentNullException>(() => user.UpdateEmail(null));

        }



    }
}
