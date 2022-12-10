using System;
using System.Collections.Generic;
using System.Numerics;
using NUnit.Framework;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private FootballTeam footballTeam;
        private FootballPlayer footballPlayer;

        [SetUp]
        public void Setup()
        {
            footballTeam = new FootballTeam("PSG", 30);
            footballPlayer = new FootballPlayer("Neymar", 11, "Forward");
        }

        [Test]
        public void Test_ConstructorSet()
        {
            Assert.AreEqual("Neymar", footballPlayer.Name);
            Assert.AreEqual(11, footballPlayer.PlayerNumber);
            Assert.AreEqual("Forward", footballPlayer.Position);
            Assert.AreEqual(0, footballPlayer.ScoredGoals);
        }

        [Test]
        public void Test_NameShouldSet()
        {
            footballPlayer = new FootballPlayer("Messi", 10, "Forward");

            Assert.AreEqual("Messi", footballPlayer.Name);
        }

        [Test]
        public void Test_EmptyNameThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                footballPlayer = new FootballPlayer(null, 10, "Forward");
            }, "Name cannot be null or empty!");

            Assert.Throws<ArgumentException>(() =>
            {
                footballPlayer = new FootballPlayer(string.Empty, 10, "Forward");
            }, "Name cannot be null or empty!");
        }

        [Test]
        public void Test_NumberShouldSET()
        {
            footballPlayer = new FootballPlayer("Messi", 10, "Forward");

            Assert.AreEqual(10, footballPlayer.PlayerNumber);
        }

        [Test]
        public void Test_NumberShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                footballPlayer = new FootballPlayer("Neymar", 22, "Forward");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                footballPlayer = new FootballPlayer("Neymar", 0, "Forward");
            });
        }

        [Test]
        public void Test_PositionShouldSET()
        {
            footballPlayer = new FootballPlayer("Messi", 10, "Forward");

            Assert.AreEqual("Forward", footballPlayer.Position);
        }

        [Test]
        public void Test_PositionShouldThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                footballPlayer = new FootballPlayer("Neymar", 11, "gotvach");
            });

            Assert.Throws<ArgumentException>(() =>
            {
                footballPlayer = new FootballPlayer("Neymar", 10, "tancior");
            });
        }

        [Test]
        public void Test_ScoreGoalsMethod()
        {
            int expectedCount = 2;

            footballPlayer.Score();
            footballPlayer.Score();

            Assert.AreEqual(expectedCount, footballPlayer.ScoredGoals);
        }

        [Test]
        public void Test_TeamConstructorShouldSet()
        {
            Assert.AreEqual("PSG", footballTeam.Name);
            Assert.AreEqual(30, footballTeam.Capacity);
            CollectionAssert.AreEqual(new List<FootballPlayer>(), footballTeam.Players);
        }

        [Test]
        public void Test_TeamNameShouldSet()
        {
            footballTeam = new FootballTeam("Real Madrid", 25);

            Assert.AreEqual("Real Madrid", footballTeam.Name);
            Assert.AreEqual(25, footballTeam.Capacity);
        }

        [Test]
        public void Test_TeamEmptyNameThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                footballTeam = new FootballTeam(null, 40);
            }, "Name cannot be null or empty!");

            Assert.Throws<ArgumentException>(() =>
            {
                footballTeam = new FootballTeam(string.Empty, 40);
            }, "Name cannot be null or empty!");
        }

        [Test]
        public void Test_TeamCapacityShouldSet()
        {
            Assert.AreEqual(30, footballTeam.Capacity);
        }

        [Test]
        public void Test_TeamCapacityThrow()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                footballTeam = new FootballTeam("Barcelona", 0);
            }, "Capacity min value = 15");

            Assert.Throws<ArgumentException>(() =>
            {
                footballTeam = new FootballTeam("Barcelona", 10);
            }, "Capacity min value = 15");
        }

        [Test]
        public void Test_AddPlayerShouldAdd()
        {
            footballPlayer = new FootballPlayer("Marquinhos", 3, "Midfielder");

            footballTeam.AddNewPlayer(footballPlayer);

            Assert.AreEqual(1, footballTeam.Players.Count);
        }

        [Test]
        public void Test_AddPlayerShouldMessage()
        {
            footballPlayer = new FootballPlayer("Marquinhos", 3, "Midfielder");

            Assert.AreEqual($"Added player {footballPlayer.Name} in position {footballPlayer.Position} with number {footballPlayer.PlayerNumber}", footballTeam.AddNewPlayer(footballPlayer));
        }

        [Test]
        public void Test_AddPlayer()
        {
            footballTeam = new FootballTeam("CSKA", 15);
            footballPlayer = new FootballPlayer("Marquinhos", 15, "Midfielder");

            footballTeam.AddNewPlayer(footballPlayer);
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 1, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 2, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 3, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 4, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 5, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 6, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 7, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 8, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 9, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 10, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 11, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 12, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 13, "Goalkeeper"));
            footballTeam.AddNewPlayer(new FootballPlayer("Jeremy", 14, "Goalkeeper"));

            Assert.AreEqual("No more positions available!", footballTeam.AddNewPlayer(new FootballPlayer("Bojinov", 20, "Forward")));
        }

        [Test]
        public void Test_PickPlayer()
        {
            footballTeam.AddNewPlayer(footballPlayer);

            Assert.AreEqual(footballPlayer, footballTeam.PickPlayer("Neymar"));
        }

        [Test]
        public void Test_PickPlayerNotExist()
        {
            Assert.AreEqual(null, footballTeam.PickPlayer("Neymar"));
        }

        [Test]
        public void Test_PlayerScore()
        {
            footballTeam.AddNewPlayer(footballPlayer);

            Assert.AreEqual($"{footballPlayer.Name} scored and now has {footballPlayer.ScoredGoals + 1} for this season!", footballTeam.PlayerScore(11));
        }

        [Test]
        public void Test_PlayerScoreGoalIncrease()
        {
            footballTeam.AddNewPlayer(footballPlayer);

            footballTeam.PlayerScore(11);

            Assert.AreEqual(1, footballPlayer.ScoredGoals);
        }
    }
}