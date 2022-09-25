using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupManager : MonoBehaviour {
	public void StartGame() {
		GameManager.instance.ChangeScene("Main");
	}
}
