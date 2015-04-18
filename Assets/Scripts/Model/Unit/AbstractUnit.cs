using Model.Map;
using System.Collections;
using UnityEngine;

namespace Model.Unit {
    public abstract class AbstractUnit {

        public HexCoord Coord { get; private set; }
        public int ControlRadius { get; private set; }
        public int AttackRadius { get; private set; }

        protected AbstractUnit(int x, int y, int controlRadius, int attackRadius) {
            Coord = new HexCoord {X = x, Y = y};
            ControlRadius = controlRadius;
            AttackRadius = attackRadius;
        }

    }
}
