namespace TheLabyrinth.Abstraction;

public class LabyrinthCellWithMoveCost : LabyrinthCell
{
   public LabyrinthCellWithMoveCost(LabyrinthCellType type, Position position)
      : base(type, position)
   {
   }

   public int DistanceFromTarget { get; }
}