using UnityEngine;
using System.Collections;

public class SimpleCallback : MonoBehaviour {

    delegate void delegateCaller();
    delegateCaller caller = FunctionToCall;

	// Use this for initialization
	void Start () {
        caller();
	}
	
	static void FunctionToCall () {
        Debug.Log("Function called.");
	}
}
