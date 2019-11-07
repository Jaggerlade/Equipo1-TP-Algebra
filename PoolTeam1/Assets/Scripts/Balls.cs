using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    
    [HideInInspector] public BallMovement ballMovement;
    void Start()
    {
        ballMovement = gameObject.AddComponent<BallMovement>(); 
        CollisionManager.instance.balls.Add(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
