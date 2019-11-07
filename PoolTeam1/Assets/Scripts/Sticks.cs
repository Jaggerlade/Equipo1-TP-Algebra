using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticks : MonoBehaviour
{
    public Camera cam;
    Vector2 mousePos;
    private float Offset = 0;
    

    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, Offset);
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = (mousePos);
        //transform.position = (mousePos);
        

    }
    private void FixedUpdate()
    {
        
    }
}
