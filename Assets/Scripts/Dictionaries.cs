using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dictionaries : MonoBehaviour {
    public Dictionary<string, int> MyDictionary;
    public string[] objectNames;
    public int[] objectCount;

	// Use this for initialization
	void Start () {
        MyDictionary = new Dictionary<string, int>();

        GameObject[] gos = GameObject.FindObjectsOfType(typeof(GameObject)) as GameObject[];

        foreach (GameObject go in gos)
        {
            Debug.Log(go.name);

            if (MyDictionary.ContainsKey(go.name))
                MyDictionary[go.name] += 1;
            else
                MyDictionary.Add(go.name, 1);
        }

        objectNames = new string[MyDictionary.Keys.Count];
        objectCount = new int[MyDictionary.Values.Count];

        MyDictionary.Keys.CopyTo(objectNames, 0);
        MyDictionary.Values.CopyTo(objectCount, 0);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
