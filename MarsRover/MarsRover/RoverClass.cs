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

        private GridClass grid = new GridClass();

		const int maxCommandCount = 5;

		// we need a X and Y co-ordinates to map to the gridref strings that the rover sends back
		// row 1 starts at x:1,y:1 (gridRef: 1)         ...and ends at x:100,y:1 (gridRef: 100)
		// row 2 starts at x:1,y2 (gridRef: 101)        ...and ends at x:100,y2 (gridRef: 200)
		// row 100 starts at x:100,y:1 (gridRef: 9901)  ...and ends at x:100,y:100 (gridRef: 10000)

		const int gridMinX = 1;
		const int gridMaxX = 100;

		const int gridMinY = 1;
        const int gridMaxY = 100;

        // in ExecuteDistanceCommand(command) I've maniplating the grid string in a clunky way.
        // It would probably be neater to convert the grid ref string into an X,Y coordinate 
        // and then do the movement and then convert the X,Y coordinate back to a gridref string. 
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
                if (commandsExecutedCount >= maxCommandCount) break;
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
            bool exceutionComplete = false;
			int distance = GetDistance(command);
            int currentY = grid.GetY(gridRef.ToString());
			int currentX = grid.GetX(gridRef.ToString());
			
			switch (direction)
			{
				case "South":
                    
                    if ((currentY + distance) >= gridMaxY) 
                    {                        
                        // only move as far as the grid perimeter
                        gridRef = grid.GetGridRefInt(currentX, gridMaxY);
					} 
                    else 
                    {
                        gridRef = grid.GetGridRefInt(currentX, currentY + distance);
                        exceutionComplete =true;
                    }                    
					break;

				case "East":
                    					
					if ((currentX + distance) >= gridMaxX)
					{
						// only move as far as the grid perimeter
						gridRef = grid.GetGridRefInt(gridMaxX, currentY);
					}
					else
					{
                        gridRef = grid.GetGridRefInt( currentX + distance, currentY);
						exceutionComplete = true;
					}
					break;

				case "North":
                    
					if ((currentY - distance) <= gridMinY)
					{
                        // only move as far as the grid perimeter 
                        gridRef = grid.GetGridRefInt(currentX, gridMinY); ;
					}
					else
					{
						gridRef = grid.GetGridRefInt(currentX, currentY - distance);
						exceutionComplete = true;
					}					
					break;

				case "West":
                    
					if ((currentX - distance) <= gridMinX)
					{
						// only move as far as the grid perimeter 
                        gridRef = grid.GetGridRefInt(gridMinX, currentY );
					}
					else
					{
						gridRef = grid.GetGridRefInt(currentX - distance, currentY);
						exceutionComplete = true;
					}
					break;				
			}

			return exceutionComplete;
		}

		private int GetDistance(string command)
		{
			int distance = 0;

			int.TryParse(command.Substring(0, command.Length - 1), out distance);

			return distance;
		}
    }
}
