using Model;
using Model.Map;
using System.Collections;
using UnityEngine;
using View.Factories;
using TerraType = Model.Map.TerrainType;

namespace View.Controllers {
    public class MapController : MonoBehaviour {

        public TerrainFactory terrainFactory;
        public StructuresFactory structuresFactory;

        void Start() {
            var level = new Level();
            MoveMapToCenter(level.Map);
            terrainFactory.CreateTerrain(level.Map);
            structuresFactory.CreateStructures(level.Enemies);
        }

        private void MoveMapToCenter(TerrainMap map) {
            Vector3 coord = map.Map[map.Width/2, map.Height/2].Coord.WorldCoord;
            coord.y -= HexCoord.Y_SHIFT;
            coord.x -= HexCoord.X_SHIFT;
            coord.z = -10;
            Camera.main.transform.position = coord;
        }

        void Update() {


        }
    }
}
