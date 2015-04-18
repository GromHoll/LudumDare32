using System.Collections.Generic;
using UnityEngine;

namespace Model.Map {
    public class TerrainMap {

        private Terrain[,] map;
        public Terrain[,] Map { get { return map; } }

        public int Width { get { return map.GetLength(0); } }
        public int Height { get { return map.GetLength(1); } }

        public TerrainMap(int width, int height) {
            map = new Terrain[width, height];
            for (var x = 0; x < width; x++) {
                for (var y = 0; y < height; y++) {
                    map[x, y] = new Terrain(x, y, TerrainType.GROUND );
                }
            }
        }
    }
}
