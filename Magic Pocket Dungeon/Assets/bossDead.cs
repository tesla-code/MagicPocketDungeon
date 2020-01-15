using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossDead : StateMachineBehaviour
{
    GameObject boss;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //he's dead, disable the scripts and remove him after animation is complete
        Debug.Log("Boss has entered deadstate");
        boss = animator.gameObject;
        boss.GetComponentInParent<TriggerZoneAxe>().enabled = false;
        boss.GetComponentInParent<BoxCollider2D>().enabled = false;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //let the death animation play once and then gtfo
        if (stateInfo.normalizedTime >= 1)
        {
            //disappear for the time being
            boss.GetComponent<SpriteRenderer>().enabled = false;
            //set him to be dead 
            animator.gameObject.GetComponent<BossShowHP>().end = true;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

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
