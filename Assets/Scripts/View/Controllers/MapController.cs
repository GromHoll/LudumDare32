using Model.Map;
using System.Collections;
using UnityEngine;
using View.Factories;
using TerraType = Model.Map.TerrainType;

namespace View.Controllers {
    public class MapController : MonoBehaviour {

        public TerrainFactory terrainFactory;

        void Start() {
            var map = CreteMap();
            MoveMapToCenter(map);
            terrainFactory.CreateTerrain(map);
        }

        private TerrainMap CreteMap() {
            var terraMap = new TerrainMap(10, 10);
            var map = terraMap.Map;

            // TODO load map from file
            map[2, 9].Type = TerraType.WATER;
            map[2, 8].Type = TerraType.WATER;
            map[2, 7].Type = TerraType.WATER;
            map[2, 6].Type = TerraType.WATER;
            map[3, 5].Type = TerraType.WATER;
            map[4, 5].Type = TerraType.WATER;
            map[5, 4].Type = TerraType.WATER;
            map[5, 3].Type = TerraType.WATER;
            map[5, 2].Type = TerraType.WATER;
            map[5, 1].Type = TerraType.WATER;
            map[6, 1].Type = TerraType.WATER;
            map[4, 0].Type = TerraType.WATER;
            map[5, 0].Type = TerraType.WATER;
            map[6, 0].Type = TerraType.WATER;

            for (int x = 3; x < 10; x++) {
                for (int y = 6; y < 10; y++) {
                    map[x, y].Type = TerraType.CITY;
                }
            }

            return terraMap;
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
