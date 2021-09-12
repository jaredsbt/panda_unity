using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed = 10;
    public float lifetime = 5.0f; 

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifetime); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); 
    }
}
