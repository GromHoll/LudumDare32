using Model.Unit;

namespace Model.Map.Terra {

    public abstract class Terrain {

        public HexCoord Coord { get; private set; }
        public ControlType Control {get; set; }

        public Terrain(int x, int y) {
            Coord = new HexCoord { X = x, Y = y };
            Control = ControlType.FREE;
        }

        public virtual bool IsAvailableForUnit(AbstractUnit unit) {
            return true;
        }
    }

}
