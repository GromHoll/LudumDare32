using Common;
using Model.Map;
using System.Collections;
using UnityEngine;
using Terra = Model.Map.Terrain;

namespace View.Factories {
    public class TerrainFactory : MonoBehaviour {

        public GameObject cityTerrain;
        public GameObject waterTerrain;
        public GameObject groundTerrain;


        public void CreateTerrain(TerrainMap map) {
            foreach (var terrain in map.Map) {
                var prefab =  GetPrefab(terrain);
                GameObjectUtils.InstantiateChild(prefab, terrain.Coord.WorldCoord, gameObject);
            }
        }

        private GameObject GetPrefab(Terra terrain) {
            switch (terrain.Type) {
                case TerrainType.CITY: return cityTerrain;
                case TerrainType.WATER: return waterTerrain;
                case TerrainType.GROUND: return groundTerrain;
            }
            return null;
        }
    }
}
