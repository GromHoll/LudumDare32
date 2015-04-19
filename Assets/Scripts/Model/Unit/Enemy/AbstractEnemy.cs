using Model.Map;
using Model.Unit;
using Model.Unit.Structure;
using System;

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
	}
}
