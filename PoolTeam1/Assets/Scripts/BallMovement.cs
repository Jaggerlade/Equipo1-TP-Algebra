using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float mass;
    public float gravity;
    public float force;
    public float coefOfFriction;

    float force2;
    float Fr;

    void Start()
    {
        force2 = 0;
        Fr = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            force2 = force;
        }

        //transform.Translate(Vector2.up * force2 * Time.deltaTime);

        if (force2 >= 0)
        {
            transform.Translate(Vector2.up * force2 * Time.deltaTime);

            force2 = force2 - CalculateFriction();
            //Debug.Log(CalculateFriction());

        }
    }

    float CalculateFriction()
    {
        float N = mass * gravity;

        Fr = (coefOfFriction * N) * 0.01f;

        return Fr;
    }
}
