using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Tests;

namespace UnitTest1
{
    [TestClass]
    public class UnitTestUser
    {
        public List<User> users;
        public User koresh;

        [TestInitialize]
        public void Init()
        {
            Random random = new Random();
            users = new List<User>();
            int countOfUsers = random.Next(4,10);
            for (int i = 0; i < countOfUsers; i++)
                users.Add(new User($"user{i}", DateTime.Now.Millisecond.ToString() + $"{i}", i % 2 == 0));

            if (DateTime.Now.Second > 40 && DateTime.Now.Second < 60)
            {
                users[random.Next(0, users.Count)] = null;
            }
            if (DateTime.Now.Second > 20 && DateTime.Now.Second < 40)
            {
                int amongus = random.Next(0, users.Count + 1);
                users[amongus].id = users[random.Next(0, users.Count)].id;
            }
            if (DateTime.Now.Second < 20)
            {
                koresh = users[random.Next(0, users.Count)];
            }
            StringBuilder stringBuilder = new StringBuilder("Список пользователей:\n");
            foreach (User user in users)
                if (user != null)
                    stringBuilder.Append($"{user.id} {user.login} {user.password}\n");
                else
                    stringBuilder.Append("user is null\n");

            Debug.WriteLine(stringBuilder.ToString());
        }

        [TestMethod]
        public void TestOriginality ()
        {
            CollectionAssert.AllItemsAreUnique(users);
        }

        [TestMethod]
        public void TestUsersIsNotNull()
        {
            CollectionAssert.AllItemsAreNotNull(users);
        }
        
        [TestMethod]
        public void TestUserIsNull()
        {
            CollectionAssert.Contains(users, null);
        }

        [TestMethod]
        public void TestFindSpecificUser()
        {
            CollectionAssert.Contains(users, koresh);
        } 
    }
}
