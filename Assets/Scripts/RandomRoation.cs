using UnityEngine;
using System.Collections;

//Author:Luna
public class RandomRoation : MonoBehaviour {

    public float tumble = 5;
	void Start () {
        rigidbody.angularVelocity = Random.insideUnitSphere * tumble;
	}
	
	void Update () {
	}
}
