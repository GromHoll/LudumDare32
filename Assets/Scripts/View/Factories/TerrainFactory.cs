using Common;
using Model.Map;
using Model.Map.Terra;
using System.Collections;
using UnityEngine;
using View.Controllers;
using Terra = Model.Map.Terra.Terrain;

namespace View.Factories {
    public class TerrainFactory : MonoBehaviour {

        public TerrainController cityTerrain;
        public TerrainController waterTerrain;
        public TerrainController groundTerrain;

        public ControlController control;

        public void CreateTerrain(TerrainMap map) {
            foreach (var terra in map.Map) {
                var prefab =  GetPrefab(terra);
                var go = GameObjectUtils.InstantiateChild(prefab.gameObject, terra.Coord.WorldCoord, gameObject);
                var controller = go.GetComponent<TerrainController>();
                controller.Terrain = terra;

                var controlGo = GameObjectUtils.InstantiateChild(control.gameObject, terra.Coord.WorldCoord, go);
                var controlController = controlGo.GetComponent<ControlController>();
                controlController.Terrain = terra;
            }
        }

        private TerrainController GetPrefab(Terra terrain) {
            if (terrain is CityTerrain) {return cityTerrain;}
            if (terrain is WaterTerrain) {return waterTerrain;}
            if (terrain is GroundTerrain) {return groundTerrain;}
            return null;
        }
    }
}
