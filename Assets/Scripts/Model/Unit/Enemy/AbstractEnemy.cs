using Model.Unit;
using System;

namespace Model.Unit.Enemy {
	public abstract class AbstractEnemy : AbstractUnit {

        public int ResistanceMax { get; protected set; }
        public int ResistanceCurrent { get; protected set; }

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
	}
}
