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
        public bool IsEnemy { get; protected set; }
        public int CurrentMovements { get; protected set; }
        public int TotalMovements { get; protected set; }
        public string Name { get; protected set; }

        protected AbstractUnit(int x, int y, int controlRadius, int attackRadius, int movements, string name) {
            Coord = new HexCoord {X = x, Y = y};
            CurrentMovements = movements;
            TotalMovements = movements;
            ControlRadius = controlRadius;
            AttackRadius = attackRadius;
            IsGroundMove = false;
            IsWaterMove = false;
            IsEnemy = true;
            Name = name;
        }

        public void Move(HexCoord coord) {
            if (CurrentMovements > 0) {
                CurrentMovements--;
                Coord.X = coord.X;
                Coord.Y = coord.Y;
            }
        }

        public void ResetMovements() {
            CurrentMovements = TotalMovements;
        }

        public string ToString() {
            return "Unit: " + Name + "\n" +
                   "Fraction: " + (IsEnemy ? "Enemy" : "Player")+ "\n" +
                   "Movements: " + CurrentMovements + "/" + TotalMovements + "\n" +
                   "Attack: " + AttackRadius + " hexs\n" +
                   "Control: " + ControlRadius + " hexs\n" +
                   "Water move: " + IsWaterMove + "\n" +
                   "Ground move: " + IsGroundMove + "\n";
        }
    }
}
