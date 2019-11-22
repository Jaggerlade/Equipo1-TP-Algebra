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

    float translateOnX;
    float translateOnY;

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
                            /*translateOnX = (walls[j].transform.position.x - balls[i].ballMovement.radius) - balls[i].transform.position.x;
                            translateOnY = (translateOnX / balls[i].ballMovement.launchDirection.x) * balls[i].ballMovement.launchDirection.y;
                            balls[i].transform.Translate(-translateOnX, -translateOnY, 0);*/

                            balls[i].ballMovement.launchDirection.x *= -1;
                        }
                        break;
                    case Walls.Type.Right:
                        if (balls[i].transform.position.x + balls[i].ballMovement.radius >= walls[j].transform.position.x)
                        {
                            /*translateOnX = balls[i].transform.position.x - (walls[j].transform.position.x - balls[i].ballMovement.radius);
                            translateOnY = (translateOnX / balls[i].ballMovement.launchDirection.x) * balls[i].ballMovement.launchDirection.y;
                            balls[i].transform.Translate(-translateOnX, -translateOnY, 0);*/

                            balls[i].ballMovement.launchDirection.x *= -1;
                        }
                        break;
                    case Walls.Type.Upper:
                        if (balls[i].transform.position.y + balls[i].ballMovement.radius >= walls[j].transform.position.y && collisionUpperWall == false)
                        {
                            /*translateOnY = balls[i].transform.position.y - (walls[j].transform.position.y - balls[i].ballMovement.radius);
                            translateOnX = (translateOnX / balls[i].ballMovement.launchDirection.y) * balls[i].ballMovement.launchDirection.x;
                            balls[i].transform.Translate(-translateOnX, -translateOnY, 0);*/

                            balls[i].ballMovement.launchDirection.y *= -1;
                            collisionUpperWall = true;
                        }
                        break;
                    case Walls.Type.Bottom:
                        if (balls[i].transform.position.y - balls[i].ballMovement.radius <= walls[j].transform.position.y && collisionBottomWall == false)
                        {
                            /*translateOnY = (walls[j].transform.position.y - balls[i].ballMovement.radius) - balls[i].transform.position.y;
                            translateOnX = (translateOnX / balls[i].ballMovement.launchDirection.y) * balls[i].ballMovement.launchDirection.x;
                            balls[i].transform.Translate(-translateOnX, -translateOnY, 0);*/

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
 