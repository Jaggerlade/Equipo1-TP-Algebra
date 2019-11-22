using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balls : MonoBehaviour
{
    public enum Tipo
    {
        blanca,
        lisa,
        rayada,
        negra
    }
    public Tipo tipo;
    [HideInInspector] public BallMovement ballMovement;
    void Start()
    {
        ballMovement = gameObject.AddComponent<BallMovement>();
        ballMovement.tipo = tipo;

        CollisionManager_BallWithBall.instance.balls.Add(this);
        CollisionManager_BallWithWall.instance.balls.Add(this);
    }

    void Update()
    {

    }

}
