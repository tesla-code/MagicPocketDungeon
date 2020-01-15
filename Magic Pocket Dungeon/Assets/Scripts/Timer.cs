using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public Text _timerText;
    string _minutes;
    string _seconds;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _minutes = ((int)Time.timeSinceLevelLoad / 60).ToString();
        _seconds = (Time.timeSinceLevelLoad % 60).ToString("f2");

        _timerText.text = _minutes + ":" + _seconds;


    }
}
