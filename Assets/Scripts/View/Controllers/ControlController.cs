using Model.Map;
using System.Collections;
using UnityEngine;
using Terra = Model.Map.Terrain;

namespace View.Controllers {
	public class ControlController : MonoBehaviour {

		public Color enemyColor;
        public Color playerColor;

        public Terra Terrain { get; set; }

        private SpriteRenderer renderer;

        public void Start() {
            renderer = GetComponent<SpriteRenderer>();
        }

		void Update() {
            if (Terrain.Control == ControlType.FREE) {
                renderer.enabled = false;
            } else {
                GetComponent<SpriteRenderer>().enabled = true;
                if (Terrain.Control == ControlType.ENEMY) {
                    renderer.color = enemyColor;
                } else {
                    renderer.color = playerColor;
                }
            }
		}
	}
}
