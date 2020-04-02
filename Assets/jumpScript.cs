using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpScript : MonoBehaviour {

    public Vector3 jump;
    public float jumpForce = 50f;

    public bool isGrounded;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jump = new Vector3(0.0f, 5.0f, 0.0f);
    }

    void OnCollisionEnter2D()
    {
      //Debug.Log("CHAo");
        isGrounded = true;
    }
  //  void OnCollisionExit2D()
  //  {
  //    isGrounded = false;
  //  }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
}
