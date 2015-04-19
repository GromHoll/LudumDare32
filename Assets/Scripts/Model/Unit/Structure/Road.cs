using Model.Map;
using Model.Map.Terra;
using Model.Unit;
using System.Collections.Generic;

namespace Model.Unit.Structure {
    public class Road : Connectable {

        public HexCoord Coord { get; set; }
        public Terrain Terrain{ get; set; }

        public Connectable Up { get; set; }
        public Connectable UpLeft { get; set; }
        public Connectable UpRight { get; set; }
        public Connectable Down { get; set; }
        public Connectable DownLeft { get; set; }
        public Connectable DownRight { get; set; }

        public Road(int x, int y) {
            Coord = new HexCoord {X = x, Y = y};
        }

    }
}
