using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShowHP : MonoBehaviour
{
    [SerializeField] string name;
    [SerializeField] Texture2D healthTexture;
    [SerializeField] float HP;
    [SerializeField] float damagePerSecond;
    Animator animator;
    [SerializeField] GameObject transition;
    public bool end;
    bool decrease;

    private void Start(){
        animator = GetComponent<Animator>();
        if (HP == 0)
            HP = 200;
        if (damagePerSecond == 0)
            damagePerSecond = 0.1f;
    }
    private void Update(){
        if (HP > 0) {
            if(decrease)
                HP -= damagePerSecond;
        }
        else{
            animator.SetBool("death", true);
        }
        if(end){
            Debug.Log("Game End");
            transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.End;
            transition.GetComponent<LevelTransition>().fading = true;
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == GameObject.FindGameObjectWithTag("Player")){
            decrease = true;
        }
    }
    void OnGUI(){
        if (decrease){
            GUI.Label(new Rect(400, 20, 50, 50), name);
            for (int i = 1; i <= HP; i++)
            {
                GUI.DrawTexture(new Rect((450 + i), 20, 50, 50), healthTexture);
            }
        }

    }
   
}
