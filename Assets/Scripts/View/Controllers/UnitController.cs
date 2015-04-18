using Model.Unit;
using System.Collections;
using UnityEngine;

namespace View.Controllers {
	public class UnitController : MonoBehaviour {

        public AbstractUnit Unit { get; set; }

        void Update() {
            transform.position = Unit.Coord.WorldCoord;
        }

	}
}
