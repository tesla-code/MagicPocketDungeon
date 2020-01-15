using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwAxeXPOS : MonoBehaviour {
    public Transform target;
    private Vector2 pos;
    private Vector2 posLocal;
    private Rigidbody2D rb;
    [SerializeField]
    float speed = 10.0f;    // Change this to allow for greater distance in the throw
    bool spin = false;
    float YRotationParent;
    [SerializeField] private float spinSpeed;
    private float parentYScale;

    private void Start() {
        if (spinSpeed == 0)
            spinSpeed = 200;
        rb = GetComponent<Rigidbody2D>();                               // Get the rigid body of the axe
        pos = transform.position;                                       // Get the posistion of the axe
        posLocal = transform.localPosition;                                       // Get the local posistion of the axe
       // rb.constraints = RigidbodyConstraints2D.FreezeAll;              // Freeze the axe so that it doesn't fall straight down
        target = GameObject.FindGameObjectWithTag("Player").transform;  // Get the playerobject
    }

    public void originPos() {   // Sets the posistion and rotation of the axe, as well as freezing it and not allowing it to spin
        transform.position = new Vector2(pos.x, pos.y);
        transform.localPosition = new Vector2(posLocal.x, posLocal.y);
        //get the parent's rotation (1 or -1)
        parentYScale = transform.parent.rotation.y;
        //makes sure the axe is rotated in the right angle depending on which side the parent is facing
        transform.rotation = Quaternion.Euler(0, (180*parentYScale), 0);
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        spin = false;
    }

    public void Throw() {       // I got the math from: https://gamedev.stackexchange.com/questions/114522/how-can-i-launch-a-gameobject-at-a-target-if-i-am-given-everything-except-for-it
        originPos();
        Vector3 toTarget = target.position - transform.position;

        // Set up the terms we need to solve the quadratic equations.
        float gSquared = Physics.gravity.sqrMagnitude;
        float b = speed * speed + Vector3.Dot(toTarget, Physics.gravity);
        float discriminant = b * b - gSquared * toTarget.sqrMagnitude;

        // Check whether the target is reachable at max speed or less.
        if (discriminant < 0) { return; }   // Target is too far away to hit at this speed.

        float discRoot = Mathf.Sqrt(discriminant);

        // Highest shot with the given max speed:
        float T_max = Mathf.Sqrt((b + discRoot) * 2f / gSquared);
        // Lowest shot with the given max speed
        float T_min = Mathf.Sqrt((b - discRoot) * 2f / gSquared);

        float T = T_min + 0.5f;

        // Convert from time-to-hit to a launch velocity:
        Vector3 velocity = toTarget / T - Physics.gravity * T / 2f;

        rb.constraints = RigidbodyConstraints2D.None;   // Un-freezes the axe
        rb.AddForce(velocity, ForceMode2D.Impulse);     // Sends the axe in the calculated path
        spin = true;
    }

    private void FixedUpdate() {
        if (spin) {     // Spins the axe if it is in the air
            transform.Rotate(0, 0, Time.deltaTime * spinSpeed);
        }
        else {
            originPos();
        }
    }
}
