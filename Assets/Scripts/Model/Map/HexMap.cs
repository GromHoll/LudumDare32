using UnityEngine;
using System.Collections.Generic;

namespace Model.Map {
    public class HexMap {

        private Hex[,] map;
        public Hex[,] Map { get { return map; } }

        public int Width { get { return map.GetLength(0); } }
        public int Height { get { return map.GetLength(1); } }

        public HexMap(int width, int height) {
            map = new Hex[width, height];
            for (var x = 0; x < width; x++) {
                for (var y = 0; y < height; y++) {
                    map[x, y] = new Hex { X = x, Y = y };
                }
            }
        }
    }
}
