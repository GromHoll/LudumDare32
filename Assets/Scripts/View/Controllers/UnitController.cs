using Common;
using Model.Map;
using Model.Unit;
using Model.Unit.Enemy;
using System.Collections;
using UnityEngine;

namespace View.Controllers {
	public class UnitController : MonoBehaviour {

        public AbstractUnit Unit { get; set; }
        public AudioClip attackSound;
        public AudioClip moveSound;
        public AudioClip dieSound;
        public GameObject attackEffect;
        public GameObject dieEffect;

        void Start() {
            Unit.OnUnitMoved += Move;
            Unit.OnUnitDie += Die;
        }

        void Update() {
            transform.position = Unit.Coord.WorldCoord;
        }

        public void Attack(AbstractEnemy target) {
            var coord = target.Coord.WorldCoord;
            if (attackEffect != null) {
                GameObjectUtils.InstantiateChildForWorld(attackEffect, coord, gameObject, true);
            }
            if (attackSound != null) {
                AudioSource.PlayClipAtPoint(attackSound, coord);
            }
            Unit.Attack(target);
        }

        public void Move() {
            if (moveSound != null) {
                AudioSource.PlayClipAtPoint(moveSound, Vector3.zero);
            }
        }

        public void Die() {
            if (dieSound != null) {
                AudioSource.PlayClipAtPoint(dieSound, Vector3.zero);
            }
            if (dieEffect != null) {
                StartCoroutine("Explosion");
            }
        }

        private IEnumerator Explosion() {
            var go = GameObjectUtils.InstantiateChildForWorld(dieEffect, transform.position, gameObject, true);
            yield return new WaitForSeconds(2f);
            gameObject.SetActive(false);
        }

	}
}
