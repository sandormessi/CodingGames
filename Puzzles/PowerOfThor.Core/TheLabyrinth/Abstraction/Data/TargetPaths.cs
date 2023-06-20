namespace TheLabyrinth.Abstraction.Data;

using System;

public class TargetPaths
{
   public TargetPaths(LabyrinthPath pathToTarget1, LabyrinthPath pathToTarget2)
   {
      PathToTarget1 = pathToTarget1 ?? throw new ArgumentNullException(nameof(pathToTarget1));
      PathToTarget2 = pathToTarget2 ?? throw new ArgumentNullException(nameof(pathToTarget2));
   }

   public LabyrinthPath PathToTarget1 { get; }

   public LabyrinthPath PathToTarget2 { get; }
}