using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class WaveManagerScript : MonoBehaviour
{

	[SerializeField] GameObject zombiePrefab;
	[SerializeField] GameObject zombieParent;
	[SerializeField] GameObject zombieSpawn;

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
				StartCoroutine(spawn());
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

	IEnumerator spawn()
	{
		yield return new WaitForSeconds(Random.Range(0.05f, 2f));

		GameObject clone = Instantiate(zombiePrefab);
		clone.transform.SetParent(zombieParent.transform, false);

		int x = Random.Range(-5, 5);
		int y = Random.Range(-5, 5);
		Vector3 spawnpoint = new Vector3(zombieSpawn.transform.position.x + x, zombieSpawn.transform.position.y + y, zombieSpawn.transform.position.z);
		clone.transform.position = spawnpoint;
	}
}
