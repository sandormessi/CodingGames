namespace TheLabyrinth.Abstraction.Logic;

using System;

public class ExtendedLabyrinthReader : IExtendedLabyrinthReader
{
   public ExtendedLabyrinth ReadExtendedLabyrinth(InitialLabyrinth initialLabyrinth)
   {
      if (initialLabyrinth == null)
      {
         throw new ArgumentNullException(nameof(initialLabyrinth));
      }

      throw new NotImplementedException();
   }
}