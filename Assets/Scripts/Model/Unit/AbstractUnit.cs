using Model.Map;
using System.Collections;
using UnityEngine;

namespace Model.Unit {
    public abstract class AbstractUnit {

        public HexCoord Coord { get; private set; }
        public int ControlRadius { get; private set; }
        public int AttackRadius { get; private set; }
        public bool IsWaterMove { get; protected set; }
        public bool IsGroundMove { get; protected set; }

        protected AbstractUnit(int x, int y, int controlRadius, int attackRadius) {
            Coord = new HexCoord {X = x, Y = y};
            ControlRadius = controlRadius;
            AttackRadius = attackRadius;
            IsGroundMove = false;
            IsWaterMove = false;
        }

        public void Move(HexCoord coord) {
            Coord.X = coord.X;
            Coord.Y = coord.Y;
        }

    }
}
