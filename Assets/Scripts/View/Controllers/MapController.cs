using Model.Map;
using System.Collections;
using UnityEngine;
using View.Factories;

namespace View.Controllers {
    public class MapController : MonoBehaviour {

        public TerrainFactory terrainFactory;

        void Start() {

            var map = new HexMap(10, 10);
            terrainFactory.CreateTerrain(map);

            Vector3 coord = map.Map[map.Width/2, map.Height/2].WorldCoord;
            coord.y -= Hex.Y_SHIFT;
            coord.x -= Hex.X_SHIFT;
            coord.z = -10;
            Camera.main.transform.position = coord;

        }

        void Update() {


        }
    }
}
