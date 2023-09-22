using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIController : MonoBehaviour
{

    public static UIController instance;
    public Text textoMoneda;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        UpdateContadorMonedas();
    }
    // Start is called before the first frame update
    public void UpdateContadorMonedas()
    {
        textoMoneda.text = LevelManager.instance.monedasAgarradas.ToString();
    }
}
