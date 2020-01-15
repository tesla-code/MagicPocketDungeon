using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public bool canFly;
    [SerializeField] float _horizontalSpeed = 2.5f;
    [SerializeField] float _jumpForce = 7.0f;
    float horizontalMove = 0f;
    float verticalMove = 0f;
    Rigidbody2D rb;
    Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;
    public bool _isGrounded = false;
    bool facingRight;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * _horizontalSpeed;
        verticalMove = Input.GetAxisRaw("Vertical") * _horizontalSpeed;
        // left -1 i.e position.x + -0.1f;  
        // right 1 i.e position.x + 0.1f;     
        // 0 means no key
        /* float horizontal = Input.GetAxisRaw("Horizontal");

         Vector2 postion = transform.position;
         postion.x = postion.x + _horizontalSpeed * horizontal * Time.deltaTime;
         transform.position = postion;*/
        Move( horizontalMove * Time.fixedDeltaTime);
        // Jump Code
        Jump();
        if (canFly){
            //just use the same speed as horizontal
            Fly(verticalMove * Time.fixedDeltaTime);
        }
    }
    public void Move(float move)
    {
        //Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rb.velocity.y);

        //And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        //if input is moving the player right and the player is facing left
        if (move > 0 && facingRight)
            Flip();

        else if (move < 0 && !facingRight)
            Flip();
        //*******************************************************
    }

    private void Flip(){
        facingRight = !facingRight;

        //multiply the player's x local scale by -1
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    private void Jump() {
        if (Input.GetKeyDown("space") && (_isGrounded == true)){
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, _jumpForce), ForceMode2D.Impulse);
            print("space key was pressed");
        }
    }
    private void Fly(float move){
        //Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(rb.velocity.x, move * 10f);

        //And then smoothing it out and applying it to the character
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

    }
    //getters and setters for various values
    public float getWalkSpeed(){
        return _horizontalSpeed;
    }
    public void setWalkSpeed(float s){
        _horizontalSpeed = s;
    }
    public float getJumpHeight(){
        return _jumpForce;
    }
    public void setJumpHeight(float j){
        _jumpForce = j;
    }
}
