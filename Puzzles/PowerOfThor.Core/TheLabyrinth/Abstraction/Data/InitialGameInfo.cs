using System;

public class InitialGameInfo
{
   public InitialGameInfo(int rowCount, int columnCount, int alarmCountdown)
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
   }

   public int RowCount { get; }

   public int ColumnCount { get; }

   public int AlarmCountdown { get; }
}