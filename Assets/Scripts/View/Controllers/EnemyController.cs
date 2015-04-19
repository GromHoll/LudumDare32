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
            enemy.OnShoot += Shoot;
        }

		void Update() {
            if (enemy.ResistanceCurrent == 0 && isAlive) {
                isAlive = false;
                GameObjectUtils.InstantiateChild(flag, transform.position, gameObject);
            }
		}

        void Shoot() {
            if (attackEffect != null) {
                StartCoroutine("Shooting");
            }
            if (attackSound != null) {
                AudioSource.PlayClipAtPoint(attackSound, enemy.Coord.WorldCoord);
            }
        }

        private IEnumerator Shooting() {
            var go = GameObjectUtils.InstantiateChildForWorld(attackEffect, enemy.Coord.WorldCoord, gameObject, true);
            yield return new WaitForSeconds(1.66f);
            GameObject.Destroy(go);
        }
	}
}
