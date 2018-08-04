using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class IntroManager : MonoBehaviour {

	[SerializeField] GameObject menu_panel;

	VideoPlayer intro;

	void Awake()
	{
		intro = GetComponent<VideoPlayer>();
		intro.loopPointReached += EndReached;
	}

	void EndReached(VideoPlayer video)
	{
		menu_panel.SetActive(true);
		gameObject.SetActive(false);
	}
}