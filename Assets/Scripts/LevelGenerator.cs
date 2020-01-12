using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

	public Texture2D map;

	public ColorToPrefab[] colorMappings;

	int count=0;

	void Start()
	{
		GenerateLevel();
	}

	void GenerateLevel()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x, y);
				count++;
			}
		}
		Debug.Log(count);
	}

	void GenerateTile(int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
			return;
		

		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			Debug.Log(pixelColor);
			Debug.Log(colorMapping.color);
			if (colorMapping.color == pixelColor)
			{
				Vector2 position = new Vector2(x, y);
				Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}

}

