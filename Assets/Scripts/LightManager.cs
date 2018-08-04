using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
	[SerializeField] float lightOnDelay = 5;
	[SerializeField] [Range(0, 1)] float lightOnProbability = 0.1f;

	Light _light;

	bool finished = true;

	void Awake()
	{
		_light = GetComponent<Light>();
	}
	
	void Update()
	{
		if (finished)
		{
			finished = false;
			StartCoroutine(RandomLight());
		}
	}

	IEnumerator RandomLight()
	{
		if (Random.Range(0f, 1f) < lightOnProbability)
		{
			_light.enabled = true;
			yield return new WaitForSeconds(lightOnDelay);
			_light.enabled = false;
		}
		yield return new WaitForSeconds(1);

		finished = true;
	}
}
