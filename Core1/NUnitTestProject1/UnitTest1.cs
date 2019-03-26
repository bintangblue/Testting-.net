using NUnit.Framework;
using WebApplication1.Controllers;
using WebApplication1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Collections.ObjectModel;
namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var user = new User { Id = "1", Name = "User 1", Password = "rahasia1" };
            string test = user.ToString();
            //Assert.Pass();
        }

        [Test]
        public void Test_ValuesController_Get()
        {
            var control = new ValuesController();
            User user =new User { Id="!", Name = "User 1", Password = "rahasia1" };
            Collection<ValidationResult> results = new Collection<ValidationResult>();
            //Validator.TryValidateObject(user, new ValidationContext(user), results);
            Validator.TryValidateObject(user, new ValidationContext(user),results,true);
            //var result = control.GetUser(user);
            //var value = result.Value;
            //Assert.AreEqual(2, value.Count());
        }
    }
}