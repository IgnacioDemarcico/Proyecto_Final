using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    public static PlayerVida instance;
    public int currentHealth, maxHealth;
    public float ivencibleLength;
    private float ivencibleCounter;
    private SpriteRenderer sprai;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
        sprai = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ivencibleCounter > 0)
        {
            ivencibleCounter -= Time.deltaTime;
            if(ivencibleCounter <= 0)
            {
                sprai.color = new Color(sprai.color.r,sprai.color.g,sprai.color.b,1f);
            }
        }
    }
    public void AplicarGolpe()
    {
        if (ivencibleCounter <= 0)
        {
            currentHealth--;
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                gameObject.SetActive(false);
            }
            else
            {
                ivencibleCounter = ivencibleLength;
                sprai.color = new Color(sprai.color.r,sprai.color.g,sprai.color.b,.5f);
                Movimiento.instance.Knockback();
            }
        }
        
    }
}
