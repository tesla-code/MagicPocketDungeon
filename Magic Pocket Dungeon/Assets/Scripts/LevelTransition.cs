using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelTransition : MonoBehaviour {

    GameObject player;
    Scene scene;
    public bool ScriptsON;
    GameObject spawnTarget;
    GameObject MAPTARGET;
    public bool loading;
    public bool reload;
    public bool fading;
    public bool next = true;
    bool canFade = true;
    public enum Levels {Level1,Init,End};

    public Levels level;

    public Image FadeImg;
    public float fadeSpeed;
    public float repeat;
 
    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (canFade) {
            if (collision.name == "Player") {
                fading = true;
                player.isStatic = true;
            }
            canFade = false;
        }
    }
    private void Update() {
        if (fading) {
            fadeOut();
        }
    }

    private void fadeOut() {
        var tempColor = FadeImg.color;
        var tempAlpha = 0.995f;

        // If the fade is finished
        if ((int)(tempColor.a * 1000) == (int)(tempAlpha * 1000)) {
            //switch to target scene
            loading = true;
        }

        // Continue to fade
        tempColor.a = 1f;
        FadeImg.color = Color.Lerp(FadeImg.color, tempColor, fadeSpeed);
        if (loading) {
            Debug.Log("Loading??");
            //activates/deactivates the player depending on what's needed
            if (player != null)
            {
                player.isStatic = false;
                if (ScriptsON)
                {
                   // player.transform.position = player.GetComponent<playerController>().checkpoint;
                    player.GetComponent<Rigidbody2D>().isKinematic = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
                    player.GetComponent<BoxCollider2D>().enabled = true;
                    player.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    player.GetComponent<Rigidbody2D>().isKinematic = true;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
                    player.GetComponent<BoxCollider2D>().enabled = false;
                    player.GetComponent<SpriteRenderer>().enabled = false;
                    Debug.Log("It ain't active, chief!");
                }
            }
            //if you just need to reload the scene, cause you died.
            if (reload){
                SceneTransition.Transition(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
                reload = false;
            }
            else if (next){
                //Move to the next level, add orbs and all that shiz
                SceneTransition.Transition(level.ToString(), LoadSceneMode.Single);
                //add the currently collected orbs into your hoard.
                player.GetComponent<playerStats>().SetCollectedOrbs();
                loading = false;
            }
        }
    }
}
