using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticks : MonoBehaviour
{
    int speed = 15;
    public Camera cam;
    [HideInInspector] public Vector2 mousePos;

    private float Offset = 5;
    GameObject blanca;

    void Start()
    {
        blanca = GameObject.FindGameObjectWithTag("Blanca");
        FindObjectOfType<Balls>();
        transform.position = new Vector3(transform.position.x, transform.position.y, Offset);
    }
    
    void Update()
    {
        mousePos = (Vector2)cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 a = ((Vector2)blanca.transform.position - mousePos);
        a.Normalize();
        a *= 2;
        transform.position = (Vector2)blanca.transform.position;
        LookAtWhiteBall();
    }

    void LookAtWhiteBall()
    {
        Vector2 blancaDirection = (Vector2)blanca.transform.position - mousePos;
        float angle = Mathf.Atan2(blancaDirection.y, blancaDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.deltaTime);
    }
}
