namespace TheLabyrinth.Abstraction;

public interface IRoundGameInfoReader
{
   RoundGameInfo ReadRoundGameInfo(InitialGameInfo initialGameInfo, int round);
}