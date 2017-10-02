using NUnit.Framework;
using System;
using MarsRover;

namespace MarsRoverTest
{
    [TestFixture()]
    public class GridTests
    {
        [Test()]
        public void StartingPositionTest()
        {
            // Arrange 
            var g = new GridClass();

            // Act
            var result = g.GetGridRef(1,1);

            // Assert
            Assert.AreEqual("1", result);
        }

        [Test()]
        public void GetGridRefNorthEastCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetGridRef(100, 1);

			// Assert
			Assert.AreEqual("100", result);
		}


		[Test()]
		public void GetYNorthEastCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetY("100");

			// Assert
			Assert.AreEqual(1, result);
		}

		[Test()]
		public void GetXNorthEastCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetX("100");

			// Assert
			Assert.AreEqual(100, result);
		}

		[Test()]
		public void GetGridRefNorthWestCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetGridRef(1, 1);

			// Assert
			Assert.AreEqual("1", result);
		}

		[Test()]
		public void GetYNorthWestCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetY("1");

			// Assert
			Assert.AreEqual(1, result);
		}

		[Test()]
		public void GetXNorthWestCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetX("1");

			// Assert
			Assert.AreEqual(1, result);
		}

		[Test()]
		public void GetGridRefSouthWestCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetGridRef(1, 100);

			// Assert
			Assert.AreEqual("9901", result);
		}

		[Test()]
		public void GetYSouthWestCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetY("9901");

			// Assert
			Assert.AreEqual(100, result);
		}

		[Test()]
		public void GetXSouthWestCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetX("9901");

			// Assert
			Assert.AreEqual(1, result);
		}

		[Test()]
		public void GetGridRefSouthEastCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetGridRef(100, 100);

			// Assert
			Assert.AreEqual("10000", result);
		}

		[Test()]
		public void GetYSouthEastCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetY("10000");

			// Assert
			Assert.AreEqual(100, result);
		}

		[Test()]
		public void GetXSouthEastCornerTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetX("10000");

			// Assert
			Assert.AreEqual(100, result);
		}

		[Test()]
		public void GetGridRefMidPointTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetGridRef(4,4);

			// Assert
			Assert.AreEqual("304", result);
		}

		[Test()]
		public void GetYMidPointTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetY("304");

			// Assert
			Assert.AreEqual(4, result);
		}

		[Test()]
		public void GetXMidPointTest()
		{
			// Arrange 
			var g = new GridClass();

			// Act
			var result = g.GetX("304");

			// Assert
			Assert.AreEqual(4, result);
		}
    }
}
