using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarraDeVida : MonoBehaviour
{
    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }
    public void CambiarVidaMaxima(int maxHealth){
        slider.maxValue = maxHealth;
    }
    public void CambiarVidaActual(int currentHealth){
        slider.value = currentHealth;
    }
    public void InicializarBarraDeVida(int currentHealth){
        CambiarVidaMaxima(currentHealth);
        CambiarVidaActual(currentHealth);
    }
}
