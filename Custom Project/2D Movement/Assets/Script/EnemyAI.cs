using Pathfinding;
using Pathfinding.Ionic.Zip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float speed = 200f;
    public float distancetoEnemy = 3f;
    public Transform EnemySprite;
    Path aIPath;
    int currentpoint = 0;
    bool isEndofPath = false;
    public bool constrainInsideGraph = false;
    [SerializeField] public Transform respwanPoint;

    Seeker seeker;
    Rigidbody2D myrb;
    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        myrb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Updating", 0f, 0.5f);


    }

    void Updating()
    {
        if (seeker.IsDone())
        {
            seeker.StartPath(myrb.position, target.position, OnComplete);
        }
    }

    void OnComplete(Path x)
    {
        if (!x.error)
        {
            aIPath = x;
            currentpoint = 0;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (aIPath == null) { return; }
        if (currentpoint >= aIPath.vectorPath.Count)
        {
            isEndofPath = true;
            return;

        }
        else
        {
            isEndofPath = false;
        }
        Vector2 direction = ((Vector2)aIPath.vectorPath[currentpoint] - myrb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;
        myrb.AddForce(force);

        float distance = Vector2.Distance(myrb.position, aIPath.vectorPath[currentpoint]);
        if (distance < distancetoEnemy)
        {
            currentpoint++;
        }

        if (force.x >= 0.01f)
        {
            EnemySprite.localScale = new Vector3(-1f, 1f, 1f);
        }
        if (force.x <= -0.01f)
        {
            EnemySprite.localScale = new Vector3(1f, 1f, 1f);
        }

      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.position = respwanPoint.position;
        }
    }

}
