using Model.Map;
using Model.Map.Terra;
using Model.Unit;
using Model.Unit.Enemy;
using Model.Unit.Player;
using System.Collections.Generic;
using System.Linq;

namespace Model {
    public class Level {

        public TerrainMap Map { get; private set; }

        private List<AbstractUnit> enemies = new List<AbstractUnit>();
        public IList<AbstractUnit> Enemies { get { return enemies; } }

        private List<AbstractUnit> playerArmy = new List<AbstractUnit>();
        public IList<AbstractUnit> PlayerArmy { get { return playerArmy; } }

        public Level() {
            Map =  CreateMap();
            CreateEnemies();
            CreatePlayerArmy();
            UpdateControl();
        }

        private TerrainMap CreateMap() {
            var terraMap = new TerrainMap(10, 10);
            var map = terraMap.Map;

            // TODO load map from file
            map[2, 9] = new WaterTerrain(2, 9);
            map[2, 8] = new WaterTerrain(2, 8);
            map[2, 7] = new WaterTerrain(2, 7);
            map[2, 6] = new WaterTerrain(2, 6);
            map[3, 5] = new WaterTerrain(3, 5);
            map[4, 5] = new WaterTerrain(4, 5);
            map[5, 4] = new WaterTerrain(5, 4);
            map[5, 3] = new WaterTerrain(5, 3);
            map[5, 2] = new WaterTerrain(5, 2);
            map[6, 1] = new WaterTerrain(6, 1);
            map[4, 0] = new WaterTerrain(4, 0);
            map[5, 0] = new WaterTerrain(5, 0);
            map[6, 0] = new WaterTerrain(6, 0);

            for (var x = 3; x < 10; x++) {
                for (var y = 6; y < 10; y++) {
                    map[x, y] = new CityTerrain(x, y);
                }
            }
            return terraMap;
        }

        private void CreateEnemies() {
            enemies = new List<AbstractUnit>() {
                new Bunker(7, 0),
                new Bunker(6, 3),
                new Bunker(9, 2),
                new AntiAir(6, 8),
                new House(4, 7),
                new House(7, 8),
                new House(6, 6),
                new House(5, 9)
            };
        }

        private void CreatePlayerArmy() {
            playerArmy = new List<AbstractUnit>() {
                new Airplane(1, 2),
                new Soldier(1, 1),
                new Soldier(2, 1),
                new Soldier(0, 3)
            };
        }

        public void NextTurn() {
            foreach (var unit in playerArmy) {
                unit.ResetMovements();
            }
            foreach (var unit in enemies) {
                unit.ResetMovements();
            }
        }

        public void UpdateControl() {
            foreach (var unit in playerArmy) {
                foreach (var terra in Map.GetTerrainsInRadius(unit.Coord, unit.ControlRadius)) {
                    terra.Control = ControlType.PLAYER;
                }
            }
            foreach (var unit in enemies) {
                foreach (var terra in Map.GetTerrainsInRadius(unit.Coord, unit.ControlRadius)) {
                    terra.Control = ControlType.ENEMY;
                }
            }

            foreach (var unit in playerArmy) {
                Map.Map[unit.Coord.X, unit.Coord.Y].Control = ControlType.PLAYER;
            }
            foreach (var unit in enemies) {
                Map.Map[unit.Coord.X, unit.Coord.Y].Control = ControlType.ENEMY;
            }

        }

        public AbstractUnit GetArmyUnitAt(HexCoord coord) {
            return playerArmy.FirstOrDefault<AbstractUnit>(unit => unit.Coord.Coord == coord.Coord);
        }

        public bool IsEmptyHex(int x, int y) {
            var unit = enemies.FirstOrDefault<AbstractUnit>(u => u.Coord.X == x && u.Coord.Y == y);
            if (unit != null) { return false; }

            unit = playerArmy.FirstOrDefault<AbstractUnit>(u => u.Coord.X == x && u.Coord.Y == y);
            return (unit == null);
        }

    }
}
