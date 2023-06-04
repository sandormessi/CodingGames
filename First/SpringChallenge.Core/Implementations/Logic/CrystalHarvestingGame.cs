namespace SpringChallenge.Core.Implementations.Logic;

using SpringChallenge.Core.Abstractions.ActionManagement;
using SpringChallenge.Core.Abstractions.GameInfo.Initial;
using SpringChallenge.Core.Abstractions.GameInfo.PerTurn;
using SpringChallenge.Core.Abstractions.InputReader;
using SpringChallenge.Core.Abstractions.Logic;
using SpringChallenge.Core.Implementations.ActionManagement;
using SpringChallenge.Core.Implementations.InputReader;

public class CrystalHarvestingGame : ICrystalHarvestingGame
{
   #region ICrystalHarvestingGame Members

   public void StartGame()
   {
      IMaximumHarvestCalculator maximumHarvestCalculator = new MaximumHarvestCalculator();
      IResourceReachPathFinder resourceReachPathFinder = new ResourceReachPathFinder();
      IResourcePathCounter resourcePathCounter = new ResourcePathCounter();
      IResourceSelector resourceSelector = new ResourceSelector();
      IActionManager actionManager = new ActionManager();
      IInputReader inputReader = new InputReader();
      IAntCounter antCounter = new AntCounter();

      IInitialGameInputReader initialGameInfoReader = new InitialGameInputReader(inputReader);
      ICellInfoPerTurnReader turnInfoReader = new CellInfoPerTurnReader(inputReader);
      IPathCalculator pathCalculator = new PathCalculator(actionManager, resourceSelector, resourcePathCounter, antCounter);
      IOpponentPathCalculator opponentPathCalculator = new OpponentPathCalculator(pathCalculator);
      ICellAnalyzer cellAnalyzer = new CellAnalyzer(opponentPathCalculator);
      IExtendedCellInfoPerTurnReader extendedCellInfoPerTurnReader = new ExtendedCellInfoPerTurnReader(turnInfoReader, cellAnalyzer);
      IMaximumHarvestCollectionCalculator maximumHarvestCollectionCalculator = new MaximumHarvestCollectionCalculator(maximumHarvestCalculator, antCounter);
      IMostHarvestingCollectionCalculator mostHarvestingCalculator = new MostHarvestingCalculator(maximumHarvestCollectionCalculator);
      IBeaconPathFinder beaconPathFinder = new BeaconPathFinder(antCounter, resourceReachPathFinder, mostHarvestingCalculator, maximumHarvestCollectionCalculator);
      IBeaconManager beaconManager = new BeaconManager(actionManager);

      IGameLogicManager gameLogicManager = new GameLogicManager(actionManager, pathCalculator,  beaconPathFinder, beaconManager);

      InitialGameInfo initialGameInfo = initialGameInfoReader.ReadGameInfo();

      var round = 1;
      while (true)
      {
         CellInfoPerTurn perTurnInfo = extendedCellInfoPerTurnReader.ReadCellInfoPerTurn(initialGameInfo, round);

         gameLogicManager.ExecuteLogic(perTurnInfo);

         actionManager.PerformActions();

         round++;
      }
   }

   #endregion
}