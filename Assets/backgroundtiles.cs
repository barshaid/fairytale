﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundtiles : MonoBehaviour
{
	public Texture2D map;

	public ColorToPrefab[] colorMappings;

	void Start()
	{
		GenerateLevel();
		AstarPath.active.Scan();
	}

	void GenerateLevel()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x, y);
			}
		}
	}

	void GenerateTile(int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
			return;


		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color == pixelColor)
			{
				Vector3 position;

				position = new Vector3(x * 5, y * 5 -1, 1);

				Instantiate(colorMapping.prefab[Random.Range(0, colorMapping.prefab.Length)], position, Quaternion.identity, transform);
			}
		}
	}
}