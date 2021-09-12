using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int health; 
    public HealthBar healthBar;

    public float decrease = 0.01f;



    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth; 
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {

            health--;     //new health value = old health value - 1

            healthBar.SetHealth(health);

            // healthBar.transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - decrease, transform.localScale.z);
        }
    }
}
