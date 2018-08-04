using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	[SerializeField] GameObject transitionPanel;
	[SerializeField] Animator titleAnimator;
	[SerializeField] AudioSource menu_music;

	bool transitionEnabled = false;
	bool transitionFinished = true;

	Color color = Color.black;
	float a = 0;

	public void EnableTransition()
	{
		GetComponent<Image>().enabled = false;
		transform.GetChild(0).gameObject.SetActive(false);

		titleAnimator.SetTrigger("moveDown");

		transitionPanel.SetActive(true);
		transitionEnabled = true;
	}

	void Update()
	{
		if (transitionEnabled)
		{
			if (a >= 1)
				SceneManager.LoadScene(1);

			if (transitionFinished)
			{
				transitionFinished = false;
				StartCoroutine(Transition());
			}
		}
	}

	IEnumerator Transition()
	{
		a += .005f;
		color.a = a;
		transitionPanel.GetComponent<Image>().color = color;

		menu_music.volume -= .005f;

		yield return new WaitForSeconds(.01f);
		transitionFinished = true;
	}
}