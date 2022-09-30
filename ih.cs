using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class ih : MonoBehaviour
{
  public Rigidbody2D rb;
  public float speed;
  public float jumpForce;
  private float moveinput;
 public float charspeed = 10f;
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public Animator anim;
  public bool isGrounded;
  private bool jump = false;
  
  
  
  

  void start(){
    rb = GetComponent<Rigidbody2D>();
  }
  void FixedUpdate(){
    moveinput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(moveinput * speed, rb.velocity.y);

    if(isGrounded == true && Input.GetButtonDown("Jump")){
        rb.velocity = Vector2.up * jumpForce;
        isGrounded = false;
        jump = true;
        anim.SetTrigger("Jump");
    }
    if (moveinput > 0)
    {
      gameObject.transform.localScale = new Vector2(3.096939f,3.478609f);
    }
    else if (moveinput < 0)
    {
     gameObject.transform.localScale = new Vector2(-3.096939f,3.478609f);

    }
  }
  void Update(){
     if (Mathf.Abs(moveinput) != 0)
        {
            anim.SetFloat("speed", speed);
        }
        else anim.SetFloat("speed", 0);
  }
  private void OnCollisionEnter2D(Collision2D collision)
  {
    if(collision.gameObject.CompareTag("ground"))
    {
        isGrounded = true;

    }
  }
}