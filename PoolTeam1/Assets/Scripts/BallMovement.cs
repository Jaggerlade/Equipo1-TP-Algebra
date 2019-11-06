using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float mass;
    public float coefOfFriction;
    public float gravity;

    float aceleration;
    float force;
    float time;

    void Start()
    {
        aceleration = 0.0f;
        force = 0.0f;
        time = 0.0f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            time += Time.deltaTime * 3;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            aceleration = time;
            force = mass * aceleration;
            time = 0.0f;
        }

        if (force >= 0.0f)
        {
            transform.Translate(Vector2.up * force * Time.deltaTime);

            force -= CalculateFriction();
        }
    }

    float CalculateFriction()
    {
        float Fr = 0.0f;
        float NormalF = mass * gravity;

        Fr = (coefOfFriction * NormalF) * Time.deltaTime;

        return Fr;
    }
}
