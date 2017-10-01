using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarsRover
{
    public class RoverClass
    {
		public RoverClass()
		{
		}

        const int gridMaxX = 100;
        const int gridMaxY = 100;
		private int gridRef = 1;
		private string direction = "South";

		private string location
		{
			get
			{
				return $"{gridRef.ToString()} {direction}";
			}
		}

        /// <summary>
        /// Moves the rover using the specified commands.
        /// </summary>
        /// <returns>The current grid reference and direction.</returns>
        /// <param name="commands">String array of commands.</param>
		public string Movement(string[] commands)
		{
            var commandsExecutedCount = 0;
			foreach (string commandItem in commands)
			{
				if (IsTurnCommand(commandItem))
				{
					ExecuteTurnCommand(commandItem);
				}
				else if (IsDistanceCommand(commandItem))
				{
					if (!ExecuteDistanceCommand(commandItem))
					{
						// halt
						break;
					}
				}

                commandsExecutedCount += 1;
                if (commandsExecutedCount >= 5) break;
			}
			return location;
		}

		private bool IsTurnCommand(string command)
		{
			return ValidTurnCommands.Any(c => c == command);
		}

		private string[] ValidTurnCommands = new string[] { "Left", "Right" };

		private void ExecuteTurnCommand(string command)
		{
			if (command == "Left")
			{
				switch (direction)
				{
					case "South":
						direction = "East";
						break;
					case "East":
						direction = "North";
						break;
					case "North":
						direction = "West";
						break;
					case "West":
						direction = "South";
						break;
				}
			}
			else if (command == "Right")
			{
				switch (direction)
				{
					case "South":
						direction = "West";
						break;
					case "East":
						direction = "South";
						break;
					case "North":
						direction = "East";
						break;
					case "West":
						direction = "North";
						break;
				}
			}
		}

		private bool IsDistanceCommand(string command)
		{
			string validDistancePattern = @"\d+[m]";

			Match match = Regex.Match(command, validDistancePattern);

			return match.Success;
		}

		private bool ExecuteDistanceCommand(string command)
		{

			int distance = GetDistance(command);

			switch (direction)
			{
				case "South":
                    var y = gridRef / gridMaxX;

                    gridRef = gridRef + (100  * distance);
					break;
				case "East":
					gridRef = gridRef + distance;
					break;
				case "North":
					gridRef = gridRef - (100 * distance);
					break;
				case "West":
					gridRef = gridRef - (distance);
					break;
			}

			return true;
		}

		private int GetDistance(string command)
		{
			int distance = 0;

			int.TryParse(command.Substring(0, command.Length - 1), out distance);

			return distance;
		}
    }
}
