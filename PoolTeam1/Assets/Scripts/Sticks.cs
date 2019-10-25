using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticks : MonoBehaviour
{
    public Camera cam;
    Vector2 mousePos;
    
    

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        

    }
    private void FixedUpdate()
    {
        
    }
}
