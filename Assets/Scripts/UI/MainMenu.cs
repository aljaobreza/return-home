using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "LevelSelectGrassland";
    public SceneFader sceneFader;

    public void LevelSelect()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exiting...");
        Application.Quit();
    }

}
