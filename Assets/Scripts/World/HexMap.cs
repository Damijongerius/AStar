using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using Random = UnityEngine.Random;

public class HexMap
{
    //movement per hextile
    private readonly float xm = 1f;
    private readonly float zm = 0.74f;

    private readonly int sizeX;
    private readonly int sizeZ;

    private readonly GameObject prefabHex;
    private readonly Material[] mats;

    // // \\ // \\ // \\
    public HexMap(int _sizeX, int _sizeZ, Material[] _mats, GameObject _prefabHex)
    {
        this.mats = _mats;
        this.prefabHex = _prefabHex;
        this.sizeX = _sizeX;
        this.sizeZ = _sizeZ;


        float[,] map = GenerateNoise();

        GenerateMap(map);
    }
    // \\ // \\ // \\ //

    //instantiate hexagons
    // // \\ // \\ // \\
    private void GenerateMap(float[,] _map)
    {
        Hexagon[,] hexagons = new Hexagon[_map.GetLength(0), _map.GetLength(1)];

        for (int x = 0; x < _map.GetLength(0); x++)
        {
            for (int z = 0; z < _map.GetLength(1); z++)
            {
                Vector3 pos = new Vector3(x * xm, 0, z * zm);

                if (z % 2 == 0)
                    pos = new Vector3(x * xm, 0, z * zm);
                else
                    pos = new Vector3((x * xm) + 0.5f, 0, z * zm);

                GameObject hex = UnityEngine.Object.Instantiate(prefabHex, pos, new Quaternion(0, 0, 0, 0));

                Debug.Log(_map[x, z]);
                hex.GetComponent<MeshRenderer>().material = GetLand();

                Land land = Land.OCEAN;
                hexagons[x, z] = new Hexagon(land, x, z);

                //sub method 
                // // \\ // \\
                Material GetLand()
                {
                    if (_map[x, z] > 0.7f)
                    {
                        land = Land.RIDGE;
                        return mats[3];
                    }

                    if (_map[x, z] > 0.6f)
                    {
                        land = Land.DESERT;
                        return mats[2];
                    }

                    if (_map[x, z] > 0.45f)
                    {
                        land = Land.FOREST;
                        return mats[1];
                    }

                    if (_map[x, z] > 0.30f)
                    {
                        land = Land.PLAINS;
                        return mats[0];
                    }

                    land = Land.OCEAN;
                    return mats[4];
                }
                // \\ // \\ //
            }
        }

        for (int x = 0; x < _map.GetLength(0); x++)
        {
            for (int z = 0; z < _map.GetLength(1); z++)
            {
                
            }
        }
    }
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    private float[,] GenerateNoise()
    {
        (float xOffset,float zOffset) = (Random.Range(-10000f, 10000f), Random.Range(-10000f, 10000f));
        float[,] map = new float[sizeX,sizeZ];
        for(int x = 0; x < sizeX; x++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                map[x,z] = Mathf.PerlinNoise(x * 2f + xOffset, z * 2f + zOffset);
            }
        }
        return map;
    }
    // \\ // \\ // \\ //
}
