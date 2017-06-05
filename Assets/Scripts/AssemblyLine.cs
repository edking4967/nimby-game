using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class AssemblyLine: MonoBehaviour {

    public List<GameObject> pool;
    public GameObject marker1;	
    public GameObject marker2;	
    public GameObject marker3;	
    public GameObject marker4;	
    public Houses houses;	
    Hashtable objectsToClear;

    float timeSave;

    public GameObject[] positions;
    public int profit = 0;

    public void Start() {

        objectsToClear = new Hashtable();
        houses = GameObject.Find("houses").GetComponent<Houses>();
        pool = new List<GameObject>();

        moveToPool(GameObject.Find("man1"));
        moveToPool(GameObject.Find("man2"));
        moveToPool(GameObject.Find("man3"));
        moveToPool(GameObject.Find("man4"));
        moveToPool(GameObject.Find("man5"));
        moveToPool(GameObject.Find("man6"));
        moveToPool(GameObject.Find("man7"));
        moveToPool(GameObject.Find("1-3"));
        moveToPool(GameObject.Find("2-3"));
        moveToPool(GameObject.Find("3-1"));

        timeSave = Time.time;

        positions = new GameObject[4];

        for (int i=0; i < positions.Length; i++) {
            positions[i] = getRandomActorFromPool();            
        }

        snapToPositions();
    }
    
    void snapToPositions() {
        positions[0].transform.position = marker1.transform.position;
        positions[1].transform.position = marker2.transform.position;
        positions[2].transform.position = marker3.transform.position;
        positions[3].transform.position = marker4.transform.position;
    }

    GameObject getRandomActorFromPool() {
        int randomNum = UnityEngine.Random.Range(0, pool.Count);
        GameObject g = pool[randomNum];
        pool.RemoveAt(randomNum);
        g.GetComponent<SpriteRenderer>().enabled = true;
        g.GetComponent<BoxCollider2D>().enabled = true;
        g.GetComponent<SpriteRenderer>().color = Color.white;
        return g;
    }

    void rotatePositions() {
        GameObject lastActor = positions[positions.Length - 1];
        moveToPool(lastActor);
        for (int i= positions.Length -1; i > 0; i--) {
            positions[i] = positions[i-1];
        }
        positions[0] = getRandomActorFromPool();
        snapToPositions();
    }

    void moveToPool(GameObject g) {
        pool.Add(g);
        g.GetComponent<SpriteRenderer>().enabled = false;
        g.GetComponent<BoxCollider2D>().enabled = false;
    }

    void updateProfit() {
        if (positions[positions.Length - 1].name.Contains("man")) {
            profit++;
            if (profit % 3 == 2) {
                houses.buildHouse();
            }
        }
    }

    public void getRidOf(GameObject g) {
        //g.GetComponent<SpriteRenderer>().color = Color.red;
        try {
            objectsToClear.Add(g, Time.time); 
        }
        catch (ArgumentException e) {
        }
    }

    public float interval = 1f; // seconds between changing positions
    public float clearInterval = .6f; // seconds between changing positions

	public void Update()
	{
        float t = Time.time;
        if (t - timeSave >= interval) {
            rotatePositions();
            updateProfit();
            timeSave = Time.time;
        }
        GameObject rem = null;
        foreach (DictionaryEntry pair in objectsToClear) {
            if (Time.time - (float) pair.Value >= clearInterval) {
                rem = (GameObject) pair.Key;
                break;
            }
        }
        if (rem != null) {
            moveToPool(rem);
            objectsToClear.Remove(rem);
        }
	}

}
