using Model;
using Model.Map;
using Model.Unit;
using UnityEditor;
using UnityEngine;

namespace View.Controllers {
    public class CursorController : MonoBehaviour {

        private int TERRA_MASK;
        private int UNIT_MASK;

        public delegate void SelectedUnit(UnitController unit);
        public event SelectedUnit OnUnitSelected;

        public delegate void SelectedTerra(TerrainController terra);
        public event SelectedTerra OnTerraSelected;

        public MapController map;

        public GameObject upCursor;
        public GameObject upRightCursor;
        public GameObject downRightCursor;
        public GameObject downCursor;
        public GameObject downLeftCursor;
        public GameObject upLeftCursor;

        private SpriteRenderer renderer;
        private UnitController selectedUnit;

        public void Start() {
            TERRA_MASK = 1 << LayerMask.NameToLayer("Terra");
            UNIT_MASK = 1 << LayerMask.NameToLayer("Unit");
            renderer = GetComponent<SpriteRenderer>();
            Unselect();
        }

        public void Update() {
			if (Input.GetMouseButtonDown(0)) {
				var terraHit = Raycast(TERRA_MASK);
                if (terraHit.collider != null) {
                    var terra = terraHit.collider.GetComponent<TerrainController>();
                    renderer.enabled = true;
                    transform.position = terra.Terrain.Coord.WorldCoord;

                    var unitHit = Raycast(UNIT_MASK);
                    if (unitHit.collider != null) {
                        var unit = unitHit.collider.GetComponent<UnitController>();
                        SelectUnit(unit);
                    } else {
                        if (selectedUnit != null) {
                            if (IsHexAroundSelection(terra.Terrain.Coord)) {
                                Debug.Log("Around");
                                selectedUnit.Unit.Move(terra.Terrain.Coord);
                                map.Level.UpdateControl();
                                SelectUnit(selectedUnit);
                            } else {
                                Debug.Log("Not around");
                                UnselectUnit();
                            }
                        } else {
                            UnselectUnit();
                        }
                    }
                }
            } else if (Input.GetMouseButtonDown(1)) {
                Unselect();
            }
        }

        private RaycastHit2D Raycast(int mask) {
			var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			return Physics2D.Raycast(pos, Vector3.forward, Mathf.Infinity, mask);
        }

        private void Unselect() {
            renderer.enabled = false;
            UnselectUnit();
        }

        private void SelectUnit(UnitController unit) {
            if (unit.Unit.IsEnemy) {
                UnselectUnit();
            } else {
                selectedUnit = unit;
                var coord = selectedUnit.Unit.Coord;
                UpdateWayHex(upCursor,          coord.X,     coord.Y + 1                );
                UpdateWayHex(upRightCursor,     coord.X + 1, coord.Y + coord.X%2        );
                UpdateWayHex(downRightCursor,   coord.X + 1, coord.Y - (coord.X + 1)%2  );
                UpdateWayHex(downCursor,        coord.X,     coord.Y - 1                );
                UpdateWayHex(upLeftCursor,      coord.X - 1, coord.Y + coord.X%2        );
                UpdateWayHex(downLeftCursor,    coord.X - 1, coord.Y - (coord.X + 1)%2  );
            }

            if (OnUnitSelected != null) { OnUnitSelected(unit); }
        }

        private void UpdateWayHex(GameObject cursor, int x, int y) {
            var renderer = cursor.GetComponent<SpriteRenderer>();
            renderer.enabled = IsRoundCursorNeedsShow(x, y);
        }

        private bool IsRoundCursorNeedsShow(int x, int y) {
            if (x < 0 || x >= map.Level.Map.Width || y < 0 || y >= map.Level.Map.Height) {
                return false;
            }
            var terra = map.Level.Map.Map[x, y];
            if (!terra.IsAvailableForUnit(selectedUnit.Unit)) {
                return false;
            }
            return map.Level.IsEmptyHex(x, y);
        }

        private void UnselectUnit() {
            upCursor.GetComponent<SpriteRenderer>().enabled = false;
            upRightCursor.GetComponent<SpriteRenderer>().enabled = false;
            downRightCursor.GetComponent<SpriteRenderer>().enabled = false;
            downCursor.GetComponent<SpriteRenderer>().enabled = false;
            upLeftCursor.GetComponent<SpriteRenderer>().enabled = false;
            downLeftCursor.GetComponent<SpriteRenderer>().enabled = false;
            selectedUnit = null;
        }

        private bool IsHexAroundSelection(HexCoord coord) {
            var distance = coord.WorldDistance(selectedUnit.Unit.Coord);
            var terra = map.Level.Map.Map[coord.X, coord.Y];
            return distance > 0.5f && distance < 1.1f && terra.IsAvailableForUnit(selectedUnit.Unit);
        }

    }
}