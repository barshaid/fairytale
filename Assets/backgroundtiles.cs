using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundtiles : MonoBehaviour
{
	public Texture2D map;

	public ColorToPrefab[] colorMappings;
	float d = 1;
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
		d *= -1;
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
			return;


		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			d = d*  -1;
			if (colorMapping.color == pixelColor)
			{
				Vector3 position;
				if (colorMapping.prefab[0].name.Substring(0, 1) == "w")
				{
					position = new Vector3(x * 5, y * 5, -10);
				}
				else if(colorMapping.prefab[0].name.Substring(0, 1) == "c")
				{
					position = new Vector3(x * 5, y * 5-10, 1);
				}
				else
				{
					position = new Vector3(x * 5, y * 5, d);
				}

				Instantiate(colorMapping.prefab[Random.Range(0, colorMapping.prefab.Length)], position, Quaternion.identity, transform);
			}
		}
	}
}
