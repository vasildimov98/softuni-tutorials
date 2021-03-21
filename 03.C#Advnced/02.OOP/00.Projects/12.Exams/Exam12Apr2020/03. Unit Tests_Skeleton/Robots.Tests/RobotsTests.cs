namespace Robots.Tests
{
    using NUnit.Framework;

    public class RobotsTests
    {
        //Arrange
        private const string ROBOT_NAME = "Test1";
        private const int ROBOT_BATTERY = 100;
        private const int ROBOT_MANAGER_CAPACITY = 10;

        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            this.robot = new Robot(ROBOT_NAME, ROBOT_BATTERY);
            this.robotManager = new RobotManager(ROBOT_MANAGER_CAPACITY);
        }

        [Test]
        public void RobotConstructorShouldSetCorrectValues()
        {
            //Assert
            Assert.That(this.robot, Is.Not.Null);
            Assert.That(this.robot.Name, Is.EqualTo(ROBOT_NAME));
            Assert.That(this.robot.Battery, Is.EqualTo(ROBOT_BATTERY));
            Assert.That(this.robot.MaximumBattery, Is.EqualTo(ROBOT_BATTERY));
        }

        [Test]
        public void CapacityPropertyShouldThrowExceptionIfValueIsLessThanZero()
        {
            //Arrange
            var wrongCapacity = -ROBOT_MANAGER_CAPACITY;

            //Act & Assert
            Assert.That(() => new RobotManager(wrongCapacity),
                Throws.ArgumentException
                .With.Message.EqualTo("Invalid capacity!"));
        }

        [Test]
        public void RobotManagerConstructorShouldSetCorrectValues()
        {
            //Arrange
            var expectedCount = 0;
            var expectedCapacity = 0;
            var robotManager = new RobotManager(0);

            //Assert
            Assert.That(robotManager, Is.Not.Null);
            Assert.That(robotManager.Capacity, Is.EqualTo(expectedCapacity));
            Assert.That(robotManager.Count, Is.EqualTo(expectedCount));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfRobotIsAlreadyAdded()
        {
            //Arrange
            var countRobotsToAdd = 5;
            this.AddRobotsInRobotManager(countRobotsToAdd);
            var expectedMessage = $"There is already a robot with name {this.robot.Name}!";

            //Act & Assert
            Assert.That(() => this.robotManager.Add(this.robot),
                Throws.InvalidOperationException
                .With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void AddMethodShouldThrowExceptionIfCapacityIsReached()
        {
            //Arrange
            var countRobotsToAdd = 10;
            this.AddRobotsInRobotManager(countRobotsToAdd);
            var robot = new Robot($"{ROBOT_NAME}11", ROBOT_BATTERY);
            var expectedMessage = "Not enough capacity!";

            //Act & Assert
            Assert.That(() => this.robotManager.Add(robot),
                Throws.InvalidOperationException
                .With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void AddMethodShouldIncreaseCount()
        {
            //Arrange
            var expectedCount1 = 0;
            var expectedCount2 = 7;

            //Assert
            Assert.That(this.robotManager.Count, Is.EqualTo(expectedCount1));

            //Arrange
            var countRobotsToAdd = 7;
            this.AddRobotsInRobotManager(countRobotsToAdd);

            //Act & Assert
            Assert.That(this.robotManager.Count, Is.EqualTo(expectedCount2));
        }

        [Test]
        public void RemoveMethodShouldThrowExceptionIfRobotDoesntExist()
        {
            //Arrange
            var wrongRobotName = $"{ROBOT_NAME}6";

            var expectedMessage = $"Robot with the name {wrongRobotName} doesn't exist!";

            //Act & Assert
            Assert.That(() => this.robotManager.Remove(wrongRobotName),
                Throws.InvalidOperationException
                .With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void RemoveMethodShouldDecreaseCount()
        {
            //Arrange
            var expectedCount1 = 10;
            var expectedCount2 = 5;
            var countRobotsToAdd = 10;
            this.AddRobotsInRobotManager(countRobotsToAdd);

            //Assert
            Assert.That(this.robotManager.Count, Is.EqualTo(expectedCount1));

            //Act
            var countRobotsToRemove = 5;
            this.RemoveRobotsInRobotManager(countRobotsToRemove);

            //Act & Assert
            Assert.That(this.robotManager.Count, Is.EqualTo(expectedCount2));
        }

        [Test]
        public void WorkMethodShouldThrowExceptionIfRobotNotFound()
        {
            //Arrange
            var robotName = $"{ROBOT_NAME}6";
            var robotJob = "SomeTestJob";
            var expectedMessage = $"Robot with the name {robotName} doesn't exist!";

            //Act & Assert
            Assert.That(() => this.robotManager.Work(robotName, robotJob, ROBOT_BATTERY),
                Throws.InvalidOperationException
                .With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void WorkMethodShouldThrowExceptionIfRobotNotEnoughBattery()
        {
            //Arrange
            var countRobotsToAdd = 5;
            this.AddRobotsInRobotManager(countRobotsToAdd);
            var robotJob = "SomeTestJob";
            var batteryUsage = 101;
            var expectedMessage = $"{ROBOT_NAME} doesn't have enough battery!";

            //Act & Assert
            Assert.That(() => this.robotManager.Work(ROBOT_NAME, robotJob, batteryUsage),
                Throws.InvalidOperationException
                .With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void WorkMethodShouldDecreaseRobotBattery()
        {
            //Arrange
            this.robotManager.Add(this.robot);
            var robotJob = "SomeTestJob";
            var batteryUsage = 100;
            var expected = ROBOT_BATTERY - batteryUsage;

            //Act
            this.robotManager.Work(ROBOT_NAME, robotJob, batteryUsage);

            //Assert
            Assert.That(this.robot.Battery, Is.EqualTo(expected));
        }

        [Test]
        public void ChargeMethodShouldThrowExceptionIfRobotNotFound()
        {
            //Arrange
            var expectedMessage = $"Robot with the name {ROBOT_NAME} doesn't exist!";

            //Act & Assert
            Assert.That(() => this.robotManager.Charge(ROBOT_NAME),
                Throws.InvalidOperationException
                .With.Message.EqualTo(expectedMessage));
        }

        [Test]
        public void ChargeMethodShouldChargeRobotBattery()
        {
            //Arrange
            this.robotManager.Add(this.robot);
            var robotJob = "SomeTestJob";
            var batteryUsage = 99;

            //Act
            this.robotManager.Work(ROBOT_NAME, robotJob, batteryUsage);
            this.robotManager.Charge(ROBOT_NAME);

            //Assert
            Assert.That(this.robot.Battery, Is.EqualTo(ROBOT_BATTERY));
        }

        
        private void RemoveRobotsInRobotManager(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.robotManager.Remove($"Test{i + 1}");
            }
        }

        private void AddRobotsInRobotManager(int count)
        {
            for (int i = 0; i < count; i++)
            {
                this.robotManager.Add(new Robot($"Test{i + 1}", ROBOT_BATTERY));
            }
        }

    }
}
