using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private float minXPos;
	private float maxXPos;
	private float minYPos;
	private float maxYPos;

	private const int Z_POSITION = -10;

	// Start is called before the first frame update
	void Start()
    {
		minXPos = Utility.instance.topleftPoint.localPosition.x + 11f;
		maxXPos = Utility.instance.bottomrightPoint.localPosition.x - 9f;
		minYPos = Utility.instance.bottomrightPoint.localPosition.y + 4f;
		maxYPos = Utility.instance.topleftPoint.localPosition.y - 4f;
	}

	// Update is called once per frame
	void Update()
    {
		UpdateCameraPosition();
	}

	void UpdateCameraPosition()
	{
        if (Utility.instance.player != null)
        {
            float currentXPos = Utility.instance.player.transform.localPosition.x;
            float currentYPos = Utility.instance.player.transform.localPosition.y;
            float clampedXPos = Mathf.Clamp(currentXPos, minXPos, maxXPos);
            float clampedYPos = Mathf.Clamp(currentYPos, minYPos, maxYPos);
            transform.position = new Vector3(clampedXPos, clampedYPos, Z_POSITION);
        }
	}
}
