using CodingGames.Core.Abstraction;

namespace SpringChallenge.Core.Implementations.InputReader;

using System;
using System.Collections.Generic;
using System.Linq;

using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.InputReader;

public class CellInfoPerTurnReader : ICellInfoPerTurnReader
{
   #region Constants and Fields

   private readonly IInputReader inputReader;

   #endregion

   #region Constructors and Destructors

   public CellInfoPerTurnReader(IInputReader inputReader)
   {
      this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
   }

   #endregion

   #region ICellInfoPerTurnReader Members

   public CellInfoPerTurn ReadCellInfoPerTurn(InitialGameInfo initialGameInfo, int round)
   {
      if (initialGameInfo == null)
      {
         throw new ArgumentNullException(nameof(initialGameInfo));
      }

      var actualCellInfos = new ActualCellInfo[initialGameInfo.CellCount];

      for (var i = 0; i < initialGameInfo.CellCount; i++)
      {
         string cellInfoInput = inputReader.ReadInput();

         string[] info = cellInfoInput.Split(' ');
         int resources = int.Parse(info[0]); // the current amount of eggs/crystals on this cell
         int myAntCount = int.Parse(info[1]); // the amount of your ants on this cell
         int opponentAntCount = int.Parse(info[2]); // the amount of opponent ants on this cell

         InitialCellInfo initialCellInfo = initialGameInfo.Cells[i];
         var cellInfo = new ActualCellInfo(initialCellInfo.CellId, initialCellInfo.Type, initialCellInfo.InitialResourceCount, initialCellInfo.Neighbors, resources, myAntCount, opponentAntCount);

         actualCellInfos[i] = cellInfo;
      }

      SetNeighborCells(actualCellInfos);

      IEnumerable<ActualCellInfo> myBases = initialGameInfo.MyBaseIndexes.Select(myBaseCellId => actualCellInfos.First(y => y.CellId == myBaseCellId));
      IEnumerable<ActualCellInfo> opponentBases = initialGameInfo.OpponentBaseIndexes.Select(opponentBaseCellId => actualCellInfos.First(y => y.CellId == opponentBaseCellId));

      int allEggs = actualCellInfos.Where(x => x.Type.HasFlag(ResourceType.Egg)).Sum(x => x.ActualResourceCount);
      return new CellInfoPerTurn(actualCellInfos, round, myBases, opponentBases, allEggs, initialGameInfo.InitialEggCount);
   }

   #endregion

   #region Methods

   private static void SetNeighborCells(IReadOnlyList<ActualCellInfo> cells)
   {
      foreach (ActualCellInfo cell in cells)
      {
         foreach (NeighborInfo cellNeighbor in cell.Neighbors)
         {
            if (cellNeighbor.NeighborId >= 0)
            {
               cellNeighbor.Cell = cells.First(x => x.CellId == cellNeighbor.NeighborId);
            }
         }
      }
   }

   #endregion
}