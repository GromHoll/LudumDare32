using UnityEngine;
using System.Collections;

namespace View.Controllers {
	public class CameraController : MonoBehaviour {

        public float speed = 10;

        private bool up;
        private bool left;
        private bool down;
        private bool right;


		void Update() {
            up    = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
            left  = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
            down  = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
            right = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);



            gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, GetTargetPosition(), Time.deltaTime*speed);
		}

        private Vector3 GetTargetPosition() {
            var pos = gameObject.transform.position;
            pos.y += up ? 1 : 0;
            pos.y -= down ? 1 : 0;
            pos.x -= left ? 1 : 0;
            pos.x += right ? 1 : 0;
            return pos;
        }


	}
}
