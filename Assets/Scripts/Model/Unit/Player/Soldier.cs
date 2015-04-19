using UnityEngine;
using System.Collections;

namespace Model.Unit.Player {
	public class Soldier : AbstractUnit {

        public Soldier(int x, int y) : base(x, y, 0, 0, 2) {
            IsGroundMove = true;
            IsEnemy = false;
        }

	}
}
