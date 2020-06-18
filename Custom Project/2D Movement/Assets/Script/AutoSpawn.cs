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
        c.transform.position = new Vector2(Random.Range(screenBounds.x * -2, screenBounds.x*2), Random.Range(-screenBounds.y, screenBounds.y));

    }
    IEnumerator cherryObjects()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnObject();
        }
    }
}
