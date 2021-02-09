using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneFader : MonoBehaviour {

	public Image img;
	public AnimationCurve curve;

	void Start ()
	{
		StartCoroutine(FadeIntoTheScene());
	}
    private void OnLevelWasLoaded(int level)
    {
        StartCoroutine(FadeIntoTheScene());
    }
    public void FadeTo (string scene)
	{
		StartCoroutine(FadeOutOfTheScene(scene));
	}

	IEnumerator FadeIntoTheScene ()
	{
		float theTiming = 1f;

		while (theTiming > 0f)
		{
			theTiming -= Time.deltaTime;
			float evaluating = curve.Evaluate(theTiming);
			img.color = new Color (0f, 0f, 0f, evaluating);
			yield return 0;
		}
	}

	IEnumerator FadeOutOfTheScene(string scene)
	{
		float theTiming = 0f;

		while (theTiming < 1f)
		{
			theTiming += Time.deltaTime;
			float evaluating = curve.Evaluate(theTiming);
			img.color = new Color(0f, 0f, 0f, evaluating);
			yield return 0;
		}

		SceneManager.LoadScene(scene);
	}

}
