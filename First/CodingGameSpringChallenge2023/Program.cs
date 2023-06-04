﻿namespace CodingGameSpringChallenge2023;

using SpringChallenge.Core.Abstractions.Logic;
using SpringChallenge.Core.Implementations.Logic;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

internal static class Program
{
   #region Methods

   private static void Main()
   {
      FileMergeProgram.Execute();

      //ICrystalHarvestingGame game = new CrystalHarvestingGame();
      //game.StartGame();

      Console.WriteLine("End of program.");
      Console.ReadKey();

      // TODO Take all bases into consideration (ants are divided between them at start)
      // TODO When count the maximum harvest take available resource count into consideration
      // TODO Most difficult: do something with battle ant chains!!!
   }

   #endregion
}