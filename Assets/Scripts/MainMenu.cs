using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public string levelOne;
    public string highScores;

    public void NewGame()
    {
        Application.LoadLevel(levelOne);
    }

    public void HighScores()
    {
        Application.LoadLevel(highScores);
    }

    public void QuitGame()
    {
        Debug.Log("Game Exited");
        Application.Quit();
    }
	
}
