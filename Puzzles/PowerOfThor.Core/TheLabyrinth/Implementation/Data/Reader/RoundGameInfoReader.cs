namespace TheLabyrinth.Abstraction;

using System;
using System.Collections.Generic;

using CodingGames.Core.Abstraction;

using TheLabyrinth.Abstraction.Logic;

public class RoundGameInfoReader : IRoundGameInfoReader
{
   private readonly IInputReader inputReader;

   private readonly ILabyrinthReader labyrinthReader;

   private readonly IExtendedLabyrinthReader extendedLabyrinthReader;

   private bool isFirstRead = true;

   private Position? startPosition;

   public RoundGameInfoReader(IInputReader inputReader, ILabyrinthReader labyrinthReader, IExtendedLabyrinthReader extendedLabyrinthReader)
   {
      this.inputReader = inputReader ?? throw new ArgumentNullException(nameof(inputReader));
      this.labyrinthReader = labyrinthReader ?? throw new ArgumentNullException(nameof(labyrinthReader));
      this.extendedLabyrinthReader = extendedLabyrinthReader ?? throw new ArgumentNullException(nameof(extendedLabyrinthReader));
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

      var extendedLabyrinth = extendedLabyrinthReader.ReadExtendedLabyrinth(labyrinth);

      if (isFirstRead)
      {
         startPosition = myPosition;
         isFirstRead = false;
      }

      return new RoundGameInfo(myPosition, round, extendedLabyrinth, startPosition);
   }
}