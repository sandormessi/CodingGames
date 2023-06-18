namespace TheLabyrinth
{
   public class LabyrinthCell
   {
      public LabyrinthCell(LabyrinthCellType type)
      {
         Type = type;
      }

      public LabyrinthCellType Type { get; }
   }
}