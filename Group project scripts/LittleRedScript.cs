using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRedScript : MonoBehaviour
{
    static Animator anim;
    public float speed = 2.0f;
    public float rotationSpeed = 60.0f;
    public float runSpeed = 16.0f;
    public float walkSpeed = 8.0f;
    public bool isWalking;
    public bool isRunning;
    public bool isIdle;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0f, 0f, translation);
        transform.Rotate(0f, rotation, 0f);

        //Walk,Run,Idle:
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (translation != 0)
            {
                anim.SetBool("IsRunning", true);
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsIdle", false);
                speed = runSpeed;
            }
        }
        else
        {
            if (translation != 0)
            {
                anim.SetBool("IsWalking", true);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsIdle", false);
                speed = walkSpeed;
            }
            if (translation == 0)
            {
                anim.SetBool("IsWalking", false);
                anim.SetBool("IsRunning", false);
                anim.SetBool("IsIdle", true);
            }
        }
    }
}
