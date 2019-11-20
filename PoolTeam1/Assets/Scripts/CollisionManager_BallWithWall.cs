using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager_BallWithWall : MonoBehaviour
{
    public static CollisionManager_BallWithWall instance;
    public List<Balls> balls = new List<Balls>();
    public List<Walls> walls = new List<Walls>();

    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < balls.Count; i++)
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

            Debug.Log(balls[1].ballMovement.launchDirection);
        }
    } 
}