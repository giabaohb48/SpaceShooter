using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plane : MonoBehaviour
{
    //public SpawnerBoss spBoss;
    public MainMenuCtrller main;
    public float planeSpeed;
    private Rigidbody2D myBody;
    private bool canShoot = true;

    private Animator anim;
    
    public AudioClip PlanShootedSound;
    public AudioClip shootSound;
    private AudioSource audioSource;

    public float bulletWait;
    public Text textPoints;
    public Text highScore;
    public Text yourScore;
    public int points = 0;

    private SpriteRenderer spriteR;
    

    // Start is called before the first frame update


    [SerializeField]
    private GameObject bullet;
    private GameObject spawnBoss;
    void Awake() 
    {
        //spBoss = GameObject.FindGameObjectWithTag("Boss").GetComponent<SpawnerBoss>();
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = shootSound;
        if (bullet == null)
        {
            bullet = GameObject.FindGameObjectWithTag("YellowBullet");
        }
        //spriteR = GetComponent<SpriteRenderer>();
        
        
    }

    void Start()
    {
        //main = GameObject.FindGameObjectWithTag("main").GetComponent<MainMenuCtrller>();
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (canShoot)
            {
                StartCoroutine(Shoot());
                audioSource.Play();
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        planeMovement();
        //planeNum = main.PlaneNumber;
        //spriteR.sprite = sprites[planeNum];
    }

    void planeMovement()
    {
        float xAxis = Input.GetAxisRaw("Horizontal") * planeSpeed;
        float yAxis = Input.GetAxisRaw("Vertical") * planeSpeed;
        myBody.velocity = new Vector2(xAxis, yAxis);
    }
    IEnumerator Shoot()
    {
        canShoot = false;
        Vector3 temp = transform.position;
        temp.y += 0.7f;
        Instantiate(bullet, temp, Quaternion.identity);
        yield return new WaitForSeconds(bulletWait);
        canShoot = true;
    }
    public void getPoints()
    {
        points += 1;
        textPoints.text = points.ToString();      
    }
    public void getPointBoss()
    {
        points += 50;
        textPoints.text = points.ToString();

    }

    public void setHighscore()
    {
        if (points > PlayerPrefs.GetInt("Highscore", points))
        {
            PlayerPrefs.SetInt("Highscore", points);
            
        }
        //PlayerPrefs.GetInt("Highscore", points);
        highScore.text = PlayerPrefs.GetInt("Highscore", points).ToString();
        yourScore.text = textPoints.text;
        textPoints.gameObject.SetActive(false);
        
    }
    void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "Enemy" || target.tag == "asteroid")
        {
            //bullet.GetComponent<YellowBullet>().getPoints();
            anim.Play("Destroy");
            audioSource.clip = PlanShootedSound;
            audioSource.Play();
            Destroy(gameObject, 0.3f);
            Time.timeScale = 0f;
            setHighscore();
        }

        if (target.tag == "RedBullet")
        {
            
            anim.Play("Destroy");
            audioSource.clip = PlanShootedSound;
            audioSource.Play();
            Destroy(gameObject, 0.3f);
            GamePlayController.instance.PlaneDiedPanel();
            setHighscore();

        }
    
    }
}
