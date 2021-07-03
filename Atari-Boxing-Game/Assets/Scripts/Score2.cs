using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score2 : MonoBehaviour
{
    public Text score2 ;

    // Start is called before the first frame update
    void Start()
    {
            score2.text = "0" ;
    }

    // Update is called once per frame
    void Update()
    {
        score2.text = Player2Punch.score2.ToString() ;
    }
}
