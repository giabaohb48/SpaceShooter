using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlane : MonoBehaviour
{
    // Start is called before the first frame update
    public static ChangePlane instance;
    private MainMenuCtrller main;
    public int planeNum = 1;
    public GameObject plane1, plane2, plane3;
    void Awake()
    {
        MakeInstance();    
        
        
    }
    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        main = GameObject.FindGameObjectWithTag("main").GetComponent<MainMenuCtrller>();
        selectPlaneToPlay();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selectPlaneToPlay()
    {
        planeNum = main.PlaneNumber;
        switch (planeNum)
        {
            case 1:
                plane1.SetActive(true);
                //plane2.SetActive(false);
                //plane3.SetActive(false);
                break;
            case 2:
                //plane1.SetActive(false);
                plane2.SetActive(true);
                //plane3.SetActive(false);
                break;
            case 3:
                //plane1.SetActive(false);
                //plane2.SetActive(false);
                plane3.SetActive(true);
                break;
            default:
                plane1.SetActive(true);
                //plane2.SetActive(false);
                //plane3.SetActive(false);
                break;
        }
       

    }
    //public void Plane1_Button()
    //{

    //    plane1.SetActive(true);
    //    plane2.SetActive(false);
    //    plane3.SetActive(false);
    //}
    //public void Plane2_Button()
    //{

    //    plane1.SetActive(false);
    //    plane2.SetActive(true);
    //    plane3.SetActive(false);
    //}
    //public void Plane3_Button()
    //{

    //    plane1.SetActive(false);
    //    plane2.SetActive(false);
    //    plane3.SetActive(true);
    //}
}
