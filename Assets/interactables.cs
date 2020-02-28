using UnityEngine;

public class interactables : MonoBehaviour
{

	public Texture2D[] map;

	public ColorToPrefab[] colorMappings;



	public void GenerateLevel(int[] seq)
	{
		for (int i = 0; i < seq.Length - 1; i++)
		{

			for (int x = 0; x < map[seq[i]].width; x++)
			{
				for (int y = 0; y < map[seq[i]].height; y++)
				{
					GenerateTile(x, y, i, map[seq[i]]);
				}

			}
		}
		
	}


void GenerateTile(int x, int y, int offset, Texture2D map)
{
		Color pixelColor = map.GetPixel(x, y);
		if (pixelColor.a < 1)
			return;


		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color == pixelColor)
			{
				Vector3 position;

				position = new Vector3((x+(map.width*offset)) * 5, y * 5);

				Instantiate(colorMapping.prefab[Random.Range(0, colorMapping.prefab.Length)], position, Quaternion.identity, transform);
			}
		}
	}

}