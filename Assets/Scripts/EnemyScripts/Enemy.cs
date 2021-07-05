using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public float shootSpeedEnemy = 2f;
    public float enemySpeed = 2f;
    private Rigidbody2D enemyBody;
    private Animator anim;


    public AudioClip explo_asteroid;
    public AudioClip explo_planeEnemy;
    public AudioClip shootEnemySound;

    private AudioSource audioSource;
    public float rotateSpeed;

    public bool canRotate;
    public bool canShoot;

    [SerializeField]
    private GameObject enemyBullet;

    //[SerializeField]
    //private GameObject enemyBullet;

    void Start()
    {
        audioSource.clip = shootEnemySound;
        if (canShoot)
        {
            StartCoroutine(EnemyShoot());
        }
        
    }
    void Awake()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootEnemySound;
    }
    // Start is called before the first frame update



    // Update is called once per frame
    void FixedUpdate()
    {
        enemyBody.velocity = new Vector2(0f, -enemySpeed);
        RotateEnemy();
    }
    IEnumerator EnemyShoot()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, shootSpeedEnemy));
        Vector3 temp = transform.position;
        temp.y -= 0.7f;
        Instantiate(enemyBullet, temp, Quaternion.identity);
        audioSource.Play();
        StartCoroutine(EnemyShoot());

    }


    void RotateEnemy()
    {
        if (canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotateSpeed * Time.deltaTime), Space.World);
        }
    }
    void turnOffGameObject()
    {
        gameObject.SetActive(false);
    }
   
    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Player")
        {
            //Destroy(target.gameObject);
            //audioSource.Play();
            
            GamePlayController.instance.PlaneDiedPanel();
            Time.timeScale = 0f;
        }
        if (target.tag == "PlaneBullet")
        {
            if (gameObject.tag == "asteroid")
            {
                audioSource.clip = explo_asteroid;
                audioSource.Play();
            }
            if (gameObject.tag == "Enemy")
            {
                audioSource.clip = explo_planeEnemy;
                audioSource.Play();
            }
            anim.Play("Destroy");
            Destroy(gameObject, 0.2f);
        }

        if (target.tag == "Bot Border")
        {
            //Time.timeScale = 0f;
            //GamePlayController.instance.PlaneDiedPanel();
            Destroy(gameObject);

        }
    }
}
