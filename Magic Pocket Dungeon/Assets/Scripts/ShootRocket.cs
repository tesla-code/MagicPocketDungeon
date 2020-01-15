using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootRocket : MonoBehaviour {
    public GameObject homingRocket;
    public Transform GunMuzzle;
    public float fireRate = 3.0f, timeSinceLastFire = 3.0f;
    bool shooting;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.name == "Player") {      // If the collision was with player
            shooting = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        shooting = false;
    }

    private void FixedUpdate() {
        if (shooting){
            if (timeSinceLastFire < fireRate) {
                timeSinceLastFire += Time.deltaTime;
            }
            else {
                Instantiate(homingRocket, GunMuzzle.transform.position, GunMuzzle.rotation);              // Start the process of shooting the rocket
                timeSinceLastFire = 0f;
            }
        }
    }
}
