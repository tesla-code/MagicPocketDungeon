using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour {

    public Image FadeImg;
    public float fadeSpeed;
    public float repeat;
    bool fading;

    private void Start() {
        FadeImg.enabled = true;
        fading = true;
    }

    private void fadeIn() {
        var tempColor = FadeImg.color;
        var tempAlpha = 0.005f;

        // If the fade is finished
        if ((int)(tempColor.a * 1000) == (int)(tempAlpha * 1000)) {
            Destroy(gameObject);
        }

        tempColor.a = 0f;
        FadeImg.color = Color.Lerp(FadeImg.color, tempColor, fadeSpeed);
    }
    private void Update() {
        if (fading) {
            fadeIn();
        }
    }
}
