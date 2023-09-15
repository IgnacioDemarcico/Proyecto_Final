using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AjustesVolumen : MonoBehaviour
{
    [SerializeField]public Slider controlVolumen;

    [SerializeField]public GameObject[] audios;

    private void Start()
    {
        audios = GameObject.FindGameObjectsWithTag("audio");
        controlVolumen.value = PlayerPrefs.GetFloat("volumenSave",1f);
    }

    private void Update()
    {
        foreach (GameObject au in audios)
        
        au.GetComponent<AudioSource>().volume = controlVolumen.value;
        
    }

    public void guardarVolumen()
    {
        PlayerPrefs.SetFloat("volumenSave", controlVolumen.value);
    }
}
