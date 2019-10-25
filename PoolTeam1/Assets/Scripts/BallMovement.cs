using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 2;
    public bool movementIsOn = false;
    public float radius;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            movementIsOn = !movementIsOn;
        }

        if (movementIsOn)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }

       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
