using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneAxe : MonoBehaviour {
    throwAxeXPOS throwAxe;
    [SerializeField] GameObject axe;
    float throwCycle = 3;
    public bool ready = true, canFlip = true;
    [SerializeField] float waitTime;
    [SerializeField] float axeAliveTime;
    bool throwing;

    // Start is called before the first frame update
    void Start() {
        //why not just set this manually?
        //Didn't make this code btw >_>
        throwAxe = axe.GetComponent<throwAxeXPOS>();                        // Get access to the script that axe has
    }

    // When collision happens
    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {    // If the collision was with the player
            throwing = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        throwing = false;
    }

    private IEnumerator axeThrowDelay() {
        //how long the creature waits until it throws  a new axe
        yield return new WaitForSeconds(waitTime);  // Delay for 1.5 seconds. This is done so that the axe is in his hand for more than a split second before throwing again
        throwAxe.Throw();                       // Then throw the axe
    }

    private void FixedUpdate() {
        //how long the axe is allowed to stay alive
        if (throwCycle <= axeAliveTime) {
            throwCycle += Time.deltaTime;       // Update the cycle
        } else {                // If it is time to throw:
            throwAxe.originPos();               // Place the axe in the hand of the enemy (and avoid wrong sending of the axe..)
            ready = true;                       // He is ready for another throw
            canFlip = true;                     // flipEnemy.cs can now safely flip the enemy and the axe, if needed
        }
        //Throw the damn axe
        if (throwing) {
            Debug.Log(throwCycle + " >" + axeAliveTime);
            //if the previous throw is complete and if the axe is in hand
            if (throwCycle > axeAliveTime && ready) {
                StartCoroutine(axeThrowDelay());    // Delay the process of throwing
                throwCycle = 0;     // Reset the "cycle"
                ready = false;      // The axe is not in hand
            }
        }
    }
}
