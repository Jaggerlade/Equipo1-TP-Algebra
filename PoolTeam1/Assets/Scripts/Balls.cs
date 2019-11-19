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
    }
    public Tipo tipo;
    [HideInInspector] public BallMovement ballMovement;
    void Start()
    {
        ballMovement = gameObject.AddComponent<BallMovement>();
        ballMovement.tipo = tipo;
        CollisionManager.instance.balls.Add(this);
    }

    void Update()
    {

    }

}
