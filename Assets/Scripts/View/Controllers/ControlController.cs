using Model.Map;
using System.Collections;
using UnityEngine;
using Terra = Model.Map.Terrain;

namespace View.Controllers {
	public class ControlController : MonoBehaviour {

		public Color enemyColor;
        public Color playerColor;

        public Terra Terrain { get; set; }

		void Update() {
            if (Terrain.Control == ControlType.FREE) {
                GetComponent<SpriteRenderer>().enabled = false;
            } else {
                GetComponent<SpriteRenderer>().enabled = true;
                if (Terrain.Control == ControlType.ENEMY) {
                    GetComponent<SpriteRenderer>().color = enemyColor;
                } else {
                    GetComponent<SpriteRenderer>().color = playerColor;
                }
            }
		}
	}
}
