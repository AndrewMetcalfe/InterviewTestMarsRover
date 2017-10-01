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
    }
}
