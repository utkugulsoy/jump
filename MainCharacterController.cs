using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterController : MonoBehaviour
{
    
    Rigidbody rb;
    
    public bool isGrounded;
    Vector3 v;
    
    
    
 
    float movementSpeed = 10;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        

    }

    private void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
        if (collision.gameObject.tag == "wall") {
            isGrounded = false;
        }
        if (collision.gameObject.tag == "enemy") {
            Destroy(gameObject);
        }
        


    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="wall")
            isGrounded = true;
    }


    private void Update()
    {

     



        if (Input.GetKey(KeyCode.D)) {

            if (isGrounded)
            {
                v = rb.velocity;
                if (rb.velocity.x > 5)
                {
                    v.x = 5f;
                    rb.velocity = v;


                }
                rb.velocity = rb.velocity + transform.right * movementSpeed;
            }


            if (!isGrounded) {
                v = rb.velocity;
                v.x = -5f;
                rb.velocity = v;
                rb.velocity = rb.velocity + transform.right * movementSpeed;


            }
            Debug.Log(rb.velocity);
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (isGrounded)
            {
                v = rb.velocity;
                if (rb.velocity.x < -5)
                {
                    v.x = -5f;
                    rb.velocity = v;
                }

                rb.velocity = rb.velocity + (-transform.right * movementSpeed);
                Debug.Log(rb.velocity);
            }

            if (!isGrounded) {
                v = rb.velocity;
                v.x = 5f;
                rb.velocity = v;
                    rb.velocity= rb.velocity + (-transform.right * movementSpeed);
                Debug.Log(rb.velocity);

            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
               

                rb.velocity = rb.velocity + transform.up * 8;
                isGrounded = false;
            }
           
            
        }
        
        
    }
    
}
