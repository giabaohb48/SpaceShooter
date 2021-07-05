using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy;
    public float speedSpawn = 1;
    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnerEnemy());
    }

    // Update is called once per frame
   
    IEnumerator spawnerEnemy()
    {
        yield return new WaitForSeconds(Random.Range(speedSpawn, speedSpawn + 2f));

        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(enemy, temp, Quaternion.identity);   
        StartCoroutine(spawnerEnemy());
    }
}
