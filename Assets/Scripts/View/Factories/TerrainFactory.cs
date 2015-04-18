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

        public void CreateTerrain(TerrainMap map) {
            foreach (var terrain in map.Map) {
                var prefab =  GetPrefab(terrain);
                var go = GameObjectUtils.InstantiateChild(prefab.gameObject, terrain.Coord.WorldCoord, gameObject);
                var controller = go.GetComponent<TerrainController>();
                controller.Terrain = terrain;
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
