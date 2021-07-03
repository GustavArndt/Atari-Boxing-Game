using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Punch : MonoBehaviour
{
    public Sprite punchStep1, punchStep2, punchStep3, steady;
    public SpriteRenderer spriteRenderer;

    public float renderTimer;

    public float punchSpeed;

    public bool upSide, downSide, rightSide, leftSide;

    public static bool punchTryingUpSide, punchTryingDownSide;
    public static int increment, score ;

    

    // Start is called before the first frame update
    void Start()
    {
        steady = Resources.Load<Sprite>("Punch/punch0");
        punchStep1 = Resources.Load<Sprite>("Punch/punch1");
        punchStep2 = Resources.Load<Sprite>("Punch/punch2");
        punchStep3 = Resources.Load<Sprite>("Punch/punch3");
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        spriteRenderer.sprite = steady;
        punchSpeed = 10;

        punchTryingDownSide = false;
        punchTryingUpSide = false;

        renderTimer = 0;

        upSide = MovementPlayerOne.upSide;
        downSide = MovementPlayerOne.downSide;
        rightSide = MovementPlayerOne.rightSide;
        leftSide = MovementPlayerOne.leftSide;

        score = 0 ;


    }

    // Update is called once per frame
    void Update()
    {

        spriteRenderer.sprite = steady;
        renderTimer -= Time.deltaTime * punchSpeed;

        punchDirection();

        punch();

        print(score) ;

    }

    void punchDirection()
    {

        upSide = MovementPlayerOne.upSide;
        downSide = MovementPlayerOne.downSide;
        rightSide = MovementPlayerOne.rightSide;
        leftSide = MovementPlayerOne.leftSide;


    }

    void punch()
    {
        // punch over the enemy left side
        if (Input.GetKey(KeyCode.Space) && upSide == true && rightSide == true)
        {
            spriteRenderer.sprite = punchStep1;
            renderTimer = 3;
        }

        else if (renderTimer < 3 && renderTimer >= 2 && upSide == true && rightSide == true)
        {
            spriteRenderer.sprite = punchStep2;
        }

        else if (renderTimer < 2 && renderTimer >= 1 && upSide == true && rightSide == true)
        {
            spriteRenderer.sprite = punchStep3;
            punchTryingDownSide = true;
            validHit() ;
        }

        // punch under the enemy left side
        else if (Input.GetKey(KeyCode.Space) && downSide == true && rightSide == true)
        {
            transform.eulerAngles = new Vector3(180, 0, 0);
            spriteRenderer.sprite = punchStep1;
            renderTimer = 3;
        }
        else if (renderTimer < 3 && renderTimer >= 2 && downSide == true && rightSide == true)
        {
            transform.eulerAngles = new Vector3(180, 0, 0);
            spriteRenderer.sprite = punchStep2;

        }

        else if (renderTimer < 2 && renderTimer >= 1 && downSide == true && rightSide == true)
        {
            transform.eulerAngles = new Vector3(180, 0, 0);
            spriteRenderer.sprite = punchStep3;
            punchTryingUpSide = true;
            validHit() ;
        }

        // punch over the enemy rightside
        else if (Input.GetKey(KeyCode.Space) && upSide == true && leftSide == true)
        {
            transform.eulerAngles = new Vector3(180, 0, 180);
            spriteRenderer.sprite = punchStep1;
            renderTimer = 3;
        }

        else if (renderTimer < 3 && renderTimer >= 2 && upSide == true && leftSide == true)
        {
            transform.eulerAngles = new Vector3(180, 0, 180);
            spriteRenderer.sprite = punchStep2;
        }

        else if (renderTimer < 2 && renderTimer >= 1 && upSide == true && leftSide == true)
        {
            transform.eulerAngles = new Vector3(180, 0, 180);
            spriteRenderer.sprite = punchStep3;
            punchTryingDownSide = true;
            validHit() ;
        }

        // punch under the enemy right side
        else if (Input.GetKey(KeyCode.Space) && downSide == true && leftSide == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            spriteRenderer.sprite = punchStep1;
            renderTimer = 3;
        }
        else if (renderTimer < 3 && renderTimer >= 2 && downSide == true && leftSide == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            spriteRenderer.sprite = punchStep2;

        }

        else if (renderTimer < 2 && renderTimer >= 1 && downSide == true && leftSide == true)
        {
            transform.eulerAngles = new Vector3(0, 0, 180);
            spriteRenderer.sprite = punchStep3;
            punchTryingUpSide = true;
            validHit() ;
        }

        else
        {
            if(increment>0){
                score += 1 ;
                increment = 0 ;
            }
            punchTryingDownSide = false;
            punchTryingUpSide = false;
            spriteRenderer.sprite = steady;
        }
        /*print("punchupside" + "=" + punchTryingUpSide + "  , " + "punchDownside" + "=" + punchTryingDownSide +
        "punchrightside" + "=" + rightSide + "  , " + "leftside" + "=" + leftSide) ;*/

    }

    void validHit(){
        if(MovementPlayerOne.availableToHit == true){
            increment += 1 ;
        }
    }
    
}
