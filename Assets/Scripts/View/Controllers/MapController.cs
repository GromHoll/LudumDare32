using Model;
using Model.Map;
using System.Collections;
using UnityEngine;
using View.Factories;

namespace View.Controllers {
    public class MapController : MonoBehaviour {

        public TerrainFactory terrainFactory;
        public StructuresFactory structuresFactory;
        public ArmyFactory armyFactory;

        public Level Level { get; set; }

        void Start() {
            Level = new Level();
            MoveMapToCenter(Level.Map);
            terrainFactory.CreateTerrain(Level.Map);
            structuresFactory.CreateStructures(Level.Enemies);
            armyFactory.CreateArmy(Level.PlayerArmy);
        }

        private void MoveMapToCenter(TerrainMap map) {
            Vector3 coord = map.Map[map.Width/2, map.Height/2].Coord.WorldCoord;
            coord.y -= HexCoord.Y_SHIFT;
            coord.x -= HexCoord.X_SHIFT;
            coord.z = -1;
            Camera.main.transform.position = coord;
        }
    }
}
