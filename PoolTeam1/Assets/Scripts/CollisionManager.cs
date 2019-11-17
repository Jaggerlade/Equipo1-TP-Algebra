using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager instance;
    public List<Balls> balls = new List<Balls>();

    const float rightAngle = 90.0f;

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void LateUpdate()
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
                        balls[j].ballMovement.launchDirection = balls[j].transform.position - balls[i].transform.position;

                        float prodEscalar = (balls[i].ballMovement.launchDirection.x + balls[j].ballMovement.launchDirection.x) * (balls[i].ballMovement.launchDirection.y + balls[j].ballMovement.launchDirection.y);
                        float impactedExitAngle = Mathf.Acos(prodEscalar / (Mathf.Sqrt((Mathf.Pow(balls[i].ballMovement.launchDirection.x, 2) + (Mathf.Pow(balls[i].ballMovement.launchDirection.y, 2) * (Mathf.Pow(balls[j].ballMovement.launchDirection.x, 2) + (Mathf.Pow(balls[j].ballMovement.launchDirection.y, 2))))))));

                        balls[j].ballMovement.launchDirection = (balls[j].ballMovement.launchDirection * Mathf.Cos(impactedExitAngle));
                        float impactingExitAngle = rightAngle - impactedExitAngle;
                        balls[i].ballMovement.launchDirection = (balls[i].ballMovement.launchDirection * Mathf.Cos(impactingExitAngle));
                        return;
                    }
                }
            }
        }
    }

  
}
