using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walls : MonoBehaviour
{
    public enum Type
    {
        Left,
        Right,
        Upper,
        Bottom
    }
    public Type type;

    void Start()
    {
        CollisionManager.instance.walls.Add(this);
    }
    
    void Update()
    {
        
    }
}
