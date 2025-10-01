using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject UI;

    public SceneFader sceneFader;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }

    }

    public void Toggle()
    {
        UI.SetActive(!UI.activeSelf);

        if (UI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        Toggle();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        Health.dead = false;
    }

    public void Menu()
    {
        Toggle();
        sceneFader.FadeTo("MainMenu");
        Health.dead = false;
    }
}
