using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnded = false;

    public GameObject gameOverUI;
    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    void Update()
    {
        if (gameEnded)
            return;

        if(Health.dead == true)
        {
            EndGame();
        }
    }
    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);

    }

    public void WinLevel()
    {
        Debug.Log("WON");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
    }
}
