using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudPlatform : MonoBehaviour
{
    [SerializeField]
    float _sum = 0f;
    float _sum2 = 0f;
    float _platformSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (_sum > 6.0)
        {
            Vector2 position = transform.position;
            position.x = position.x - _platformSpeed;
            transform.position = position;

            _sum2 += _platformSpeed;

            if(_sum2 > 6.0)
            {
                _sum = 0f;
            }
        }

        

        else 
        {
            _sum2 = 0f;

            _sum += _platformSpeed;

            Vector2 position = transform.position;
            position.x = position.x + _platformSpeed;
            transform.position = position;
        }
    }
}
