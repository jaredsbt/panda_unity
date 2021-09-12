using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaser : MonoBehaviour
{
    public GameObject player;
    public float speed = 4;
    public float radius = 5;
    //radius is how closer the player has to be for the enemy to begin chasing it

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform);
        //makes enemy look at player the whole game

        if (Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}