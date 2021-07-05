using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, -speed);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            //Destroy(target.gameObject);
            GamePlayController.instance.PlaneDiedPanel();

        }
        if (target.tag == "Bot Border")
        {
            Destroy(gameObject);
        }
    }
}
