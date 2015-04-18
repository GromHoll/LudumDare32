using Common;
using Model.Unit;
using Model.Unit.Enemy;
using System.Collections.Generic;
using UnityEngine;

namespace View.Factories {
    public class StructuresFactory : MonoBehaviour {

        public GameObject house;
        public GameObject bunker;
        public GameObject antiAir;

        public void CreateStructures(IList<AbstractUnit> enemies) {
            foreach (var unit in enemies) {
                var prefab = GetPrefab(unit);
                var go = GameObjectUtils.InstantiateChild(prefab, unit.Coord.WorldCoord, gameObject);
            }
        }

        private GameObject GetPrefab(AbstractUnit unit) {
            if (unit is AntiAir) { return antiAir; }
            if (unit is Bunker) { return bunker; }
            if (unit is House) { return house; }
            return null;
        }

    }
}
