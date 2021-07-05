using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Boss : MonoBehaviour
{
    public float shootSpeed = 1.5f;
    public float health = 200f;
    
    public float enemySpeed;
    private Rigidbody2D enemyBody;
    private Animator anim;
    private Enemy ene;


    public AudioClip explo_planeEnemy;
    public AudioClip shootEnemySound;

    private AudioSource audioSource;
    public float rotateSpeed;

    public bool canRotate;

    public bool canShoot;
    [SerializeField]
    private GameObject enemyBullet;
    private MainMenuCtrller main;
    private Plane pl;
    //[SerializeField]
    //private GameObject enemyBullet;

    void Start()
    {
        audioSource.clip = shootEnemySound;
        if (canShoot)
        {
            StartCoroutine(EnemyShoot());
        }
        audioSource.Play();
        pl = GameObject.FindGameObjectWithTag("Player").GetComponent<Plane>();
    }
    void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        audioSource.clip = shootEnemySound;
    }
    // Start is called before the first frame update

    public static bool move = true;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 temp = enemyBody.position;
        if (enemyBody.position.y > 2.7f)
        {
            enemyBody.velocity = new Vector2(0f, -enemySpeed);
        }
        else
            enemyBody.velocity = new Vector2(0f, 2.7f);                               
    }
    public void TakeDame(int damage)
    {
        health -= damage;
        anim.Play("Shooted");
        if (health <= 0)
        {
            Die();
            //main.GetComponent<MainMenuCtrller>().load_Sence("GamePlay 1");
        }
    }
    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(Random.Range(0.2f, shootSpeed));
        Vector3 temp = transform.position;
        temp.y -= 1f;
        Instantiate(enemyBullet, temp, Quaternion.identity);
        StartCoroutine(EnemyShoot());

    }


    void turnOffGameObject()
    {
        gameObject.SetActive(false);
    }
    void Die()
    {
        audioSource.clip = explo_planeEnemy;
        audioSource.Play();
        anim.Play("Destroy");
        Destroy(gameObject, 0.2f);
        shootSpeed -= 0.1f;
        health += 50;
        //ene.GetComponent<Enemy>().shootSpeedEnemy -= 0.1f;
        //ene.GetComponent<Enemy>().enemySpeed += 0.5f;
    }
    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {
            Destroy(gameObject);
            audioSource.Play();
            GamePlayController.instance.PlaneDiedPanel();
            pl.GetComponent<Plane>().setHighscore();
            Time.timeScale = 0f;
        }
        if (target.tag == "PlaneBullet")
        {        
            if (gameObject.tag == "Enemy")
            {
                Die();             
            }
            
            
        }

        if (target.tag == "Bot Border")
        {
            //Time.timeScale = 0f;
            //GamePlayController.instance.PlaneDiedPanel();
            Destroy(gameObject);

        }
    }
}
