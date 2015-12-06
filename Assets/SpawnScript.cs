using UnityEngine;
using System.Collections;

public class SpawnScript : MonoBehaviour {

    public GameObject[] randomObject;
	// Use this for initialization
	void Start () {
        int r = Random.Range(0, 3);
        Rigidbody temp = Instantiate(randomObject[r], transform.position, transform.rotation) as Rigidbody;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
