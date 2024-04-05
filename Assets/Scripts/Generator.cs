using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public Texture2D map;
    public ColorToPrefab[] mappings;
    public float size = 5;

    private void Start()
    {
        Generate();
    }

    public void Generate()
    {
        for(int x=0; x<map.width; x++)
        {
            for(int y=0; y<map.height; y++)
            {
                Color c = map.GetPixel(x, y);
                foreach( var m in mappings )
                {
                    if(m.color == c)
                    {
                        GameObject prefab = m.prefab;
                        Vector3 pos = new Vector3(x, 0, y) * size;
                        Instantiate(prefab, pos, Quaternion.identity, transform);
                    }
                }
            }
        }
    }

    public class ColorToPrefab
    {
        public Color color;
        public GameObject prefab;
    }
}
