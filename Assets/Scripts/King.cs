using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class King: MonoBehaviour {

    public GameObject bolt;
    AssemblyLine line;
    float timeSave;
    Vector3 boltVector;
    float boltSpeed = 1.5f;
    GameObject target = null;

    public void Start() {
        bolt = GameObject.Find("bolt");
        line = GameObject.Find("assemblyLine").GetComponent<AssemblyLine>();
        timeSave = Time.time;
    }

    public float interval=.67f;
    public void throwBolt() {
        bolt.transform.position = transform.position;
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
    }
	public void Update()
	{
        float t = Time.time;
        if (t - timeSave >= interval) {
            throwBolt();
            timeSave = Time.time;
        }
        if (target != null) {
            bolt.transform.position += boltVector * boltSpeed;
        }
	}
}
