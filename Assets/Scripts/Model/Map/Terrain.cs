namespace Model.Map {

    public enum TerrainType { WATER, CITY, GROUND };
    public enum ControlType { FREE, PLAYER, ENEMY };

    public class Terrain {

        public HexCoord Coord { get; private set; }
        public TerrainType Type { get; set; }
        public ControlType Control {get; set; }

        public Terrain(int x, int y, TerrainType type) {
            Coord = new HexCoord { X = x, Y = y };
            Control = ControlType.FREE;
            Type = type;
        }

    }

}
