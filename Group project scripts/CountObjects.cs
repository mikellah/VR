using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountObjects : MonoBehaviour
{
    public GameObject objToDestroy;
    public GameObject objUI;
    public bool collectedBread = false;
    // Start is called before the first frame update
    void Start()
    {
        objUI = GameObject.Find("ObjectNum");
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedBread==false)
        {
            objUI.GetComponent<Text>().text = (ObjectsToCollect.toasts.ToString() + " pieces of bread left. " + ObjectsToCollect.wines.ToString() + " bottles of wine left");
            if (ObjectsToCollect.toasts == 0 && ObjectsToCollect.wines ==0)
            {
                objUI.GetComponent<Text>().text = "All bread collected. All bottles of wine collected. Congratulations";

                collectedBread = true;
            }
        }
        
    }
}
