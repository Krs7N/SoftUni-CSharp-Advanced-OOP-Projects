using System;

namespace Database.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class DatabaseTests
    {
        [SetUp]
        public void SetUp()
        {

        }

        [TestCase(new int[] { })]
        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldSetDataCorrectly(int[] data)
        {
            Database db = new Database(data);

            Assert.AreEqual(data.Length, db.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void Test_ConstructorShouldThrowWhenIsFullCapacity(int[] data)
        {
            Database db = new Database(data);

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Add(1);
            }, "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public void Test_AddShouldBeIncreasingCount(int[] data)
        {
            Database db = new Database(data);

            Assert.AreEqual(data.Length, db.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4 })]
        public void Test_Add(int[] data)
        {
            Database db = new Database(data);

            db.Add(1);

            Assert.AreEqual(data.Length + 1, db.Count);
        }

        [TestCase(new int[] { })]
        public void Test_RemoveShouldThrowWhenDatabaseIsEmpty(int[] data)
        {
            Database db = new Database();

            Assert.Throws<InvalidOperationException>(() =>
            {
                db.Remove();
            }, "The collection is empty!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5 })]
        public void Test_RemoveShouldDecreaseCount(int[] data)
        {
            Database db = new Database(data);

            db.Remove();

            Assert.AreEqual(4, db.Count);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7 })]
        public void Test_FetchShouldCopyArray(int[] data)
        {
            Database db = new Database(data);

            int[] copyArr = (int[])data.Clone();

            int[] newArray = db.Fetch();

            CollectionAssert.AreEqual(copyArr, newArray);
        }
    }
}
