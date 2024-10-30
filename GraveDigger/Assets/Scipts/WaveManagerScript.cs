using JetBrains.Annotations;
using Pathfinding.Serialization;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Data;
using UnityEngine.InputSystem.Interactions;

public class WaveManagerScript : MonoBehaviour
{
	/*
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
		}*/

	public GameObject _zombiePrefab;
	public GameObject _gravePrefab;
	public GameObject _zombieHolder;
	public TransformListHolder _gravesList;
	public TMP_Text _waveText;


	public int newZombies = 4;
	public int currentZombies = 0;
	public int newGraves = 2;

	public int currentWave = 0;

	public bool waveStarted = false;
	public bool gravesDestroyed = true;

	float intermissionTime = 10;

	float pTime;
	int spawnradius = 2;

	private void Start()
	{
        _gravesList.ClearData();
        pTime = Time.time;
	}

	private void Update()
	{
		currentZombies = _zombieHolder.transform.childCount;
		if (_gravesList.Variable.Count == 0)
		{
			gravesDestroyed = true;
		}
		if(currentZombies == 0 && waveStarted)
		{
			print("current zombies 0");
			waveStarted = false;
			pTime = Time.time;
			currentWave += 1;
			_waveText.text = "Wave " + currentWave.ToString();
			//newZombies = newZombies + 4 + currentWave * 2;
			//newGraves = currentWave + 2;
		}

		if(!waveStarted && gravesDestroyed)
		{
			//print("spawninggraves");
			Debug.Log((intermissionTime - (Time.time - pTime)).ToString());
			_waveText.text = Mathf.RoundToInt(intermissionTime - (Time.time - pTime)).ToString();
			if (Mathf.RoundToInt(Time.time - pTime) == intermissionTime)
			{
				//print("entered if statement");
				gravesDestroyed = false;
				Spawn_Graves();
			}
		}
		if(!waveStarted && !gravesDestroyed)
		{
			//same number of zombies spawn at all graves
			_waveText.text = "Wave " + currentWave.ToString();
			waveStarted = true;

			StartCoroutine(Spawn_Zombies(0, _gravesList.Variable[0].transform));
			for (int z = 0; z < _gravesList.Variable.Count - 1; z++)
			{
				for (int i = 0; i < newZombies; i++)
				{
					float t = Random.Range(0.05f, 5f);
					Transform graveToSpawnAt = _gravesList.Variable[z].transform;
					Spawn_Zombies(t, graveToSpawnAt);
				}
			}
		}
	}

	IEnumerator Spawn_Zombies(float t, Transform graveToSpawnAt)
	{
		yield return new WaitForSeconds(t);

		GameObject clone = Instantiate(_zombiePrefab);
		clone.transform.SetParent(_zombieHolder.transform, false);

		int x = Random.Range(-spawnradius, spawnradius);
		int y = Random.Range(-spawnradius, spawnradius);
		Vector3 spawnpoint = new Vector3(graveToSpawnAt.position.x + x, graveToSpawnAt.position.y + y, graveToSpawnAt.position.z);
		clone.transform.position = spawnpoint;
	}

	void Spawn_Graves()
	{
		for (int i = 0; i < newGraves; i++)
		{
			// find random location and place there
			int x = Random.Range(-20, 20);
			int y = Random.Range(-20, 20);

			GameObject clone = Instantiate(_gravePrefab);
			clone.transform.position = new Vector3(x, y, 0);
		}
	}

}
