using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

	float speed = 1f;
	int boundary = 200;
	int width;
	int height;

	void Start()
	{
		width = Screen.width;
		height = Screen.height;

	}

	void Update()
	{
		if (Input.mousePosition.x > width - boundary)
		{
			transform.Translate(new Vector3(0.1f * speed, 0, 0));
		}

		if (Input.mousePosition.x < 0 + boundary)
		{
			transform.Translate(new Vector3(-0.1f * speed, 0, 0));

		}

		if (Input.mousePosition.y > height - boundary)
		{
			transform.Translate(new Vector3(0, 0.1f * speed, 0));
		}

		if (Input.mousePosition.y < 0 + boundary)
		{
			transform.Translate(new Vector3(0,-0.1f * speed, 0));
		}

	}
}
