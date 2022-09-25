using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour {
    public void LoadSetup() {
        GameManager.instance.ChangeScene("Setup");
	}
}
