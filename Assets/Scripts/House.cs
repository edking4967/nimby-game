using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class House: MonoBehaviour {
    
    GameObject[] smogs;
    float smogSpeed = .5f;
    public Vector2 smogStartPos;
    public int smogNum = 0;
    float smogInterval = 4f;
    float timeSave;

    public void Start() {
        smogs = new GameObject[] {
            transform.Find("smog0").gameObject,
            transform.Find("smog1").gameObject,
            transform.Find("smog2").gameObject,
            transform.Find("smog3").gameObject,
            transform.Find("smog4").gameObject,
            transform.Find("smog5").gameObject,
            transform.Find("smog6").gameObject,
            transform.Find("smog7").gameObject,
            transform.Find("smog8").gameObject,
        };
        smogInterval += UnityEngine.Random.Range(-.5f, .5f);
        smogSpeed += UnityEngine.Random.Range(-.2f, .2f);

        smogStartPos = smogs[0].transform.position;
        timeSave = Time.time;
    }

    public void hideSmogs() {
        for (int i=0; i<smogs.Length; i++) {
            smogs[i].GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    
    public void Update() {
        if (!GetComponent<SpriteRenderer>().enabled) {
        return;
        }
        for (int i =0; i<=smogNum; i++)
        {
            smogs[i].transform.position += Vector3.up * smogSpeed * Time.deltaTime;
        }
        if (Time.time - timeSave >= smogInterval) {
            if (smogNum < (smogs.Length - 1)) 
                smogNum++;
            smogs[smogNum].GetComponent<SpriteRenderer>().enabled = true;
            timeSave = Time.time;
            smogInterval += UnityEngine.Random.Range(-.5f, .5f);
        }
    } 
}
