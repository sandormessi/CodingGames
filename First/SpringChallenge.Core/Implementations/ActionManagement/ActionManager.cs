namespace SpringChallenge.Core.Implementations.ActionManagement;

using System;
using System.Text;

using SpringChallenge.Core.Abstractions.ActionManagement;

public class ActionManager : IActionManager
{
   #region Constants and Fields

   private const char CommandTerminator = ';';

   private readonly StringBuilder actionStringBuilder = new(128);

   #endregion

   #region IActionManager Members

   public void DoNothing()
   {
      actionStringBuilder.Append($"WAIT{CommandTerminator}");
   }

   public void PerformActions()
   {
      string actions = actionStringBuilder.ToString().TrimEnd(CommandTerminator);
      Console.WriteLine(actions);
      actionStringBuilder.Clear();
   }

   public void PlaceBeacon(int cellIndex, int strength)
   {
      actionStringBuilder.Append($"BEACON {cellIndex} {strength}{CommandTerminator}");
   }

   public void PlaceBeaconsLine(int cellIndex1, int cellIndex2, int strength)
   {
      actionStringBuilder.Append($"LINE {cellIndex1} {cellIndex2} {strength}{CommandTerminator}");
   }

   public void WriteMessage(string message)
   {
      actionStringBuilder.Append($"MESSAGE {message}{CommandTerminator}");
   }

   #endregion
}