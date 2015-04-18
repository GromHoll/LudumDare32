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

        public IList<Terrain> GetTerrainsInRadius(HexCoord coord, int radius) {
            var result = new List<Terrain>();
            foreach (var terra in Map) {
                var distance = coord.WorldDistance(terra.Coord);
                if (distance <= radius*HexCoord.Y_SHIFT*2 + 0.01) {
                    result.Add(terra);
                }
            }
            return result;
        }
    }
}
