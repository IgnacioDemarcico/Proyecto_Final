using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public float waitToRespawn;

    public int monedasAgarradas;

    public void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCo());
    }
    IEnumerator RespawnCo()
    {
        Movimiento.instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(waitToRespawn);

        Movimiento.instance.gameObject.SetActive(true);

        Movimiento.instance.transform.position = CheckpointController.instance.spawnpoint; 
    }
}
