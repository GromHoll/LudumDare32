using Model.Unit;

namespace Model.Map.Terra {

    public class WaterTerrain : Terrain {

        public WaterTerrain(int x, int y) : base(x, y) {}

        public override bool IsAvailableForUnit(AbstractUnit unit) {
            return unit.IsWaterMove;
        }
    }

}
