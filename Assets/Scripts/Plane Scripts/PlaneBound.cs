using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBound : MonoBehaviour
{
    // Start is called before the first frame update
    private float minX, maxX, minY, maxY;


    void Start()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0f));

        minX = -bounds.x + 0.4f;
        maxX = bounds.x - 0.4f;

        minY = -bounds.y + 0.5f;
        maxY = bounds.y - 0.4f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = transform.position;

        if (temp.x < minX)
        {
            temp.x = minX;
        }
        else if (temp.x > maxX)
        {
            temp.x = maxX;
        }

        if (temp.y < minY)
        {
            temp.y = minY;
        }
        else if (temp.y > maxY)
        {
            temp.y = maxY;
        }

        transform.position = temp;
    }
}
