using Common;
using Model.Unit.Structure;
using System.Collections.Generic;
using UnityEngine;

namespace View.Factories {
    public class RoadFactory : MonoBehaviour {

        public GameObject roadPref;
        public GameObject roadMainPref;

        public void CreateRoad(IList<Road> roads) {
            foreach (var road in roads) {
                var roadGo = GameObjectUtils.InstantiateChild(roadMainPref, road.Coord.WorldCoord, gameObject);

                if (road.Up != null) {
                    GameObjectUtils.InstantiateChild(roadPref, road.Coord.WorldCoord, roadGo);
                }
                if (road.UpLeft != null) {
                    var go = GameObjectUtils.InstantiateChild(roadPref, road.Coord.WorldCoord, roadGo);
                    go.transform.Rotate(0, 0, 60);
                }
                if (road.DownLeft != null) {
                    var go = GameObjectUtils.InstantiateChild(roadPref, road.Coord.WorldCoord, roadGo);
                    go.transform.Rotate(0, 0, 120);
                }
                if (road.Down != null) {
                    var go = GameObjectUtils.InstantiateChild(roadPref, road.Coord.WorldCoord, roadGo);
                    go.transform.Rotate(0, 0, 180);
                }
                if (road.DownRight != null) {
                    var go = GameObjectUtils.InstantiateChild(roadPref, road.Coord.WorldCoord, roadGo);
                    go.transform.Rotate(0, 0, 240);
                }
                if (road.UpRight != null) {
                    var go = GameObjectUtils.InstantiateChild(roadPref, road.Coord.WorldCoord, roadGo);
                    go.transform.Rotate(0, 0, 300);
                }
            }
        }

    }
}
