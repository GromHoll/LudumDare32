using Model.Map;
using Model.Unit;
using System.Collections;
using UnityEngine;

namespace View.Controllers {
	public class UnitController : MonoBehaviour {

        public AbstractUnit Unit { get; set; }
        public AudioClip attackSound;
        public AudioClip moveSound;

        void Update() {
            transform.position = Unit.Coord.WorldCoord;
        }

        public void Attack() {
            AudioSource.PlayClipAtPoint(attackSound, Vector3.zero);
            Unit.Attack();
        }

        public void Move(HexCoord coord) {
            AudioSource.PlayClipAtPoint(moveSound, Vector3.zero);
            Unit.Move(coord);
        }

	}
}
