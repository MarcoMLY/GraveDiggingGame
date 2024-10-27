using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class WaveManagerScript : MonoBehaviour
{

	[SerializeField] GameObject zombiePrefab;
	[SerializeField] GameObject zombieParent;
	int currentZombies = 0;
	int currentWave = 0;
	int newZombies = 2;

	bool waveEnded = true;


	// Start is called before the first frame update
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

		currentZombies = zombieParent.transform.childCount;
		if (waveEnded)
		{

			newZombies *= 5;

			print(newZombies);

			for (int i = 0; i < newZombies; i++)
			{
				GameObject clone = GameObject.Instantiate(zombiePrefab);
				clone.transform.SetParent(zombieParent.transform, true);

				StartCoroutine(wait());
			}

			currentZombies = newZombies;
			waveEnded = false;
		}


		if (currentZombies == 0)
		{
			waveEnded = true;
			currentWave += 1;
		}
	}

	IEnumerator wait()
	{
		yield return new WaitForSeconds(0.5f);
	}
}
