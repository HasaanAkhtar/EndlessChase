using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cherry : MonoBehaviour
{
    int cherryVal = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            ScoreManager.inst.UpdateScore(cherryVal);
        }
    }
}
