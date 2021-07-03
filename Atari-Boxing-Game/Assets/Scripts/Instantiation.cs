using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instantiation : MonoBehaviour
{
    public GameObject playerOne , playerTwo, arena, Timer, score1, score2, canvas;


    void Start()
    {
        Instantiate(playerOne, new Vector3(-4.5f, 2, 0), Quaternion.identity) ;
        Instantiate(arena, new Vector3(0,0,0), Quaternion.identity) ;
        Instantiate(playerTwo, new Vector3(4.5f, -2, 0), Quaternion.Euler(0,0,180)) ;
        Instantiate(Timer, new Vector3(0, 180, 0), Quaternion.identity).transform.SetParent(canvas.transform, false);
        Instantiate(score1, new Vector3(-350, 200, 0), Quaternion.identity).transform.SetParent(canvas.transform, false);
        Instantiate(score2, new Vector3(350, 200, 0), Quaternion.identity).transform.SetParent(canvas.transform, false);

       
    }

}
