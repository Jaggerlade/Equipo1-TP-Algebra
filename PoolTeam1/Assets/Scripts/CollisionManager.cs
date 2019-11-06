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
                {
                    /*if (balls[i].ballMovement.transform.position + balls[j].ballMovement.transform.position
                        <= )
                    {

                    }*/
                }
            }
        }
       

     
    }
}
