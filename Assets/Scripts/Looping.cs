using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Looping : MonoBehaviour
{

    public float speed = 2f;
    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(transform.position.x > 18f){
            transform.position = startPos;
        }
    }
}
