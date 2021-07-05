using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    public Plane plane;
    [SerializeField]
    private GameObject boss;
    private Enemy ene;
    public GameObject warningPanel;
    private BoxCollider2D box;
    private bool spBoss = false;
    private int pointToSpBoss = 20;
    private int setWarning = 0;
    // Start is called before the first frame update
    
    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
        plane = GameObject.FindGameObjectWithTag("Player").GetComponent<Plane>();
    }
    void Start()
    {
        //if (plane.points % 5 == 0)
        //{
        //    StartCoroutine(spawnerEnemy());
        //}
        
    }

    IEnumerator RemoveAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        warningPanel.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        
        if ((plane.points+1) % pointToSpBoss == 0)
        {
            setWarning = plane.points;
            warningPanel.SetActive(true);
            plane.points++;
            spBoss = true;
            //StartCoroutine(RemoveAfterSeconds(2));
        }
        if (plane.points - setWarning == 3)
        {
            warningPanel.SetActive(false);
        }
        
        if (spBoss)
        {           
            StartCoroutine(spawnerEnemy());
            spBoss = false;
            //if (!spBoss)
            //{
            //    boss.GetComponent<Boss>().shootSpeed -= 0.1f;
            //    boss.GetComponent<Boss>().health += 50f;
            //    ene.GetComponent<Enemy>().shootSpeedEnemy -= 0.1f;
            //    ene.GetComponent<Enemy>().enemySpeed += 0.5f;
            //}

        }
        

    }

    IEnumerator spawnerEnemy()
    {
        yield return new WaitForSeconds(0f);
        Vector3 temp = transform.position;
        temp.x = 0;
        Instantiate(boss, temp, Quaternion.identity);
        //StartCoroutine(spawnerEnemy());
    }
}
