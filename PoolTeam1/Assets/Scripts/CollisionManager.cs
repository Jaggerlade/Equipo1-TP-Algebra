using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollisionManager : MonoBehaviour
{
    public static CollisionManager instance;
    public List<Balls> balls = new List<Balls>();
    void Awake()
    {
        instance = this;
       
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < balls.Count; i++)
        {
            for (int j = 0; j < balls.Count; j++)
            {
                if (balls[i] = balls[j])
                {
                    return;
                }
                else
                {/*
                    if (balls[i].ballMovement.transform.position + balls[j].ballMovement.transform.position
                        <= balls[i].radius+balls[j].radius){
                        balls[j].Speed=balls[j].transformation.position-balls[i].transformation.position;
                        float prodEscalar = (balls[i].Speed.x+balls[j].Speed.x)*(balls[i].Speed.y+balls[j].Speed.y);
                        float angulo1 = Mathf.Acos(prodEscalar/(Mathf.Sqrt((Mathf.Pow(balls[i].Speed.x,2)+(Mathf.Pow(balls[i].Speed.y,2)*(Mathf.Pow(balls[j].Speed.x,2)+(Mathf.Pow(balls[j].Speed.y,2));
                        ball[j].Speed.x = (ball[j].Speed.x*Mathf.Cos(angulo1));
                        ball[j].Speed.y = (ball[j].Speed.x*Mathf.Cos(angulo1));
                        float angulo2 = 90-angulo1;
                        ball[i].Speed.x = (ball[i].Speed.x*Mathf.Cos(angulo1));
                        ball[i].Speed.y = (ball[i].Speed.x*Mathf.Cos(angulo1));
                    }
                */
                }
            }
        }
       

     
    }
}
