using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRoam : MonoBehaviour
{
    public float speed = 5.0f;

    public Vector3 pointA;
    public Vector3 pointB;
    //Locations the enemy goes between

    Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        target = pointA;
    }

    // Update is called once per frame
    void Update()
    {
        Roam();
    }

    void Roam()
    {
        float step = speed * Time.deltaTime;
        //enemy moves one step closer to target

        transform.position = Vector3.MoveTowards(transform.position, target, step);
        transform.LookAt(target);
        //make enemy face the direction it is traveling

        if (Vector3.Distance(transform.position, target) < 0.001f)
        {
            if (target == pointA)
            {
                target = pointB;
            }
            else if (target == pointB)
            {
                target = pointA;
            }
        }
    }
}