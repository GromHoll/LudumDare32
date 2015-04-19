using Model.Unit;

namespace Model.Map.Terra {

    public abstract class Terrain {

        public HexCoord Coord { get; private set; }
        public ControlType Control {get; set; }
        public string Name {get; set; }

        public Terrain(int x, int y, string name) {
            Coord = new HexCoord { X = x, Y = y };
            Control = ControlType.FREE;
            Name = name;
        }

        public virtual bool IsAvailableForUnit(AbstractUnit unit) {
            return true;
        }

        public string ToString() {
            return "Terrain: " + Name + "\n" +
                   "Controlled by " + ControlledBy();
        }

        private string ControlledBy() {
            switch (Control) {
                case ControlType.FREE: return "nobody";
                case ControlType.PLAYER: return "player";
                case ControlType.ENEMY: return "enemy";
                default: return "unknown";
            }
        }
    }

}
