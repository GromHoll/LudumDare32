using Common;
using Model.Map;
using System.Collections;
using UnityEngine;

namespace View.Factories {
    public class TerrainFactory : MonoBehaviour {

        public GameObject blankHex;

        public void CreateTerrain(HexMap map) {
            foreach (var hex in map.Map) {
                GameObjectUtils.InstantiateChild(blankHex, hex.WorldCoord, gameObject);
            }
        }
    }
}
