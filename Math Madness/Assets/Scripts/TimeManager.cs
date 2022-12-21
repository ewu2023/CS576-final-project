using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        if (scene.name == "level") {
            // Ensure time scale is set to 1 to start
            Time.timeScale = 1.0f;
        }
    }
}
