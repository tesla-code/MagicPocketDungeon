using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    bool pickUp;
    bool effectInPlace = false;
    //the potion has multiple functions, choose one with an enumerator value, they change the player's properties in x seconds
    [SerializeField] enum Effect {Jump, Run, Fly, Invincible, Heavy};
    [SerializeField] Effect effect;
    GameObject player;
    float j, s;
    [SerializeField] float countdown;
    float maxCountdown;

    private void Start()
    {
        maxCountdown = countdown;
    }
    //???????
    // Update is called once per frame
    void Update(){
        //if a player touches me, activate my shizzle fo nizzle
        //for a set amount of time (customizable) do the effect, keep the original values stored somewhere , and re-apply them once done
        if (pickUp){
            potionEffect();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.FindGameObjectWithTag("Player")){
            player = collision.gameObject;
            pickUp = true;
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            //hide the effect as well
            gameObject.transform.GetChild(0).gameObject.SetActive(false);

            //Activate the effect on the player, change the color in the cases depending on the type
            player.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    void potionEffect(){
        switch(effect){
            //get extra jump height
            case Effect.Jump:{
                //make sure j is only set to the original height, no bullshit
                if (!effectInPlace){
                    Debug.Log("Effect is being applied");
                    j = player.GetComponent<BasicMovement>().getJumpHeight();
                    //twice the normal jump height
                    player.GetComponent<BasicMovement>().setJumpHeight(j * 1.5f);
                    effectInPlace = true;
                    player.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.2f,3,0.2f,1);
                }
                //start the countdown, and reset the value after it reaches 0
                countdown -= Time.deltaTime;
                //Reset that shit
                if(countdown <= 0){
                    //only reset the value once
                    player.GetComponent<BasicMovement>().setJumpHeight(j);

                }
            break;
            }
            //Run faster 
            case Effect.Run:{
                //make sure j is only set to the original height, no bullshit
                if (!effectInPlace){
                    Debug.Log("Effect is being applied");
                    j = player.GetComponent<BasicMovement>().getWalkSpeed();
                    //twice the normal run speed
                    player.GetComponent<BasicMovement>().setWalkSpeed(j * 1.5f);
                    effectInPlace = true;
                    player.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = new Color(3, 0.2f, 0.2f, 1);
                }
                //start the countdown, and reset the value after it reaches 0
                countdown -= Time.deltaTime;
                //Reset that shit
                if (countdown <= 0){
                    player.GetComponent<BasicMovement>().setWalkSpeed(j);
                }
            break;
            }
            //Fly (duh)
            case Effect.Fly:{
                //make sure j is only set to the original height, no bullshit
                if (!effectInPlace)
                {
                    Debug.Log("Effect is being applied");
                    //HE CAN FLY
                    player.GetComponent<BasicMovement>().canFly = true;
                    effectInPlace = true;
                    player.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = new Color(0.2f, 0.2f, 3, 1);
                }
                //start the countdown, and reset the value after it reaches 0
                countdown -= Time.deltaTime;
                //Reset that shit
                if (countdown <= 0){
                    player.GetComponent<BasicMovement>().canFly = false;
                }
            break;
            }
            //Become invincible
            case Effect.Invincible:{
                //make sure j is only set to the original height, no bullshit
                if (!effectInPlace)
                {
                    Debug.Log("Effect is being applied");
                    //he can't be touched
                    player.GetComponent<BoxCollider2D>().enabled = false;
                    effectInPlace = true;
                    player.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = new Color(1, 1, 1, 1);
                }
                //start the countdown, and reset the value after it reaches 0
                countdown -= Time.deltaTime;
                //Reset that shit
                if (countdown <= 0){
                    player.GetComponent<BoxCollider2D>().enabled = true;
                }
            break;
            }
            case Effect.Heavy:{
                //make sure j is only set to the original height, no bullshit
                if (!effectInPlace)
                {
                    Debug.Log("Effect is being applied");
                    s = player.GetComponent<BasicMovement>().getWalkSpeed();
                    j = player.GetComponent<BasicMovement>().getJumpHeight();
                     //less than half the normal run speed
                    player.GetComponent<BasicMovement>().setWalkSpeed(s * 0.3f);
                    player.GetComponent<BasicMovement>().setJumpHeight(j * 0.3f);

                    effectInPlace = true;
                    player.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().startColor = new Color(3, 0.2f, 3f, 1);
                }
                //start the countdown, and reset the value after it reaches 0
                countdown -= Time.deltaTime;
                //Reset that shit
                if (countdown <= 0)
                {
                        player.GetComponent<BasicMovement>().setWalkSpeed(s);
                        player.GetComponent<BasicMovement>().setJumpHeight(j);
                }
            break;
            }
        }
        if (countdown <= 0){
            //do this after everything is done
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider2D>().enabled = true;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //you can pick it up again
            pickUp = false;
            effectInPlace = false;
            player.transform.GetChild(1).gameObject.SetActive(false);
            Debug.Log("countdown end, the potion has respawned");
            countdown = maxCountdown;
        }
    }
}
