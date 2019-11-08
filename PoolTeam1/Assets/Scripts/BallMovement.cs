using UnityEngine;


public class BallMovement : MonoBehaviour
{
    public float mass;
    public float coefOfFriction;
    public float gravity;

    float aceleration;
    float force;
    float time;
    float speed;
    
    Vector3 launchDirection;

    public GameObject blanca;

    public float radius;

    void Start(){
        aceleration = 0.0f;
        force = 0.0f;
        time = 0.0f;
        launchDirection = Vector3.zero;
    }
    void FixedUpdate(){

        if (Input.GetKey(KeyCode.Mouse0)){
            time += Time.deltaTime * 3;
            /*
            La acumulacion no deberia ser infinita. Tal vez poner if(time<=10.0)?
            Para poder hacer que la direccion de la pelota sea en base a donde se clickeo:
            */
            launchDirection = blanca.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0)){
            aceleration = time;
            force = mass * aceleration;
            time = 0.0f;
        }
        if (force >= 0.0f){

            transform.Translate(launchDirection * force * Time.deltaTime);

            force -= CalculateFriction();
        }
    }
    float CalculateFriction(){
        float Fr = 0.0f;
        float NormalF = mass * gravity;

        Fr = (coefOfFriction * NormalF) * Time.deltaTime;

        return Fr;
    }
    private void OnDrawGizmos(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
   
}
