using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public static class SceneTransition {
    public static void Transition (string scene, LoadSceneMode mode) {
        SceneManager.LoadSceneAsync(scene, mode);
    }
}
