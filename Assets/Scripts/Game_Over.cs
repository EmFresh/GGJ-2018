using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game_Over : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] help = gameObject.scene.GetRootGameObjects();
        bool end = false;
        foreach (GameObject a in help)
        {
            if (a.name == "Player")
            {

                end = false;
                break;
            }
            else
                end = true;
        }
        if (end)
        {
            GetComponent<Text>().enabled = true;
        }
        if (Input.GetButton("Quit"))
        {
            Debug.Log("quit");
        Application.Quit();
        }
    }
}
