using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    static GameManager _instance = null;

	// Use this for initialization
	void Start () {
        if(_instance)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Application.loadedLevelName == "Test_Player_1")
                //Application.LoadLevel("Test_Player_2");
                Application.LoadLevelAdditive("Test_Player_2");
            else if (Application.loadedLevelName == "Test_Player_2")
                Application.LoadLevel("Test_Player_1");
        }

        if (Input.GetButtonDown("Jump"))
            Application.UnloadLevel("Test_Player_2");
	}
}
