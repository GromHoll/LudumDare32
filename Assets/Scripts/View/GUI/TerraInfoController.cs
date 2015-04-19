using UnityEngine;
using UnityEngine.UI;
using View.Controllers;

namespace View.GUI {
    public class TerraInfoController : MonoBehaviour {

        public CursorController cursor;
        public Text text;

        private TerrainController terrain;

        void Start() {
            cursor.OnTerraSelected += (terra) => { terrain = terra; };
        }

        void Update() {
            if (terrain != null) {
                var image = GetComponent<Image>();
                image.sprite = terrain.GetComponent<SpriteRenderer>().sprite;
                image.color = terrain.GetComponent<SpriteRenderer>().color;
                text.text = terrain.Terrain.ToString();
            }
        }

    }
}
