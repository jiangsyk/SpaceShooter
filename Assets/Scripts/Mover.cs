using UnityEngine;
using System.Collections;

//Author:Luna
public class Mover : MonoBehaviour
{
    public float speed = 3;
    void Start()
    {

    }

    void FixedUpdate()
    {
        rigidbody.velocity = Vector3.up * speed;
    }
}
