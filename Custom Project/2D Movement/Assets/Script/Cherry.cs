using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Cherry : MonoBehaviour
{
    public float speed = 0.0f;
    private Rigidbody2D rb;
    int cherryVal = 1;
    private Vector2 screenBounds;
    public Camera MainCamera;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") 
        {
            ScoreManager.inst.UpdateScore(cherryVal);
            
        }

    }
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));

    }
    private void Update()
    {
        
    }
}
