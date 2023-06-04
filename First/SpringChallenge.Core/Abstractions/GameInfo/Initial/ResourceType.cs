namespace SpringChallenge.Core.Abstractions.GameInfo.Initial;

using System;

[Flags]
public enum ResourceType
{
   Empty = 0,

   Egg = 1,

   Crystal = 2,

   All = Egg | Crystal
}