using Common;
using UnityEngine;

namespace Model.Map {
    public class HexCoord {

        public const float X_SHIFT = 0.750f;
        public const float Y_SHIFT = 0.433f;

        private IntVector2 coord;
        public IntVector2 Coord { get { return coord; } }
        public int X { get { return coord.x; } set { coord.x = value; } }
        public int Y { get { return coord.y; } set { coord.y = value; } }

        public Vector2 WorldCoord { get { return new Vector2(WorldX, WorldY); } }
        public float WorldX { get { return X*X_SHIFT; } }
        public float WorldY { get { return 2*Y*Y_SHIFT + Y_SHIFT*(X%2); } }

        public float WorldDistance(HexCoord other) {
            return Mathf.Sqrt(Mathf.Pow(WorldX - other.WorldX, 2f) +
                              Mathf.Pow(WorldY - other.WorldY, 2f));
        }

    }
}
