using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager instance = null;

	private void Awake() {
        DontDestroyOnLoad(gameObject);
	}

	void Start() {
        if (instance == null) instance = this;
        else if (instance == this) Destroy(gameObject);
    }

    public void UpdateBGColor() { 
        // updates bg color
    }

    public void ChangeScene(string sceneName) {
        SceneManager.LoadScene(sceneName);
    }
}
