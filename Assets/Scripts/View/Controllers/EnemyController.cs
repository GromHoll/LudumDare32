using Common;
using Model.Unit.Enemy;
using System.Collections;
using UnityEngine;

namespace View.Controllers {
	public class EnemyController : UnitController {

        public GameObject flag;

        private AbstractEnemy enemy;
        private bool isAlive = true;

        void Start() {
            enemy = (AbstractEnemy) Unit;
        }

		void Update() {
            if (enemy.ResistanceCurrent == 0 && isAlive) {
                isAlive = false;
                GameObjectUtils.InstantiateChild(flag, transform.position, gameObject);
            }
		}
	}
}
