using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float speed;
    int currentPointIndex;

    float waitTime;
    public float startWaitTime;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = patrolPoints[0].position;
        transform.rotation = patrolPoints[0].rotation;
        waitTime = startWaitTime;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);

        if (transform.position == patrolPoints[currentPointIndex].position)
        {
            transform.rotation = patrolPoints[currentPointIndex].rotation;
            if (waitTime <= 0)
            {
                if (currentPointIndex + 1 < patrolPoints.Length)
                {
                    currentPointIndex++;
                }
                else
                {
                    currentPointIndex = 0;
                }

                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
