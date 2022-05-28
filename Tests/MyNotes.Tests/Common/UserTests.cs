using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Domain;
using MyNotes.Domain.Base;
using MyNotes.Domain.Base.Enitities;
using MyNotes.Domain.Entities;
using Assert = Xunit.Assert;

namespace MyNotes.Tests.Common
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void UserCreatingTest()
        {
            User u = new User();

            Assert.True(u is User);
            Assert.True(u is Entity<int>);
            Assert.True(u is IEntity<int>);
            Assert.True(u is IUser);
            Assert.True(u.Id is int);
            Assert.True(u is NamedEntity<int>);
            Assert.True(u is INamedEntity<int>);
        }
    }
}
