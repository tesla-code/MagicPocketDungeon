using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class deathAndRespawn : MonoBehaviour
{
    Animator animator;
    public bool iDied;
    Vector3 targetPosition;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {

        //do this nonsense once the death animator has finished playing
        if (iDied){
            SceneTransition.Transition(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Danger")){
            Debug.Log("made DANGEROUS contact");

            //set the dead bool to true
            if(gameObject.GetComponent<BoxCollider2D>().enabled == true)
                if (!animator.GetBool("Dead")){
                    animator.SetBool("Dead", true);
                }
        }
    }
}
