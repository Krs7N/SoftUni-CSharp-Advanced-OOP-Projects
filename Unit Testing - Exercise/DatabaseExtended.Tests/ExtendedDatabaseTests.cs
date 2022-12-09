using System;
using ExtendedDatabase;

namespace DatabaseExtended.Tests
{
    using NUnit.Framework;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        private Database defDb;
        private Person person;

        [SetUp]
        public void SetUp()
        {
            this.defDb = new Database();
            this.person = new Person(123, "Pesho");
        }

        [Test]
        public void Test_PersonConstructorShouldSetDataCorrectly()
        {
            Person human = new Person(123, "Pesho");

            Assert.AreEqual(person.Id, human.Id);
            Assert.AreEqual(person.UserName, human.UserName);
        }

        [Test]
        public void Test_AddShouldIncreaseDatabaseCount()
        {
            Database db = new Database();
            defDb.Add(person);

            Assert.AreEqual(0, db.Count);
            Assert.AreEqual(1, defDb.Count);
        }

        [Test]
        public void Test_AddShouldThrowWhenCapacityIsFull()
        {
            Person[] people = new Person[]
            {
                new Person(1, "Joro"),
                new Person(2, "Mitko"),
                new Person(3, "a"),
                new Person(4, "oro"),
                new Person(5, "b"),
                new Person(6, "dsad"),
                new Person(7, "wert"),
                new Person(8, "qw"),
                new Person(9, "erw"),
                new Person(10, "ytyt"),
                new Person(11, "bgbg"),
                new Person(12, "bgbgbgb"),
                new Person(13, "bggbbggbgb"),
                new Person(14, "bggbbggbgbbg"),
                new Person(15, "dasdasdasdasdas"),
                new Person(16, "dasldfssojkg")
            };

            defDb = new Database(people);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Add(new Person(17, "Jeko"));
            }, "Array's capacity must be exactly 16 integers!");
        }

        [Test]
        public void Test_AddShouldThrowWhenThereIsPersonWithSameName()
        {
            defDb.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Add(new Person(345, "Pesho"));
            }, "There is already user with this username!");
        }

        [Test]
        public void Test_AddShouldThrowWhenThereIsPersonWithSameId()
        {
            defDb.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Add(new Person(123, "Jichko"));
            }, "There is already user with this Id!");
        }

        [Test]
        public void Test_RemoveShouldDecreaseCount()
        {
            defDb.Add(person);
            defDb.Add(new Person(123123, "Gosho"));

            defDb.Remove();

            Assert.AreEqual(1, defDb.Count);
        }

        [Test]
        public void Test_RemoveShouldThrowWhenDbIsEmpty()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.Remove();
            });
        }

        [Test]
        public void Test_FindByUsernameShouldReturnPerson()
        {
            defDb.Add(person);
            Assert.AreEqual(person, defDb.FindByUsername("Pesho"));
        }

        [Test]
        public void Test_FindByUsernameShouldThrowWhenPersonIsNotExisting()
        {
            defDb.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.FindByUsername("Georgi");
            });
        }

        [Test]
        public void Test_FindByUsernameShouldThrowWhenPersonIsNullOrEmpty()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                defDb.FindByUsername(null);
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                defDb.FindByUsername("");
            });
        }

        [Test]
        public void Test_FindByIdShouldReturnPerson()
        {
            defDb.Add(person);
            Assert.AreEqual(person, defDb.FindById(123));
        }

        [Test]
        public void Test_FindByIdShouldThrowWhenPersonIsNotExisting()
        {
            defDb.Add(person);

            Assert.Throws<InvalidOperationException>(() =>
            {
                defDb.FindById(312);
            });
        }

        [Test]
        public void Test_FindByIdShouldThrowWhenIdIsNegative()
        {
            defDb.Add(person);

            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                defDb.FindById(-32);
            });
        }
    }
}