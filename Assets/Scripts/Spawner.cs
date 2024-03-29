﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
	[SerializeField] int currentEnemeries;

	private const int MAXIMUM_ENEMIES = 100;

    // Start is called before the first frame update
    void Start()
    {
		SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {

	}

	void SpawnEnemies()
	{
		if (currentEnemeries < MAXIMUM_ENEMIES)
		{
			Vector2 spawnPoint = GenerateRandownSpawnPoint();
			bool isSkeleton = Random.Range(0, 2) == 0 ? true : false;
			if (isSkeleton)
			{
				Instantiate(Utility.instance.skeletonPrefab, spawnPoint, Quaternion.identity);
			}
			else
			{
				Instantiate(Utility.instance.wizardPrefab, spawnPoint, Quaternion.identity);
			}

			currentEnemeries++;
		}

		Invoke("SpawnEnemies", 0.5f);
	}

	Vector2 GenerateRandownSpawnPoint()
	{
		float posX = Random.Range(Utility.instance.topleftPoint.localPosition.x, Utility.instance.bottomrightPoint.localPosition.x);
		float posY = Random.Range(Utility.instance.bottomrightPoint.localPosition.y, Utility.instance.topleftPoint.localPosition.y);
		return new Vector2(posX, posY);
	}
}
