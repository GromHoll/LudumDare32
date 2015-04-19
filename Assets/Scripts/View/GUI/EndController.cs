using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace View.GUI {
	public class EndController : MonoBehaviour {

        public Text result;

        public void Finish(bool isWin) {
            result.text = isWin ? "Congratulations!" : "You are failed...";
            gameObject.SetActive(true);
        }

	}
}
