using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSecundario : MonoBehaviour
{
    // Start is called before the first frame update
   public void Jugar()
   {
    SceneManager.LoadScene("Level 1");
    }
    public void Jugar2()
   {
    SceneManager.LoadScene("Level 2");
    }
     public void Menu1()
   {
    SceneManager.LoadScene("MenuPrincipal");
    }
    public void Salir(){
        Debug.Log("Salir...");
        Application.Quit();
    }
}
