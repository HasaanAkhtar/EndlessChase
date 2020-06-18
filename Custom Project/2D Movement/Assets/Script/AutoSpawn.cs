using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject cherryPrefab;
    public float respawnTime = 1.0f;
    private Vector2 screenBounds;
    public Camera MainCamera;
    private float objectWidth;
    private float objectHeight;
    // Use this for initialization
    void Start()
    {
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        StartCoroutine(cherryObjects());
    }

    private void spawnObject()
    {
        GameObject c = Instantiate(cherryPrefab) as GameObject;
        c.transform.position = new Vector2(Random.Range(-screenBounds.x,screenBounds.x), Random.Range(-screenBounds.y /2 , screenBounds.y));

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            cherryObjects();
        }
    }

    IEnumerator cherryObjects()
    { 
        
        yield return new WaitForSeconds(respawnTime);
        spawnObject();
      
    }
}
