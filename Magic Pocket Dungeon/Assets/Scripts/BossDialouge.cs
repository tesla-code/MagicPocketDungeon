using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class BossDialouge : MonoBehaviour
{

    [SerializeField]
    GameObject _player;
    bool hasBeenDisplayed = false;

    [SerializeField]
    GameObject _panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(_player.transform.position, transform.position);

        if(hasBeenDisplayed == false && dist < 12)
        {
            hasBeenDisplayed = true;
            _panel.SetActive(true);
        }

    }
}
