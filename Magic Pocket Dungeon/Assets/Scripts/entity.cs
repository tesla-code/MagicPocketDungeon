using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entity : MonoBehaviour
{

    public int HP;
    //Dangerous environments
    private void OnCollisionEnter2D(Collision2D other){
        //Debug.Log("Entity is in collision");
        //if what it's colliding with is dangerous
    }

    public void takeDamage(int dmg){
       // Debug.Log("Entity is taking damage");
        //decrement HP
        if (HP > 0)
            HP -= dmg;
        //set HP back to null and call death
        if (HP <= 0){
            death();
        }
    }
    public void death(){
        var animator = GetComponentInChildren<Animator>();
        animator.SetBool("dead", true);
    }
}
