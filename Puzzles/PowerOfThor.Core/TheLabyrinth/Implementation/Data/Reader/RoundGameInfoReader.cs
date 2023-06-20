namespace TheLabyrinth.Abstraction;

using System;
using System.Collections.Generic;

using CodingGames.Core.Abstraction;

public class RoundGameInfoReader : IRoundGameInfoReader
{
   private readonly IInputReader inputReader;

   private readonly ILabyrinthReader labyrinthReader;

   public RoundGameInfoReader(IInputReader inputReader, ILabyrinthReader labyrinthReader)
   {
      this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
      this.labyrinthReader = labyrinthReader ?? throw new ArgumentNullException(nameof(labyrinthReader));
   }

   public RoundGameInfo ReadRoundGameInfo(InitialGameInfo initialGameInfo, int round)
   {
      if (initialGameInfo == null)
      {
         throw new ArgumentNullException(nameof(initialGameInfo));
      }

      if (round < 0)
      {
         throw new ArgumentOutOfRangeException(nameof(round));
      }

      var positionInput = inputReader.ReadInput();

      var positionInputParts = positionInput.Split(' ');

      var xCoordinate = int.Parse(positionInputParts[0]);
      var yCoordinate = int.Parse(positionInputParts[1]);

      var myPosition = new Position(xCoordinate, yCoordinate);

      List<string> labyrinthRowData = new();
      for (var i = 0; i < initialGameInfo.RowCount; i++)
      {
         var labyrinthCellInfo = inputReader.ReadInput();
         labyrinthRowData.Add(labyrinthCellInfo);
      }

      var labyrinth = labyrinthReader.ReadLabyrinth(labyrinthRowData);

      return new RoundGameInfo(myPosition, round, labyrinth);
   }
}