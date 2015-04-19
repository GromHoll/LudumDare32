using Model;
using Model.Map;
using Model.Unit.Structure;
using System.Collections;
using System.Linq;
using UnityEngine;
using View.Factories;
using View.GUI;

namespace View.Controllers {
    public class MapController : MonoBehaviour {

        public TerrainFactory terrainFactory;
        public StructuresFactory structuresFactory;
        public ArmyFactory armyFactory;
        public RoadFactory roadFactory;

        public EndController end;

        public Level Level { get; set; }

        void Start() {
            Level = new Level();
            MoveMapToCenter(Level.Map);
            terrainFactory.CreateTerrain(Level.Map);
            structuresFactory.CreateStructures(Level.Enemies);
            armyFactory.CreateArmy(Level.PlayerArmy);
            armyFactory.CreateArmy(Level.PlayerArmy);
            roadFactory.CreateRoad(Level.Roads.Cast<Connectable>());
            roadFactory.CreateRoad(Level.Enemies.Cast<Connectable>());
        }

        void Update() {
            if (Level.IsEnd && !end.isActiveAndEnabled) {
                end.Finish(Level.IsWin);
            }
        }

        private void MoveMapToCenter(TerrainMap map) {
            Vector3 coord = map.Map[map.Width/2, map.Height/2].Coord.WorldCoord;
            coord.y -= HexCoord.Y_SHIFT;
            coord.x -= HexCoord.X_SHIFT;
            coord.z = -1;
            Camera.main.transform.position = coord;
        }

        public void NextTurn() {
            Level.NextTurn();
        }

    }
}
