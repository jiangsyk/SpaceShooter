using UnityEngine;
using System.Collections;

//Author:Luna
public class PlayerController : MonoBehaviour {

    public float minX = -5.8f;
    public float maxX = 5.8f;
    public float minY = -6.45f;
    public float maxY = 8.65f;

    public float speed = 10;

    public GameObject bullet;
    public Transform firePos;

    public float fireInterval = 0.25f;//发射间隔
    private float nextFire = 0;

    public AudioClip fireAudio;

	void Start () {
	
	}
	
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            Fire();
            nextFire = Time.time + fireInterval;
        }
    }
	void FixedUpdate () {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rigidbody.velocity = new Vector3(h, v, 0) * speed;

        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(x, y, 0);
	}
    public void Fire()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
        audio.PlayOneShot(fireAudio);
    }
}
