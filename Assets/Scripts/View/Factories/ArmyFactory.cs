﻿using Common;
using Model.Unit;
using Model.Unit.Player;
using System.Collections.Generic;
using UnityEngine;

namespace View.Factories {
	public class ArmyFactory : MonoBehaviour {

        public GameObject airplane;
        public GameObject soldier;

        public void CreateArmy(IList<AbstractUnit> playerArmy) {
            foreach (var unit in playerArmy) {
                var prefab = GetPrefab(unit);
                var go = GameObjectUtils.InstantiateChild(prefab, unit.Coord.WorldCoord, gameObject);
            }
        }

        private GameObject GetPrefab(AbstractUnit unit) {
            if (unit is Soldier) { return soldier; }
            if (unit is Airplane) { return airplane; }
            return null;
        }


	}
}
