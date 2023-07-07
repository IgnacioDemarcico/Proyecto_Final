using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JefeNuevo : MonoBehaviour
{
    public static JefeNuevo instance;
    public float moveSpeed;

    public Transform leftPoint, rightPoint;

    private bool movingRight;

    private Rigidbody2D theRB;
    public SpriteRenderer theSr;

    public float moveTime, waitTime;
    private float moveCount, waitCount;
    [Header ("VidaJefe")]
    public float vidaJ;
    public bool derrotadoJ;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        moveCount = moveTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(moveCount > 0)
        {
            moveCount -= Time.deltaTime;
            if(movingRight)
            {
                theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
                gameObject.GetComponent<Animator>().SetBool("movement", true);
                theSr.flipX = false;
                if(transform.position.x > rightPoint.position.x)
            {
                movingRight = false;
            }
            }
            else
            {
                theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
                gameObject.GetComponent<Animator>().SetBool("movement", true);
                theSr.flipX = true;

                if(transform.position.x < leftPoint.position.x)
                {
                    movingRight = true;
                }
            }
            
            if(moveCount <= 0)
            {
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
        }
            else if(waitCount > 0)
            {
                waitCount -= Time.deltaTime;
                theRB.velocity = new Vector2(0f, theRB.velocity.y);
                gameObject.GetComponent<Animator>().SetBool("movement", false);
                
                if(waitCount <= 0)
                {
                    moveCount = Random.Range(moveTime * .75f, waitTime * 1.25f);
                }

            }
        
        
    }
    public void RecibirDaño(float DanioGolpe)
    {
        vidaJ -= DanioGolpe;
        derrotadoJ = false;
        if(vidaJ <= 0)
        {
           vidaJ = 0;
           derrotadoJ = true;
           Destroy(gameObject);
        }
    }
}
