using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerController : MonoBehaviour
{
    public int speed = 10; // public makes variable editable in inspector 
                           // variable type (int) variable name (speed) = variable (10)
    Rigidbody rb;

    public float jumpForce = 8.0f; // float hold decimal values
    bool jumping = false;   // bool (boolean) holds true/ false values

    public bool isDead = false;
    public int health = 10;

    public int score = 0;

    public Text scoreText;
    public Text healthText; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)    // two equal signs checks the value. One equal sign changes the value. 
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.back * speed * Time.deltaTime);
            }

            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (Input.GetButtonDown("Jump") && jumping == false)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                jumping = true; 
            }
        }

        if (health <= 0)
        {
            GameOver(); 
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            jumping = false; 
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            health--; 
        }
    }

    void onTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            score++;
            Destroy(other.gameObject); 
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            health--; 
        }

        if (other.gameObject.CompareTag("Death"))
        {
            GameOver();
        }
    }

    void GameOver ()
    {
        isDead = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}