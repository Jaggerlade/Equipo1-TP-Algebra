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

    public enum NombreColic
    {
        ball_1,
        ball_2,
        ball_3,
        ball_4,
        ball_5,
        ball_6,
        ball_7,
        ball_8,
        ball_9,
        ball_10,
        ball_11,
        ball_12,
        ball_13,
        ball_14,
        ball_15,
        ball_16,
        walls
    }

    public Tipo tipo;
    public NombreColic nombre;
    [HideInInspector] public NombreColic ultimaColic;
    [HideInInspector] public BallMovement ballMovement;

    void Start()
    {
        ballMovement = gameObject.AddComponent<BallMovement>();
        ballMovement.tipo = tipo;
        ballMovement.nombre = nombre;
        ballMovement.ultimaColic = nombre;

        CollisionManager_BallWithBall.instance.balls.Add(this);
        CollisionManager_BallWithWall.instance.balls.Add(this);
    }
}
