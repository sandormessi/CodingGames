namespace TheLabyrinth.Abstraction.Data;

using System;

public class TargetPath
{
   public TargetPath(LabyrinthPath path, int actualPosition)
   {
      Path = path ?? throw new ArgumentNullException(nameof(path));
      ActualPosition = actualPosition;
      TargetReached = ActualPosition == path.Distance;
   }

   public LabyrinthPath Path { get; }

   public int ActualPosition { get; }

   public bool TargetReached { get; }
}