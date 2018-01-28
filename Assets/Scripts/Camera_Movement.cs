using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Movement : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        //  get().transform.Translate(new Vector3(1,0,0));
        GetComponent<Rigidbody2D>().velocity = new Vector2(1, 0);
    }

    // Update is called once per frame
    void Update()
    {
       

    }
}
