using UnityEngine;
using System.Collections;

public class WorldScript : MonoBehaviour
{

    static GameObject[] spawnerArr = new GameObject[5];
    // Use this for initialization
    void Start()
    {
        // Add Collectable tagged GameObjects to array
        spawnerArr = GameObject.FindGameObjectsWithTag("Collectable");

        foreach (GameObject obj in spawnerArr)
        {
            Debug.Log(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
