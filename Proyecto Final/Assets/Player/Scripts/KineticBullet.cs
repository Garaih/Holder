using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticBullet : MonoBehaviour
{
    public float speed;

    void Start()
    {
        
    }
    
    void Update()
    {
        //transform.Translate(transform.forward * speed * Time.deltaTime);

        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
