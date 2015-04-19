using UnityEngine;
using UnityEngine.UI;
using View.Controllers;

namespace View.GUI {
    public class UnitInfoController : MonoBehaviour {

        public CursorController cursor;
        public Text text;

        private UnitController unit;

        void Start() {
            cursor.OnUnitSelected += (u) => { unit = u; };
        }

        void Update() {
            if (unit != null) {
                var image = GetComponent<Image>();
                image.sprite = unit.GetComponent<SpriteRenderer>().sprite;
                image.color = unit.GetComponent<SpriteRenderer>().color;
                text.text = unit.Unit.ToString();
            }
        }

    }
}
