using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;



public class Buttons : MonoBehaviour
{
    public GameObject panel;
    
    
    
    public void QuitButton()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

   



    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void resumeScene()
    {
        panel.SetActive(false);
    }
    public void GameSettings()
    {
        panel.SetActive(true);
    }
    



    void Start()
    {
        

        if (panel != null)
        {
            panel.SetActive(false);
        }
        else
        {
            Debug.LogError("Panel deðiþkeni atanmamýþ! Inspector üzerinden atandýðýndan emin olun.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.Escape))
        {
            //SceneManager.LoadScene(0);
            panel.gameObject.SetActive(true);

        }
    }
}
