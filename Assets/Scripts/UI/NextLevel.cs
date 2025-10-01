using UnityEngine.SceneManagement;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string levelName;
    public GameManager gameManager;
    public SceneFader sceneFader;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(levelName);
            gameManager.WinLevel();            
            
        }
    }
}
