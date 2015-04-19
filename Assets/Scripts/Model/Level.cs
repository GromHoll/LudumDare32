using Model.Map;
using Model.Map.Terra;
using Model.Unit;
using Model.Unit.Enemy;
using Model.Unit.Player;
using Model.Unit.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model {
    public class Level {

        public TerrainMap Map { get; private set; }

        private List<AbstractEnemy> enemies = new List<AbstractEnemy>();
        public IList<AbstractEnemy> Enemies { get { return enemies; } }

        private List<AbstractUnit> playerArmy = new List<AbstractUnit>();
        public IList<AbstractUnit> PlayerArmy { get { return playerArmy; } }

        private List<Road> roads = new List<Road>();
        public IList<Road> Roads { get { return roads; } }

        public bool IsEnd {get; set; }
        public bool IsWin {get; set; }

        public Level() {
            Map =  CreateMap();
            CreateEnemies();
            CreateRoads();
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

        private void CreateRoads() {
            roads = new List<Road> {
                new Road(4, 3),
                new Road(4, 2),
                new Road(5, 1),
                new Road(6, 2),
                new Road(7, 2),
                new Road(8, 2),
                new Road(8, 1),
                new Road(7, 6),
                new Road(7, 7),
                new Road(5, 8),
                new Road(5, 7)
            };


            foreach (var road in roads) {
                road.Terrain = Map.Map[road.Coord.X, road.Coord.Y];
            }

            var connections = new List<Connectable>();
            connections.AddRange(roads.Cast<Connectable>());
            connections.AddRange(enemies.Cast<Connectable>());;

            foreach (var conn in connections) {
                foreach (var aroundConn in connections) {
                    if (conn.Coord.X == aroundConn.Coord.X) {
                        if (conn.Coord.Y == aroundConn.Coord.Y + 1) {
                            conn.Down = aroundConn;
                        }
                        if (conn.Coord.Y == aroundConn.Coord.Y - 1){
                            conn.Up = aroundConn;
                        }

                    }

                    if (conn.Coord.X%2 == 0) {
                        if (conn.Coord.X == aroundConn.Coord.X - 1) {
                            if (conn.Coord.Y == aroundConn.Coord.Y) {
                                conn.UpRight = aroundConn;
                            }
                            if (conn.Coord.Y == aroundConn.Coord.Y + 1) {
                                conn.DownRight = aroundConn;
                            }
                        }
                        if (conn.Coord.X == aroundConn.Coord.X + 1) {
                            if (conn.Coord.Y == aroundConn.Coord.Y) {
                                conn.UpLeft = aroundConn;
                            }
                            if (conn.Coord.Y == aroundConn.Coord.Y + 1) {
                                conn.DownLeft = aroundConn;
                            }
                        }
                    }

                    if (conn.Coord.X%2 == 1) {
                        if (conn.Coord.X == aroundConn.Coord.X - 1) {
                            if (conn.Coord.Y == aroundConn.Coord.Y) {
                                conn.DownRight = aroundConn;
                            }
                            if (conn.Coord.Y == aroundConn.Coord.Y - 1) {
                                conn.UpRight = aroundConn;
                            }
                        }
                        if (conn.Coord.X == aroundConn.Coord.X + 1) {
                            if (conn.Coord.Y == aroundConn.Coord.Y) {
                                conn.DownLeft = aroundConn;
                            }
                            if (conn.Coord.Y == aroundConn.Coord.Y - 1) {
                                conn.UpLeft = aroundConn;
                            }
                        }
                    }
                }
            }
        }

        private void CreateEnemies() {
            enemies = new List<AbstractEnemy>() {
                new Bunker(7, 0),
                new Bunker(6, 3),
                new Bunker(9, 2),
                new AntiAir(6, 8),
                new House(4, 7),
                new House(7, 8),
                new House(6, 6),
                new House(5, 9) ,
                new Warehouse(4, 4),
                new Warehouse(8, 6)
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

        public void Move(AbstractUnit unit, HexCoord target) {
            unit.Move(target);

            foreach (var enemy in enemies) {
                var distance = unit.Coord.WorldDistance(enemy.Coord);
                var shooted = distance < (enemy.AttackRadius + 0.1f);
                if (shooted) {
                    if (unit is Airplane && enemy is AntiAir && enemy.ResistanceCurrent > 0) {
                        unit.IsDead = true;
                        enemy.Shooting();
                        playerArmy.Remove(unit);
                        break;
                    } else if (unit is Soldier && enemy is Bunker && enemy.ResistanceCurrent > 0) {
                        unit.IsDead = true;
                        enemy.Shooting();
                        playerArmy.Remove(unit);
                        break;
                    }
                }
            }
            Debug.Log("Army " + playerArmy.Count);
            UpdateControl();
            CheckEnd();
        }

        public void NextTurn() {
            foreach (var unit in playerArmy) {
                unit.ResetMovements();
            }

            foreach (var enemy in enemies) {
                enemy.CheckSupply();
            }
            CheckEnd();
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

        public void CheckEnd() {
            if (playerArmy.Count == 0) {
                IsEnd = true;
                IsWin = false;
            }
            if (enemies.All(unit => unit.ResistanceCurrent <= 0 || unit is Warehouse)) {
                IsEnd = true;
                IsWin = true;
            }
        }

        public AbstractUnit GetArmyUnitAt(HexCoord coord) {
            return playerArmy.FirstOrDefault<AbstractUnit>(unit => unit.Coord.Coord == coord.Coord);
        }

        public AbstractUnit GetEnemyUnitAt(int x, int y) {
            return enemies.FirstOrDefault<AbstractEnemy>(unit => unit.Coord.X == x && unit.Coord.Y == y);
        }

        public bool IsEmptyHex(int x, int y) {
            var enemyUnit = enemies.FirstOrDefault<AbstractEnemy>(u => u.Coord.X == x && u.Coord.Y == y);
            if (enemyUnit != null) { return false; }

            var playerUnit = playerArmy.FirstOrDefault<AbstractUnit>(u => u.Coord.X == x && u.Coord.Y == y);
            return (playerUnit == null);
        }

    }
}
