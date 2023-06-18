public class InitialGameInfo
{
   public InitialGameInfo(int rowCount, int columnCount, int alarmCountdown)
   {
      RowCount = rowCount;
      ColumnCount = columnCount;
      AlarmCountdown = alarmCountdown;
   }

   public int RowCount { get; }

   public int ColumnCount { get; }

   public int AlarmCountdown { get; }
}