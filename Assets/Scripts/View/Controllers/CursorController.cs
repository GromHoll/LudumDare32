using Model;
using Model.Map;
using UnityEditor;
using UnityEngine;

namespace View.Controllers {
    public class CursorController : MonoBehaviour {

        private SpriteRenderer renderer;
        public MapController map;

        public GameObject upCursor;
        public GameObject upRightCursor;
        public GameObject downRightCursor;
        public GameObject downCursor;
        public GameObject downLeftCursor;
        public GameObject upLeftCursor;

        public void Start() {
            renderer = GetComponent<SpriteRenderer>();
        }

        public void Update() {
            if (Input.GetMouseButtonDown(0)) {
                var hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);
                if (hit.collider != null) {
                    var terra = hit.collider.GetComponent<TerrainController>();
                    renderer.enabled = true;
                    transform.position = terra.Terrain.Coord.WorldCoord;
                    UpdateRoundCursors(terra.Terrain.Coord);
                }
            } else if (Input.GetMouseButtonDown(1)) {
                renderer.enabled = false;
            }
        }

        private void UpdateRoundCursors(HexCoord coord) {
            UpdateRoundCursor(coord.X,     coord.Y + 1,               upCursor);
            UpdateRoundCursor(coord.X + 1, coord.Y + coord.X%2,       upRightCursor);
            UpdateRoundCursor(coord.X + 1, coord.Y - (coord.X + 1)%2, downRightCursor);
            UpdateRoundCursor(coord.X,     coord.Y - 1,               downCursor);
            UpdateRoundCursor(coord.X - 1, coord.Y + coord.X%2,       upLeftCursor);
            UpdateRoundCursor(coord.X - 1, coord.Y - (coord.X + 1)%2, downLeftCursor);
        }

        private void UpdateRoundCursor(int x, int y, GameObject cursor) {
            var renderer = cursor.GetComponent<SpriteRenderer>();
            if (x < 0 || x >= map.Level.Map.Width || y < 0 || y >= map.Level.Map.Height) {
                renderer.enabled = false;
            } else {
                renderer.enabled = true;
            }
        }

    }
}