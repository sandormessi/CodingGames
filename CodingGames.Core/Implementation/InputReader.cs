using System;
using CodingGames.Core.Abstraction;

namespace CodingGames.Core.Implementation;

public class InputReader : IInputReader
{
   #region IInputReader Members

   public string ReadInput()
   {
      string? input = Console.ReadLine();
      if (input is null)
      {
         throw new InvalidOperationException("There is no input.");
      }

      return input;
   }

   #endregion
}