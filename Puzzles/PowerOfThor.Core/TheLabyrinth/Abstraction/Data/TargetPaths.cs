namespace TheLabyrinth.Abstraction.Data;

using System;

public class TargetPaths
{
   public TargetPaths(TargetPath pathToTarget1, TargetPath pathToTarget2)
   {
      PathToTarget1 = pathToTarget1 ?? throw new ArgumentNullException(nameof(pathToTarget1));
      PathToTarget2 = pathToTarget2 ?? throw new ArgumentNullException(nameof(pathToTarget2));
   }

   public TargetPath PathToTarget1 { get; }

   public TargetPath PathToTarget2 { get; }
}