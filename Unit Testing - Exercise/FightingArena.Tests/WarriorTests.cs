namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test_ConstructorSetsDataCorrectly()
        {
            string expectedName = "Joro";
            int expectedDamage = 50;
            int expectedHP = 100;

            Warrior warrior = new Warrior(expectedName, expectedDamage, expectedHP);

            string actualName = warrior.Name;
            int actualDamage = warrior.Damage;
            int actualHP = warrior.HP;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDamage, actualDamage);
            Assert.AreEqual(expectedHP, actualHP);
        }

        [Test]
        public void Test_NameValidationShouldThrowIfNull()
        {
            string name = null;
            int damage = 50;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Test_NameValidationShouldThrowWithEmptyName()
        {
            string name = string.Empty;
            int damage = 50;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Test_NameValidationShouldThrowWithWhitespaceName()
        {
            string name = "         ";
            int damage = 50;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Test_DamageValidationShouldThrowWithZeroDamage()
        {
            string name = "Joro";
            int damage = 0;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Test_DamageValidationShouldThrowWithNegativeDamage()
        {
            string name = "Joro";
            int damage = -1;
            int HP = 100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        public void Test_HPValidationShouldThrowWithNegativeHp()
        {
            string name = "Joro";
            int damage = 50;
            int HP = -100;

            Assert.Throws<ArgumentException>(() =>
            {
                Warrior warrior = new Warrior(name, damage, HP);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void Test_AttackerAttacksWithHPLowerThanOrEqual30ShouldThrowException(int attackerHP)
        {
            string attackerName = "Joro";
            int attackerDamage = 10;

            string defenderName = "Pesho";
            int defenderDamage = 10;
            int defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        [TestCase(25)]
        [TestCase(30)]
        public void Test_DefenderDefendsWithHPLowerThanOrEqual30ShouldThrowException(int defenderHP)
        {
            string attackerName = "Joro";
            int attackerDamage = 10;
            int attackerHP = 50;

            string defenderName = "Pesho";
            int defenderDamage = 10;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void Test_WeakerAttackerAttacksStrongerDefenderShouldThrowException()
        {
            string attackerName = "Joro";
            int attackerDamage = 10;
            int attackerHP = 40;

            string defenderName = "Pesho";
            int defenderDamage = 80;
            int defenderHP = 40;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            Assert.Throws<InvalidOperationException>(() =>
            {
                attacker.Attack(defender);
            });
        }

        [Test]
        public void Test_AttackerDefenderHPShouldBeDecreasedBySuccessfulAttack()
        {
            string attackerName = "Joro";
            int attackerDamage = 10;
            int attackerHP = 50;

            string defenderName = "Pesho";
            int defenderDamage = 10;
            int defenderHP = 50;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            int expectedAttackerHP = attackerHP - defenderDamage;
            int expectedDefenderHP = defenderHP - attackerDamage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }

        [Test]
        public void Test_StrongerAttackerShouldKillWeakerDefender()
        {
            string attackerName = "Joro";
            int attackerDamage = 60;
            int attackerHP = 50;

            string defenderName = "Pesho";
            int defenderDamage = 10;
            int defenderHP = 50;

            Warrior attacker = new Warrior(attackerName, attackerDamage, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDamage, defenderHP);

            int expectedDefenderHP = 0;
            int expectedAttackerHP = attacker.HP - defender.Damage;

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}