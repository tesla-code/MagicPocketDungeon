using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = gameObject.transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            Debug.Log("Ground Enter!");

            _player.GetComponent<BasicMovement>()._isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {

        if(collision.collider.tag == "Ground")
        {
            Debug.Log("Ground Exit!");
            _player.GetComponent<BasicMovement>()._isGrounded = false;
        }
    }

}
