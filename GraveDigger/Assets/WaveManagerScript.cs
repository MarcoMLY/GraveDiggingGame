using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.WSA;

public class WaveManagerScript : MonoBehaviour
{

	[SerializeField] GameObject zombiePrefab;
	[SerializeField] GameObject zombieParent;
	[SerializeField] GameObject zombieSpawn;

	[SerializeField] TMP_Text waveText;

	int currentZombies = 0;
	int currentWave = 0;
	int newZombies = 5;

	int spawnradius = 1;

	bool waveEnded = true;


	// Start is called before the first frame update
	void Start()
	{
		waveEnded = true;
	}

	// Update is called once per frame
	void Update()
	{
		currentZombies = zombieParent.transform.childCount;
		if (waveEnded)
		{

			waveEnded = false;
			currentWave += 1;
			waveText.text = "Wave " + currentWave.ToString();

			newZombies *= 2;

			print(newZombies);
			spawnError();
			for (int i = 0; i < newZombies; i++)
			{
				StartCoroutine(spawn());
			}

			currentZombies = newZombies;	
		}

		if (currentZombies == 0 && !waveEnded)
		{
			// wait intermission time
			waveEnded = true;
		}
	}

	IEnumerator spawn()
	{
		yield return new WaitForSeconds(Random.Range(0.05f, 2f));

		GameObject clone = Instantiate(zombiePrefab);
		clone.transform.SetParent(zombieParent.transform, false);

		int x = Random.Range(-spawnradius, spawnradius);
		int y = Random.Range(-spawnradius, spawnradius);
		Vector3 spawnpoint = new Vector3(zombieSpawn.transform.position.x + x, zombieSpawn.transform.position.y + y, zombieSpawn.transform.position.z);
		clone.transform.position = spawnpoint;
	}

	void spawnError()
	{
		GameObject clone = Instantiate(zombiePrefab);
		clone.transform.SetParent(zombieParent.transform, false);

		int x = Random.Range(-spawnradius, spawnradius);
		int y = Random.Range(-spawnradius, spawnradius);
		Vector3 spawnpoint = new Vector3(zombieSpawn.transform.position.x + x, zombieSpawn.transform.position.y + y, zombieSpawn.transform.position.z);
		clone.transform.position = spawnpoint;
	}
}
