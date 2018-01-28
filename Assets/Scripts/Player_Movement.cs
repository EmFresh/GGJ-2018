using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public int speed;
    public int fireCount;
    public GameObject gamObject;
    int fcCount = 0;
    // Use this for initialization
    void Start()
    {
        //GetComponent<Transform>().transform.Translate( new Vector2(1, 0));
        //GetComponent<Rigidbody2D>().velocity = new Vector2(1,0) ;
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.tag == "Boundery")
        {
            Transform trans = other.GetComponent<Transform>();
            GetComponent<Rigidbody2D>().position = new
                    Vector2(
                    Mathf.Clamp(GetComponent<Rigidbody2D>().position.x, trans.position.x - trans.lossyScale.x / 2 + GetComponent<SpriteRenderer>().sprite.bounds.extents.x*2, trans.position.x + trans.lossyScale.x / 2 - GetComponent<SpriteRenderer>().sprite.bounds.extents.x*2),
                    Mathf.Clamp(GetComponent<Rigidbody2D>().position.y, trans.position.y - trans.lossyScale.y / 2, trans.position.y + trans.lossyScale.y / 2));
            //   Debug.Log(trans.position.x + " : " + GetComponent<Rigidbody2D>().position.x);
        }

    }
    bool hitPlayer;
    int deathCount = 3;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && !hitPlayer)
        {
            Destroy(collision.gameObject);
            hitPlayer = true;
            if (deathCount-- == 0)
                Destroy(gameObject);
        }
    }

    int colCount = 10, colCounter, count;
    public int imunity;
    private void hit(bool hit)
    {
        if (hit)
        {
            if (count++ < imunity)
            {

                if (colCounter++ == 0)
                    GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .8f);
                else if (colCounter == colCount / 2)
                {
                    GetComponent<SpriteRenderer>().color = new Color(255, 0, 0, .5f);
                }
                else if (colCounter > colCount)
                    colCounter = 0;
            }
            else
            {
                count = 0;
                hitPlayer = false;
            }

        }
        else
            GetComponent<SpriteRenderer>().color = new Color(255, 255, 255);
    }

    // Update is called once per frame

    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(Input.GetAxis("Horizontal") * speed, Input.GetAxis("Vertical") * speed);



        if (Input.GetButton("Fire1") && fcCount++ == 0)
        {
            Debug.Log("fire!!!");
            Destroy(Instantiate(gamObject, new Vector3(transform.position.x, (transform.position.y + .5f)), Quaternion.identity), 1.2f);

        }
        if (fcCount == fireCount)
            fcCount = 0;

        if (!Input.GetButton("Fire1"))
        {
            fcCount = 0;
        }
        hit(hitPlayer);
        //Debug.Log(fcCount);
    }
}
