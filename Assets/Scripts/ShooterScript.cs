using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterScript : MonoBehaviour
{
    public GameObject bullet;

    public bool canShoot;
    public float timeBetweenShots = 1;
    float timeUntilNextShot; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time> timeUntilNextShot)
        {
            canShoot = true;
        }

        if (Input.GetMouseButton(0) && canShoot == true)
        {
            canShoot = false;
            timeUntilNextShot = Time.time + timeBetweenShots;      // Time since the game started + time between shots (1 second)
            Instantiate(bullet, this.transform.position, this.transform.rotation);
        }

    }
}
