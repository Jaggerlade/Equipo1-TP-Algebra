using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionManager_BallWithWall : MonoBehaviour
{
    public static CollisionManager_BallWithWall instance;
    public List<Balls> balls = new List<Balls>();
    public List<Walls> walls = new List<Walls>();

    bool collisionUpperWall = false;
    bool collisionBottomWall = false;

    void Awake()
    {
        instance = this;
    }

    void FixedUpdate()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            for (int j = 0; j < walls.Count; j++)
            {
                switch (walls[j].type)
                {
                    case Walls.Type.Left:
                        if (balls[i].transform.position.x - balls[i].ballMovement.radius <= walls[j].transform.position.x)
                        {
                            balls[i].ballMovement.launchDirection.x *= -1;
                        }
                        break;
                    case Walls.Type.Right:
                        if (balls[i].transform.position.x + balls[i].ballMovement.radius >= walls[j].transform.position.x)
                        {
                            balls[i].ballMovement.launchDirection.x *= -1;
                        }
                        break;
                    case Walls.Type.Upper:
                        if (balls[i].transform.position.y >= walls[j].transform.position.y && collisionUpperWall == false)
                        {
                            balls[i].ballMovement.launchDirection.y *= -1;
                            collisionUpperWall = true;
                        }
                        break;
                    case Walls.Type.Bottom:
                        if (balls[i].transform.position.y <= walls[j].transform.position.y && collisionBottomWall == false)
                        {
                            balls[i].ballMovement.launchDirection.y *= -1;
                            collisionBottomWall = true;
                        }
                        break;
                }
            }

            collisionUpperWall = false;
            collisionBottomWall = false;
        }
    } 
}
 