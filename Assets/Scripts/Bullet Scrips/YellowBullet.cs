using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class YellowBullet : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myBody;

    public Text textPoints;
    private int point;
    public GameObject plan;
    public Boss boss;
    public int Damage = 5;
   
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if (plan == null)
        {
            plan = GameObject.FindGameObjectWithTag("Player");
        }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        myBody.velocity = new Vector2(0f, speed);
    }

    public void getPoints()
    {
        point += 1;
        textPoints.text = point.ToString();
    }
    public void getPointBoss()
    {
        point += 50;
        textPoints.text = point.ToString();
    }
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Enemy" || target.tag == "asteroid")
        {         
            Destroy(gameObject);
            plan.GetComponent<Plane>().getPoints();
        }
        
        if (target.tag == "Border")
        {
            Destroy(gameObject);
        }
        if (target.tag == "boss")
        {
            Destroy(gameObject);
            boss = target.GetComponent<Boss>();
            
            if (boss != null)
            {
                plan.GetComponent<Plane>().getPoints();
                boss.TakeDame(Damage);               
            }
            

        }
        
        

    }
}
