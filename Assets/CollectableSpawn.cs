using UnityEngine;
using System.Collections;

public class CollectableSpawn : MonoBehaviour {

    public GameObject collectable;

    // This could be used to generate spawn points
    // public transform[] spawnPoints;

    // Use this for initialization
    void Start()
    {
        // Create object at spawn location
        Rigidbody temp = Instantiate(collectable, transform.position, transform.rotation) as Rigidbody;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
