using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCtrller : MonoBehaviour
{
    public int PlaneNumber = 1;
    private ChangePlane changePlane;
    public GameObject selectPanel;
    [SerializeField]
    
    public void PlayGameButton(string scene_name)
    {
        
        SceneManager.LoadScene(scene_name);
        //ChangePlane.instance.selectPlaneToPlay();
        Time.timeScale = 1f;
    }
    public void next_sence(string scene_name)
    {
        
        SceneManager.LoadScene(scene_name);        
        Time.timeScale = 1f;
    }

   
    public void QuitGameButton()
    {
        Application.Quit();
    }
    public void OptionButton()
    {
        selectPanel.SetActive(true);
    }

    public void Plane1_button()
    {
        PlaneNumber = 1;
        selectPanel.SetActive(false);
    }
    public void Plane2_button()
    {
        PlaneNumber = 2;
        selectPanel.SetActive(false);
        Debug.Log(PlaneNumber);
    }
    public void Plane3_button()
    {
        PlaneNumber = 3;
        selectPanel.SetActive(false);
    }
    
    public void x_button()
    {
        selectPanel.SetActive(false);
    }
}
