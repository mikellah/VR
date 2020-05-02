using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class RobbyRunning : MonoBehaviour
{
    //Robot:
    GameObject Robby;
    //GameObject Head;
    // GameObject Pelvis, Torso;
    //Right Arms:
    GameObject RightShoulder, RightArm,RightElbow, RightHand;
    //Left Arms:
    GameObject LeftShoulder, LeftArm, LeftElbow, LeftHand;
    //RightLeg
    GameObject RightBone, RightHip, RightKnee, RightLeg;
    //LeftLeg
    GameObject LeftBone, LeftKnee,LeftHip,LeftLeg;

    bool Moves;
    //checks if we are pressing the keys

    public float movementSpeed = 8;
    //movement speed 
    public float rotationSpeed { get { return movementSpeed * 5; } }
    //rotation of bones speed 

    // Start is called before the first frame update
    void Start()
    {
         Robby = GameObject.Find("Robby");
         // Head = GameObject.Find("Head");
         // Torso = GameObject.Find("Torso");
         RightArm = GameObject.Find("RightArm");
         LeftElbow = GameObject.Find("LeftElbow");
         RightElbow = GameObject.Find("RightElbow");
         LeftArm = GameObject.Find("LeftArm");
         LeftBone = GameObject.Find("LeftBone");
         RightBone = GameObject.Find("RightBone");
         RightShoulder = GameObject.Find("RightShoulder");
         LeftShoulder = GameObject.Find("LeftShoulder");
         RightHand = GameObject.Find("RightHand");
         LeftHand = GameObject.Find("LeftHand");
         //Pelvis = GameObject.Find("Pelvis");
          LeftHip = GameObject.Find("LeftHip");
          LeftLeg = GameObject.Find("LeftLeg");
          RightHip = GameObject.Find("RightHip");
          RightLeg = GameObject.Find("RightLeg");
          LeftKnee = GameObject.Find("LeftKnee");
          RightKnee = GameObject.Find("RightKnee");
    }
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MoveForward();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                MoveBackward();
            }
        }

       //Animation code for moving limbs: 
        void Animate()
        {
            if (LeftHip.transform.rotation.x > 0)
            {
                if (!Moves)
                {
                    LeftLeg.transform.RotateAround(LeftKnee.transform.position, Vector3.left, rotationSpeed * 3 * Time.deltaTime);
                    LeftHand.transform.RotateAround(LeftElbow.transform.position, Vector3.right, rotationSpeed * 3 * Time.deltaTime);
                }
                else
                {
                    LeftLeg.transform.RotateAround(LeftKnee.transform.position, Vector3.right, rotationSpeed * 2.7811f * Time.deltaTime);
                    LeftHand.transform.RotateAround(LeftElbow.transform.position, Vector3.left, rotationSpeed * 2.7813f * Time.deltaTime);
                }
            }

            if (RightArm.transform.rotation.x > 0)
            {
                if (Moves)
                {
                    RightLeg.transform.RotateAround(RightKnee.transform.position, Vector3.left, rotationSpeed * 3 * Time.deltaTime);
                    RightHand.transform.RotateAround(RightElbow.transform.position, Vector3.right, rotationSpeed * 3 * Time.deltaTime);

                }
                else
                {
                    RightLeg.transform.RotateAround(RightKnee.transform.position, Vector3.right, rotationSpeed * 2.7811f * Time.deltaTime);
                    RightHand.transform.RotateAround(RightElbow.transform.position, Vector3.left, rotationSpeed * 3 * Time.deltaTime);

                }
            }
            if (Math.Abs(LeftArm.transform.rotation.x) > 0.25f)
            {
                Moves = !Moves;
            }

            if (Moves)
            {
                LeftArm.transform.RotateAround(LeftShoulder.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
                RightArm.transform.RotateAround(RightShoulder.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);

                LeftHip.transform.RotateAround(LeftBone.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
                RightHip.transform.RotateAround(RightBone.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
            }
            else
            {
                LeftArm.transform.RotateAround(LeftShoulder.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
                RightArm.transform.RotateAround(RightShoulder.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);

                LeftHip.transform.RotateAround(LeftBone.transform.position, Vector3.left, rotationSpeed * Time.deltaTime);
                RightHip.transform.RotateAround(RightBone.transform.position, Vector3.right, rotationSpeed * Time.deltaTime);
            }

        }

        void MoveForward()
        {
            Robby.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
            Animate();
        }

        void MoveBackward()
        {
            Robby.transform.Translate(Vector3.back * movementSpeed * Time.deltaTime);
            Animate();
        }

    }
