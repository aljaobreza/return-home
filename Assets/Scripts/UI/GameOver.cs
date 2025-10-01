using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;
    public void Retry ()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        Health.dead = false;
    }

    public void Menu()
    {
        sceneFader.FadeTo("MainMenu");
        Health.dead = false;
    }
}
