using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroid : MonoBehaviour
{

    [SerializeField]
    private GameObject[] asteroid;

    private BoxCollider2D box;

    void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnerAsteroid());
    }

    // Update is called once per frame

    IEnumerator spawnerAsteroid()
    {
        yield return new WaitForSeconds(Random.Range(1f, 7f));

        float minX = -box.bounds.size.x / 2f;
        float maxX = box.bounds.size.x / 2f;

        Vector3 temp = transform.position;
        temp.x = Random.Range(minX, maxX);
        Instantiate(asteroid[Random.Range(0,asteroid.Length)], temp, Quaternion.identity);
        StartCoroutine(spawnerAsteroid());
    }
}
