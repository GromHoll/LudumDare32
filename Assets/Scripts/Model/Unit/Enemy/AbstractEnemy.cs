using Model.Map;
using Model.Map.Terra;
using Model.Unit;
using Model.Unit.Structure;
using System;
using System.Collections.Generic;

namespace Model.Unit.Enemy {
	public abstract class AbstractEnemy : AbstractUnit, Connectable {

        public Connectable Up { get; set; }
        public Connectable UpLeft { get; set; }
        public Connectable UpRight { get; set; }
        public Connectable Down { get; set; }
        public Connectable DownLeft { get; set; }
        public Connectable DownRight { get; set; }

        public int ResistanceMax { get; protected set; }
        public int ResistanceCurrent { get; protected set; }
        public override int ControlRadius {
            get { return (ResistanceCurrent > 0) ? base.ControlRadius : 0;}
            set { base.ControlRadius = value; } }

        protected AbstractEnemy(int x, int y, int controlRadius, int attackRadius, string name) : base(x, y, controlRadius, attackRadius, 0, name) {
            ResistanceMax = 100;
            ResistanceCurrent = 100;
        }

        public void Hit(int resistance) {
            ResistanceCurrent = Math.Max(ResistanceCurrent - resistance, 0);
        }

        public override string ToString() {
            return "Unit: " + Name + "\n" +
            "Fraction: " + (IsEnemy ? "Enemy" : "Player")+ "\n" +
            "Resistance: " + ResistanceCurrent + "/" + ResistanceMax + "\n" +
            "Attack: " + AttackRadius + " hexs\n" +
            "Control: " + ControlRadius + " hexs";
        }

        public void CheckSupply() {
            if (ResistanceCurrent <= 0) { return; }

            var alreadyChecked = new List<Connectable>();
            if (!IsConnectedToWarehouse(this, alreadyChecked)) {
                Hit(10);
            }
        }

        private static bool IsConnectedToWarehouse(Connectable forCheck, List<Connectable> alreadyChecked) {
            if (forCheck == null) { return false; }

            alreadyChecked.Add(forCheck);
            if (forCheck is Warehouse) {
                if ((forCheck as Warehouse).ResistanceCurrent > 0) {
                    return true;
                } else {
                    return false;
                }
            }
            if (alreadyChecked.Contains(forCheck)) { return false; }
            if (forCheck is Road && (forCheck as Road).Terrain.Control == ControlType.PLAYER) { return false; }


            if (IsConnectedToWarehouse(forCheck.Up, alreadyChecked)) { return true; }
            if (IsConnectedToWarehouse(forCheck.UpRight, alreadyChecked)) { return true; }
            if (IsConnectedToWarehouse(forCheck.DownRight, alreadyChecked)) { return true; }
            if (IsConnectedToWarehouse(forCheck.Down, alreadyChecked)) { return true; }
            if (IsConnectedToWarehouse(forCheck.DownLeft, alreadyChecked)) { return true; }
            if (IsConnectedToWarehouse(forCheck.UpLeft, alreadyChecked)) { return true; }

            return false;
        }

	}
}
