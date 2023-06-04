namespace SpringChallenge.Core.Implementations.InputReader;

using System;

using SpringChallenge.Core.Abstractions.InputReader;

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