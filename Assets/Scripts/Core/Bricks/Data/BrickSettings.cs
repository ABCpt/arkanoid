using System;
using UnityEngine;

namespace Core.Bricks.Data
{
   [Serializable]
   public struct BrickSettings
   {
      public BrickType BrickType;
      public BrickType NextBrickType;
      public Color Color;
   }
}
