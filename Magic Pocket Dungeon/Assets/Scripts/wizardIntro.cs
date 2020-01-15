using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizardIntro : MonoBehaviour
{
    public bool end;
    [SerializeField]GameObject transition;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (end){
            transition.GetComponent<LevelTransition>().level = LevelTransition.Levels.Level1;
            transition.GetComponent<LevelTransition>().fading = true;
        }
    }
}
