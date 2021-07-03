using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayerOne : MonoBehaviour
{
    public static float speed;
    public  GameObject enemy;
    public  GameObject player;
    public  Vector3 enemyPos, playerPos;
    public  float posX , posY, limitY, limitX ;
    public float ringBoundX, ringBoundY ;
    public static bool availableToHit ;

    public static bool rightSide, upSide, downSide, leftSide ;    
    

     void Start() {

        player = GameObject.FindGameObjectWithTag("PlayerOne") ;
        playerPos = transform.localPosition ;
        
        enemy = GameObject.FindGameObjectWithTag("PlayerTwo") ;
        enemyPos = enemy.transform.localPosition ;

        availableToHit = false ;
                 
    }
    
    // Update is called once per frame
    void Update()
    {
        enemyPos = enemy.transform.localPosition ;
        playerPos = transform.localPosition ;

        speed = 3 ;

        posX = enemyPos.x ;//+ 1.42f
        posY = enemyPos.y ;//+ 2.4f 

        limitX = 1.42f ;
        limitY = 2.4f ;

        ringBoundX = 4.85f ;
        ringBoundY = 2.25f ;

        
        Controls();

        ringBoundaries() ;

        enemyBoundaries() ;
        
        playerSide() ;

        PositionToHit() ;

    }
    void playerSide(){
                
        if(playerPos.x>enemyPos.x){
            transform.eulerAngles = new Vector3(0,0,180);
            leftSide = true ;
            rightSide = false ;
            
        }
        else if(playerPos.x<enemyPos.x){
            transform.eulerAngles = new Vector3(0,0,0);
            leftSide = false ;
            rightSide = true ;
                       
        }
        if(playerPos.y>enemyPos.y){
            downSide = true ;
            upSide = false ;
        }
        else if(playerPos.y<enemyPos.y){
            downSide = false ;
            upSide = true ;
        }
    }
    void Controls(){
        if (Input.GetKey(KeyCode.W))
        {
            transform.localPosition += Vector3.up*speed*Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.localPosition += Vector3.down*speed*Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localPosition += Vector3.left*speed*Time.deltaTime ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localPosition += Vector3.right*speed*Time.deltaTime ;
        }
    }

    void ringBoundaries(){
            if(transform.localPosition.y <= -ringBoundY){
                
                transform.localPosition = new Vector3(transform.localPosition.x , -ringBoundY, transform.localPosition.z) ;
            }
            if(transform.localPosition.y >= ringBoundY){
                
                transform.localPosition = new Vector3(transform.localPosition.x , ringBoundY, transform.localPosition.z) ;
            }
            if(transform.localPosition.x <= -ringBoundX){
                
                transform.localPosition = new Vector3(-ringBoundX , transform.localPosition.y, transform.localPosition.z) ;
            }
            if(transform.localPosition.x >= ringBoundX){
                
                transform.localPosition = new Vector3(ringBoundX , transform.localPosition.y, transform.localPosition.z) ;
            }
    }

    void enemyBoundaries(){
        if(transform.localPosition.y <= (posY+limitY) && transform.localPosition.y>(posY + 2) && downSide == true && transform.localPosition.x >=(posX-limitX) && transform.localPosition.x <=(posX+limitX) ){
            
            transform.localPosition = new Vector3(transform.localPosition.x, (posY + limitY), transform.localPosition.z) ;
        }
        if(transform.localPosition.x <= (posX+limitX) && transform.localPosition.x>(posX + 1.3f) && leftSide == true && transform.localPosition.y >=(posY-limitY) && transform.localPosition.y <=(posY+limitY) ){
            transform.localPosition = new Vector3((posX + limitX), transform.localPosition.y, transform.localPosition.z) ;
        }
        if(transform.localPosition.x >= (posX - limitX) && transform.localPosition.x<(posX - 1.3f) && rightSide == true && transform.localPosition.y >=(posY-limitY) && transform.localPosition.y <=(posY+limitY) ){
            transform.localPosition = new Vector3((posX - limitX), transform.localPosition.y, transform.localPosition.z) ;
        }
        if(transform.localPosition.y >= (posY- limitY) && transform.localPosition.y<(posY - 2) && upSide == true && transform.localPosition.x >=(posX-limitX) && transform.localPosition.x <=(posX+limitX) ){
            
            transform.localPosition = new Vector3(transform.localPosition.x, (posY - limitY), transform.localPosition.z) ;
        }
               
    }

    void PositionToHit(){
            if(Mathf.Abs(playerPos.x - posX) <= 1.45f ){
                //print("posição em x para bater") ;
                
                
                if(Mathf.Abs(playerPos.y-posY) <= 1.3f && Mathf.Abs(playerPos.y-posY) >= 0.7f){
                    
                    //print("posição em y para bater vaiiiiiiiiiiiiiiiiiiiiiiii") ;
                    availableToHit = true ;
                }
                else
                {
                    availableToHit = false;
                }
            }
            //print(Mathf.Abs(playerPos.y-posY)) ;
            //print(Mathf.Abs(playerPos.x - posX)) ;
    }



}

