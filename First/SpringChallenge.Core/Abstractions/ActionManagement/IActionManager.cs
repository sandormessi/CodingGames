namespace SpringChallenge.Core.Abstractions.ActionManagement;

public interface IActionManager
{
   #region Public Methods and Operators

   void DoNothing();

   void PerformActions();

   void PlaceBeacon(int cellIndex, int strength);

   void PlaceBeaconsLine(int cellIndex1, int cellIndex2, int strength);

   void WriteMessage(string message);

   #endregion
}