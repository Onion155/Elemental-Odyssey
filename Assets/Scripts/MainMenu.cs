using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour // this is for button functionality in the MainMenu 
{
   public void GoToScene(string sceneName) // if there are errors with loading scene make sure the scene is in the build scenes!
    {
        SceneManager.LoadScene(sceneName); // loads scene named 
    }

    public void QuitGame() // closes the game
    {
        Application.Quit();
        Debug.Log("Quit Game"); // wont actualkly quit game in editor so this is to ensure it works
    }
}
