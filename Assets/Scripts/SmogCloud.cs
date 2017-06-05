using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SmogCloud: MonoBehaviour {

    GameObject[] smogs;
    int smogNum = 0;
    Hashtable ht;

    public void Start() {
        ht = new Hashtable();
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
            transform.Find("smog9").gameObject,
            transform.Find("smog10").gameObject,
            transform.Find("smog11").gameObject,
            transform.Find("smog12").gameObject,
        };
    }
    public void OnTriggerEnter2D(Collider2D hit) {

        if (hit.gameObject.tag == "smog") {
            incrementTable(hit.transform.parent.name);
            hit.transform.position = hit.transform.parent.gameObject.GetComponent<House>().smogStartPos; 
            Vector2 vec = smogs[smogNum].transform.position;
            vec.x = hit.transform.position.x;
            smogs[smogNum].transform.position = vec;
            smogs[smogNum].GetComponent<SpriteRenderer>().enabled = true;

            if (smogNum < smogs.Length - 1) {
                smogs[smogNum].transform.localScale += smogs[smogNum].transform.localScale * .2f * (int) ht[hit.transform.parent.name]; 
                smogNum++;
            } 
        }
    }

    public void incrementTable(string name) {
        if (!ht.ContainsKey(name))
            ht.Add(name, 0);
        else
            ht[name] = (int) ht[name] + 1;
    }
}
