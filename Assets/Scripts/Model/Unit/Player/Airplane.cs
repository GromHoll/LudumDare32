﻿using UnityEngine;
using System.Collections;

namespace Model.Unit.Player {
	public class Airplane : AbstractUnit {

        public Airplane(int x, int y) : base(x, y, 0, 0, 4, "Helicopter") {
            IsGroundMove = true;
            IsWaterMove = true;
            IsEnemy = false;
        }

	}
}
