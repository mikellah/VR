using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed = 500f;
    public Vector3 jump;
    private bool isGrounded;
    private Rigidbody body;
    public float jumpPower = 1f;
   

    void Start()
    {
        body = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //for movement input:
        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");
        float moveX = inputX * speed * Time.deltaTime;
        float moveZ = inputZ * speed * Time.deltaTime;
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        body.AddForce(moveX,0,moveZ);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {

            body.AddForce(jump * jumpPower, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
