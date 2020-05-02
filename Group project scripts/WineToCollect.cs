using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WineToCollect : MonoBehaviour
{
    public static int wineBottles = 0;
    void Awake()
    {
        wineBottles++;

    }

    void LateUpdate()
    {
        if (ObjectsToCollect.toasts == 0)
        {
            if (gameObject.tag == "Wine")
            {
                gameObject.SetActive(true);
            }
        }
        else
        {
            if (gameObject.tag == "Wine")
            {
                gameObject.SetActive(false);
            }
        }

    }
        // Update is called once per frame
        void OnTriggerEnter(Collider player)
        {
            if (player.gameObject.tag == "Player")
                wineBottles--;
            gameObject.SetActive(false);
        }
    
}
