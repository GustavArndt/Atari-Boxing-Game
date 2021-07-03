using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score1 : MonoBehaviour
{
    public Text score1 ;

    // Start is called before the first frame update
    void Start()
    {
            score1.text = "0" ;
    }

    // Update is called once per frame
    void Update()
    {
        score1.text = Player1Punch.score.ToString() ;
    }
}
