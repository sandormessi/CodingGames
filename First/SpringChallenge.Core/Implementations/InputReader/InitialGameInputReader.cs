using CodingGames.Core.Abstraction;

namespace SpringChallenge.Core.Implementations.InputReader;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.InputReader;

public class InitialGameInputReader : IInitialGameInputReader
{
   #region Constants and Fields

   private readonly IInputReader inputReader;

   #endregion

   #region Constructors and Destructors

   public InitialGameInputReader(IInputReader inputReader)
   {
      this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
   }

   #endregion

   #region IInitialGameInputReader Members

   public InitialGameInfo ReadGameInfo()
   {
      string firstInput = GetNextInput();

      int numberOfCells = int.Parse(firstInput);

      IList<InitialCellInfo> cells = ReadCellInfo(numberOfCells);

      string thirdInput = GetNextInput();

      int baseCount = int.Parse(thirdInput);

      string fourthInput = GetNextInput();
      string[] myBaseIndexStrings = fourthInput.Split(' ');
      var myBaseIndexes = new int[baseCount];
      for (var i = 0; i < baseCount; i++)
      {
         int myBaseIndex = int.Parse(myBaseIndexStrings[i]);
         myBaseIndexes[i] = myBaseIndex;
      }

      string fifthInput = GetNextInput();
      string[] opponentBaseIndexStrings = fifthInput.Split(' ');
      var opponentBaseIndexes = new int[baseCount];
      for (var i = 0; i < baseCount; i++)
      {
         int opponentBaseIndex = int.Parse(opponentBaseIndexStrings[i]);
         opponentBaseIndexes[i] = opponentBaseIndex;
      }

      int initialEggCount = cells.Where(x => x.Type.HasFlag(ResourceType.Egg)).Sum(x => x.InitialResourceCount);
      return new InitialGameInfo(numberOfCells, cells, baseCount, myBaseIndexes, opponentBaseIndexes, initialEggCount);
   }

   #endregion

   #region Methods

   private string GetNextInput()
   {
      return inputReader.ReadInput();
   }

   private IList<InitialCellInfo> ReadCellInfo(int numberOfCells)
   {
      IList<InitialCellInfo> cells = new List<InitialCellInfo>();
      for (var i = 0; i < numberOfCells; i++)
      {
         string cellInfoInput = GetNextInput();

         string[] cellInfo = cellInfoInput.Split(' ');
         int type = int.Parse(cellInfo[0]);
         int initialResources = int.Parse(cellInfo[1]);

         int neighborIndex1 = int.Parse(cellInfo[2]);
         int neighborIndex2 = int.Parse(cellInfo[3]);
         int neighborIndex3 = int.Parse(cellInfo[4]);
         int neighborIndex4 = int.Parse(cellInfo[5]);
         int neighborIndex5 = int.Parse(cellInfo[6]);
         int neighborIndex6 = int.Parse(cellInfo[7]);

         var neighbors = new[]
         {
            new NeighborInfo(NeighborDirection.Right, neighborIndex1), new NeighborInfo(NeighborDirection.RightTop, neighborIndex2), new NeighborInfo(NeighborDirection.LeftTop, neighborIndex3),
            new NeighborInfo(NeighborDirection.Left, neighborIndex4), new NeighborInfo(NeighborDirection.LeftBottom, neighborIndex5), new NeighborInfo(NeighborDirection.RightBottom, neighborIndex6)
         };

         var cell = new InitialCellInfo(i, (ResourceType)type, initialResources, neighbors.Where(x => x.NeighborId >= 0));

         cells.Add(cell);
      }

      return cells;
   }

   #endregion
}