using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager_BallWithBall : MonoBehaviour
{
    public static CollisionManager_BallWithBall instance;
    public List<Balls> balls = new List<Balls>();

    const float rightAngle = 90.0f;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ApplyCollisions();
    }

    void ApplyCollisions()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            for (int j = 0; j < balls.Count; j++)
            {
                if (balls[i] != balls[j])
                {
                    if (Vector3.Distance(balls[i].ballMovement.transform.position, balls[j].ballMovement.transform.position)
                        <= balls[i].ballMovement.radius + balls[j].ballMovement.radius)
                    {
                        //bola impactante
                        balls[i].ballMovement.launchDirection = balls[i].transform.position - balls[j].transform.position;
                        float prodEscalar = Vector3.Angle(balls[i].ballMovement.launchDirection, balls[j].ballMovement.launchDirection);
                        balls[i].ballMovement.launchDirection = (balls[i].ballMovement.launchDirection * Mathf.Cos(prodEscalar));

                        //bola impactada
                        float impactingExitAngle = rightAngle - prodEscalar;
                        balls[j].ballMovement.force = balls[j].ballMovement.force + balls[i].ballMovement.force;
                        balls[j].ballMovement.launchDirection = (balls[i].ballMovement.launchDirection * Mathf.Cos(impactingExitAngle));
                        //break;
                        return;
                    }
                }
            }
        }
    }
}
