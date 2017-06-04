using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class King: MonoBehaviour {

    public GameObject bolt;
    AssemblyLine line;
    float timeSave;
    float boltSpeed = 1.5f;
    public Vector2 boltDir = Vector2.zero;
    GameObject arm;
    
    Vector2 mouse;

    public void Start() {
        bolt = GameObject.Find("bolt");
        line = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
        timeSave = Time.time;
        arm = GameObject.Find("king-arm");
    }

    public float interval=.67f;
    public void throwBolt(Vector2 direction) {
        bolt.transform.position = transform.position;
        boltDir = direction;
        bolt.GetComponent<SpriteRenderer>().enabled = true;
        /*
        target = null;
        int num;
        List<int> tried = new List<int>();
        while (target == null && tried.Count < line.positions.Length) {
            num = UnityEngine.Random.Range(0, line.positions.Length);
            if (tried.Contains(num)) { 
                continue;
            }

            if (!line.positions[num].name.Contains("man")) {
                target = line.positions[num];
            }
            else {
                target = null;
                tried.Add(num);
            }
        }
        if (target == null) {
            return;
        }
        boltVector = target.transform.position - transform.position;
        boltVector = boltVector / boltVector.magnitude;
        */
    }
	public void Update()
	{
        float t = Time.time;
        /*
        if (t - timeSave >= interval) {
            throwBolt();
            timeSave = Time.time;
        }
        */
        if (boltDir != Vector2.zero) {
            bolt.transform.position += (Vector3)(boltDir * boltSpeed);
        }
	}

	void FixedUpdate () {
        Vector2 armDir;

        mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        armDir = mouse - (Vector2)arm.transform.position;
        arm.transform.up = armDir;

        if(Input.GetMouseButtonDown(0)) {
            throwBolt(armDir / armDir.magnitude * boltSpeed);
        }
	}
}
