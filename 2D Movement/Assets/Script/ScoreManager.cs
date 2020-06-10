using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager inst;
    public Text text;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (inst == null)
        {
            inst = this;
        }

    }

    public void UpdateScore(int cherryVal)
    {
        //if (cherryVal != 0)
        //{
            score += cherryVal;
            text.text = "XP " + score.ToString();
        //}
      
    }
}
