using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SmogCloud: MonoBehaviour {

    GameObject[] smogs;
    Hashtable houseTable;
    float maxSize = 3f;

    public void Start() {
        houseTable = new Hashtable();
        houseTable.Add("house1-1", 0);
        houseTable.Add("house1-2", 1);
        houseTable.Add("house1-3", 2);
        houseTable.Add("house1-4", 3);
        houseTable.Add("house1-5", 4);
        smogs = new GameObject[] {
            transform.Find("smog0").gameObject,
            transform.Find("smog1").gameObject,
            transform.Find("smog2").gameObject,
            transform.Find("smog3").gameObject,
            transform.Find("smog4").gameObject,
            transform.Find("smog5").gameObject
        };
    }
    /*
    public void Update() {
        for (int i=0; i<smogs.Length; i++) {
            smogs[i].transform.Rotate(Vector3.right * Time.deltaTime * 5);
        }
    }
    */
    public void OnTriggerEnter2D(Collider2D hit) {

        if (hit.gameObject.tag == "smog") {
            // Move smog back down to chimney:
            hit.transform.position = hit.transform.parent.gameObject.GetComponent<House>().smogStartPos; 
            // Update scale, position, and visibility of floating smog:
            int smogNum = (int) houseTable[hit.transform.parent.gameObject.name];
            Vector2 vec = smogs[smogNum].transform.position;
            vec.x = hit.transform.position.x;
            smogs[smogNum].transform.position = vec;
            smogs[smogNum].GetComponent<SpriteRenderer>().enabled = true;
            //if (smogs[smogNum].transform.localScale.magnitude < maxSize) {
                //Debug.Log(smogs[smogNum].transform.localScale.magnitude);
                smogs[smogNum].transform.localScale += new Vector3(1,1);//smogs[smogNum].transform.localScale * 1f;
            //} 

        }
    }

}
