using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDead : StateMachineBehaviour
{
    GameObject player;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Player has entered deadstate");
        player = animator.gameObject;
        player.GetComponent<Rigidbody2D>().isKinematic = true;
        player.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        //disable controls
        player.GetComponent<BasicMovement>().enabled = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = animator.gameObject;
        //let the death animation play once and then gtfo
        if (stateInfo.normalizedTime >= 1){
            //disappear for the time being
            player.GetComponent<SpriteRenderer>().enabled = false;
            //you're not dead anymore
            animator.SetBool("Dead", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("Player is out of deadstate");
        animator.gameObject.GetComponent<deathAndRespawn>().iDied = true;
        player.GetComponent<Rigidbody2D>().isKinematic = false;
        player.GetComponent<BasicMovement>().enabled = true;
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
