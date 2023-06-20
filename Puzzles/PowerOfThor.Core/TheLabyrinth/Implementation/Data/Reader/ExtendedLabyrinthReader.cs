namespace TheLabyrinth.Abstraction.Logic;

using System;
using System.Linq;

using TheLabyrinth.Abstraction.Data.Reader;

public class ExtendedLabyrinthReader : IExtendedLabyrinthReader
{
   private readonly IExtendedLabyrinthCellReader extendedLabyrinthCellReader;

   public ExtendedLabyrinthReader(IExtendedLabyrinthCellReader extendedLabyrinthCellReader)
   {
      this.extendedLabyrinthCellReader = extendedLabyrinthCellReader ?? throw new ArgumentNullException(nameof(extendedLabyrinthCellReader));
   }

   public ExtendedLabyrinth ReadExtendedLabyrinth(InitialLabyrinth initialLabyrinth)
   {
      if (initialLabyrinth == null)
      {
         throw new ArgumentNullException(nameof(initialLabyrinth));
      }

      var cells = initialLabyrinth.Cells;

      return new ExtendedLabyrinth(cells
         .Select(x => x.Select(y => extendedLabyrinthCellReader.ReadExtendedLabyrinthCell(initialLabyrinth, y)).ToList()).ToList());
   }
}