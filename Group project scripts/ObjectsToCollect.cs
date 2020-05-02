using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsToCollect : MonoBehaviour
{
    // Start is called before the first frame update
    public static int toasts = 0;
    public static int wines = 0;
    public static bool toast = true;
    void Awake()
    {

        if (gameObject.tag == "Wine")
        {
            wines++;
           // gameObject.SetActive(false);
        }
        else
            toasts++;
    }
  /*  void showWine()
    {
            GameObject[] gs;
            gs = GameObject.FindGameObjectsWithTag("Wine");
            foreach(GameObject g in gs)
            {
                g.SetActive(true);
            }
    }*/

    // Update is called once per frame
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            if (gameObject.tag == "Wine")
            {
                wines--;
                gameObject.SetActive(false);
            }
            else
            {
                toasts--;
                gameObject.SetActive(false);
            }
        }
       
    }
}
