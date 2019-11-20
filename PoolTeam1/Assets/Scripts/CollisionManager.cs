using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    public static CollisionManager instance;
    public List<Balls> balls = new List<Balls>();
    public List<Walls> walls = new List<Walls>();

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
            ApplyBallsCollsions(i);
            ApplyWallsCollsions(i);

            Debug.Log(balls[1].ballMovement.launchDirection);
        }
    }

    void ApplyBallsCollsions(int i)
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

    void ApplyWallsCollsions(int i)
    {
        for (int j = 0; j < walls.Count; j++)
        {
            switch (walls[j].type)
            {
                case Walls.Type.Left:
                    if (balls[i].transform.position.x + balls[i].ballMovement.radius >= walls[j].transform.position.x)
                    {
                        balls[i].ballMovement.launchDirection.x *= -1;
                    }
                    break;
                case Walls.Type.Right:
                    if (balls[i].transform.position.x - balls[i].ballMovement.radius <= walls[j].transform.position.x)
                    {
                        balls[i].ballMovement.launchDirection.x *= -1;
                    }
                    break;
                case Walls.Type.Upper:
                    if (balls[i].transform.position.y >= walls[j].transform.position.y)
                    {
                        balls[i].ballMovement.launchDirection.y *= -1;
                        Debug.Log("Colision");
                    }
                    break;
                case Walls.Type.Bottom:
                    if (balls[i].transform.position.y <= walls[j].transform.position.y)
                    {
                        balls[i].ballMovement.launchDirection.y *= -1;
                        Debug.Log("Colision");
                    }
                    break;
            }
        }
    }
}
