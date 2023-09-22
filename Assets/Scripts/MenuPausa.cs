using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public string levelSelect, mainMenu;
    public GameObject menuPausa;
    public bool enPausa;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Menu"))
        {
            PauseUnpause();
        }
    }
    public void PauseUnpause()
    {
        if(enPausa)
        {
            enPausa = false;
            menuPausa.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            enPausa = true;
            menuPausa.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void LevelSelect()
    {
        SceneManager.LoadScene(levelSelect);
        Time.timeScale = 1f;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenu);
        Time.timeScale = 1f;
    }
}
