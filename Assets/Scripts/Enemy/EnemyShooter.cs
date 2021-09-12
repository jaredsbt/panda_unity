using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    float shotTimer = 0.0f;

    public GameObject enemyBullet;
    public float coolDown = 1;

    public GameObject player;
    public float radius = 5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer > coolDown && Vector3.Distance(transform.position, player.transform.position) <= radius)
        {
            Instantiate(enemyBullet, this.transform.position, this.transform.rotation);
            shotTimer = 0;
        }
    }
}