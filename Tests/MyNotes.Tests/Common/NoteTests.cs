﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotes.Domain;
using MyNotes.Domain.Base;
using MyNotes.Domain.Entities;
using Assert = Xunit.Assert;

namespace MyNotes.Tests.Common
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void NoteCreatingTest()
        {
            Note n = new Note();

            Assert.True(n is Note);
            Assert.True(n is Entity<int>);
            Assert.True(n is INote);
            Assert.True(n.Id is int);
        }
    }
}
