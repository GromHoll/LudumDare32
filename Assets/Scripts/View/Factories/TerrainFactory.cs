using Common;
using Model.Map;
using System.Collections;
using UnityEngine;
using View.Controllers;
using Terra = Model.Map.Terrain;

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
            switch (terrain.Type) {
                case TerrainType.CITY: return cityTerrain;
                case TerrainType.WATER: return waterTerrain;
                case TerrainType.GROUND: return groundTerrain;
            }
            return null;
        }
    }
}
