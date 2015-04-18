using Model.Map;
using Model.Unit;
using Model.Unit.Enemy;
using Model.Unit.Player;
using System.Collections.Generic;

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
            map[2, 9].Type = TerrainType.WATER;
            map[2, 8].Type = TerrainType.WATER;
            map[2, 7].Type = TerrainType.WATER;
            map[2, 6].Type = TerrainType.WATER;
            map[3, 5].Type = TerrainType.WATER;
            map[4, 5].Type = TerrainType.WATER;
            map[5, 4].Type = TerrainType.WATER;
            map[5, 3].Type = TerrainType.WATER;
            map[5, 2].Type = TerrainType.WATER;
            map[6, 1].Type = TerrainType.WATER;
            map[4, 0].Type = TerrainType.WATER;
            map[5, 0].Type = TerrainType.WATER;
            map[6, 0].Type = TerrainType.WATER;

            for (var x = 3; x < 10; x++) {
                for (var y = 6; y < 10; y++) {
                    map[x, y].Type = TerrainType.CITY;
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
                new Soldier(1, 3)
            };
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
        }
    }
}
