using NUnit.Framework;
using System;
using MarsRover;

namespace MarsRoverTest
{
    [TestFixture()]
    public class Test
    {
        [Test()]
		public void GivenExampleTest()
		{
			// Arrange 
			var m = new RoverClass();
            var commands = "50m,Left,23m,Left,4m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("4624 North", result);
		}
		
		[Test()]
		public void OutOfBoundsSouthTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "1m,2m,100m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("9901 South", result);
		}

		[Ignore]
		[Test()]
		public void OutOfBoundsEastTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Left,200m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("100 East", result);
		}

		[Ignore]
		[Test()]
		public void OutOfBoundsWestTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Right,10m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 West", result);
		}

		[Ignore]
		[Test()]
		public void OutOfBoundsNorthTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Right,Right,10m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 North", result);
		}

		[Test()]
		public void InvalidCommandTooManyCommandsTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Left,10m,10m,10m,10m,10m,10m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("41 East", result);
		}

		[Test()]
		public void DirectionalCommandsTurnLeftTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = new string[] { "Left" };

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 East", result);
		}

		[Test()]
		public void DirectionalCommandsTurnRightTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = new string[] { "Right" };

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 West", result);
		}

		[Test()]
		public void DirectionalCommandsTurnRightTurnLeftTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Right,Left".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 South", result);
		}

		[Test()]
		public void DirectionalCommandsTurnLeftTurnRightTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Left,Right".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 South", result);
		}

		[Test()]
		public void DirectionalCommandsMultipleTurnLeftsTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Left,Left,Left,Left,Left".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 East", result);
		}

		[Test()]
		public void DirectionalCommandsMultipleTurnRightsTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Right,Right,Right,Right,Right".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 West", result);
		}

		[Test()]
		public void DistanceCommandsNoMovementTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "0m,0m,0m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1 South", result);
		}

		[Test()]
		public void DistanceCommandsMultipleNoMovementTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "0m,0m,0m,0m,1m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("101 South", result);
		}

		[Test()]
		public void DistanceCommandsMultipleMovementTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "1m,2m,3m,4m,5m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("1501 South", result);
		}

		[Test()]
		public void MoveSouthTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "2m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("201 South", result);
		}

		[Test()]
		public void MoveEastTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Left,2m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("3 East", result);
		}

		[Test()]
		public void MoveWestTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "Left,10m,Left,Left,5m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("6 West", result);
		}

		[Test()]
		public void MoveNorthTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands = "10m,Right,Right,5m".Split(new char[] {','});

			// Act
			var result = m.Movement(commands);

			// Assert
			Assert.AreEqual("501 North", result);
		}
        		
		[Test()]
		public void MultipleCommandSetsTest()
		{
			// Arrange 
			var m = new RoverClass();
			var commands1 = "10m,Right,Right,5m".Split(new char[] {','});
			var commands2 = "1m".Split(new char[] {','});

			// Act
			var result1 = m.Movement(commands1);
			var result2 = m.Movement(commands2);

			// Assert
			Assert.AreEqual("501 North", result1);
			Assert.AreEqual("401 North", result2);
		}
    }
}
