using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
	public static Utility instance;

	public GameObject enemyPrefab;
	public Transform topleftPoint;
	public Transform bottomrightPoint;
	public Transform player;

	private void Awake()
	{
		instance = this;	
	}
}
