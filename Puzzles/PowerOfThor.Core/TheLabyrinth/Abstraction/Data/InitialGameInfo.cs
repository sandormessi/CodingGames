using System;

using TheLabyrinth.Abstraction.Data;

public class InitialGameInfo
{
   public InitialGameInfo(int rowCount, int columnCount, int alarmCountdown, GameRules rules)
   {
      if (rowCount <= 0)
      {
         throw new ArgumentOutOfRangeException(nameof(rowCount));
      }

      if (columnCount <= 0)
      {
         throw new ArgumentOutOfRangeException(nameof(columnCount));
      }

      if (alarmCountdown <= 0)
      {
         throw new ArgumentOutOfRangeException(nameof(alarmCountdown));
      }

      RowCount = rowCount;
      ColumnCount = columnCount;
      AlarmCountdown = alarmCountdown;
      Rules = rules ?? throw new ArgumentNullException(nameof(rules));
   }

   public int RowCount { get; }

   public int ColumnCount { get; }

   public int AlarmCountdown { get; }

   public GameRules Rules { get; }
}