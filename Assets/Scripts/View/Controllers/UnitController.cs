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
        public GameObject attackEffect;

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

        public void Move(HexCoord coord) {
            if (moveSound != null) {
                AudioSource.PlayClipAtPoint(moveSound, Vector3.zero);
            }
            Unit.Move(coord);
        }

	}
}
