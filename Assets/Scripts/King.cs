using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class King: MonoBehaviour {

    public GameObject bolt;
    AssemblyLine line;
    float timeSave;
    float boltSpeed = 1.5f;
    float moveSpeed = 2f;
    public Vector2 boltDir = Vector2.zero;
    Vector2 mouse;
    GameObject barrel;

    public void Start() {
        bolt = GameObject.Find("bolt");
        line = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
        timeSave = Time.time;
        barrel = GameObject.Find("barrel");
        barrel.GetComponent<Animator>().StartPlayback();
    }

    public float interval=.67f;

	void FixedUpdate () {

        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKey(KeyCode.LeftArrow))
            move(Vector2.left, Time.deltaTime);
        if(Input.GetKey(KeyCode.RightArrow))
            move(Vector2.right, Time.deltaTime);
        if(Input.GetKeyDown(KeyCode.Space)) {
            barrel.GetComponent<Animator>().StopPlayback();
            barrel.GetComponent<Rigidbody2D>().isKinematic = false;
        }
	}

    void move(Vector2 direction, float time) {
        transform.position += (Vector3) direction * time * moveSpeed;
    }
}
