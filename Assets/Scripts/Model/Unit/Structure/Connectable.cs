using Model.Map;

namespace Model.Unit.Structure {
    public interface Connectable {
        HexCoord Coord { get; }

        Connectable Up { get; set; }
        Connectable UpLeft { get; set; }
        Connectable UpRight { get; set; }
        Connectable Down { get; set; }
        Connectable DownLeft { get; set; }
        Connectable DownRight { get; set; }

    }
}
