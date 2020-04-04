using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour {

    public Vector3 jump;
    public float jumpForce = 50f;

    public bool isGrounded;
    Rigidbody2D rb;




    private bool colidedWithPlatform;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 5.0f, 0.0f);
        colidedWithPlatform = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
      if(other.gameObject.tag=="moving_platform_y"){
           isGrounded = true;//ja acabou o pulo
           colidedWithPlatform = true;
         }
    }

    void OnCollisionStay2D(Collision2D other)
    {
      if(other.gameObject.tag=="solid_terrain"){
           isGrounded = true;//ja acabou o pulo
           colidedWithPlatform = false;
      }
    }
    void OnCollisionExit2D()
    {
      if(!colidedWithPlatform){
        isGrounded = false;
      }

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
