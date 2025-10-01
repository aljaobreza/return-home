using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFader : MonoBehaviour
{
    public Image img;
    public AnimationCurve curve;
    
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeTo(string scene)
    {
        StartCoroutine(FadeOut(scene));
    }

    IEnumerator FadeIn()
    {
        float t = 0.8f;

        while(t > 0f)
        {
            t -= Time.deltaTime;
            float a = curve.Evaluate(t); //implements the curve
            img.color = new Color (0f, 0f, 0f, a);
            yield return 0; //wait until the next frame
        }


    }

    IEnumerator FadeOut(string scene)
    {
        float t = 0f;

        while (t < 0.8f)
        {
            t += Time.deltaTime;
            float a = curve.Evaluate(t); //implements the curve
            img.color = new Color(0f, 0f, 0f, a);
            yield return 0; //wait until the next frame
        }

        SceneManager.LoadScene(scene);


    }
}
