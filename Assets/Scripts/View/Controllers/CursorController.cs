using UnityEditor;
using UnityEngine;

namespace View.Controllers {
    public class CursorController : MonoBehaviour {

        private SpriteRenderer renderer;

        public void Start() {
            renderer = GetComponent<SpriteRenderer>();
        }

        public void Update() {
            if (Input.GetMouseButtonDown(0)) {


                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);
                if (hit.collider != null) {
                    transform.position = hit.collider.transform.position;
                    renderer.enabled = true;
                }
            } else if (Input.GetMouseButtonDown(1)) {
                renderer.enabled = false;
            }


        }

    }
}