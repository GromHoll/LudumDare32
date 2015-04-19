using Model.Unit.Enemy;
using System.Collections;
using UnityEngine;

namespace Model.Unit.Player {
	public class Soldier : AbstractUnit {

        public Soldier(int x, int y) : base(x, y, 0, 0, 2, "Soldier") {
            IsGroundMove = true;
            IsEnemy = false;
        }

        public override void Attack(AbstractEnemy target) {}

	}
}
