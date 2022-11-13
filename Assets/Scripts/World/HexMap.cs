using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using static UnityEditor.PlayerSettings;
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

                Land land = Land.OCEAN;
                hex.GetComponent<MeshRenderer>().material = GetLand();
                hex.name = $"{x}-{z}";
                hex.AddComponent<BoxCollider>();

                if(land == Land.OCEAN)
                {
                    hex.layer = 4;
                }
                hexagons[x, z] = new Hexagon(land, x, z, hex);

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
                List<Hexagon> neighbours = new List<Hexagon>();

                if (z % 2 == 0)
                {
                    if (z + 1 < _map.GetLength(1))
                    {
                        if(hexagons[x, z + 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x, z + 1]);
                    }
                    if (x + 1 < _map.GetLength(0) && z + 1 < _map.GetLength(1))
                    {
                        if (hexagons[x + 1, z + 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x + 1, z + 1]);
                    }
                    if (x - 1 >= 0)
                    {
                        if (hexagons[x - 1 , z].land != Land.OCEAN)
                            neighbours.Add(hexagons[x - 1, z]);
                    }
                    if (x + 1 < _map.GetLength(0))
                    {
                        if (hexagons[x + 1, z].land != Land.OCEAN)
                            neighbours.Add(hexagons[x + 1, z]);
                    }
                    if (z - 1 >= 0)
                    {
                        if (hexagons[x, z - 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x, z - 1]);
                    }
                    if (x + 1 < _map.GetLength(0) && z - 1 >= 0)
                    {
                        if (hexagons[x + 1, z - 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x + 1, z - 1]);
                    }
                }
                else
                {
                    if (x - 1 >= 0 && z + 1 < _map.GetLength(1))
                    {
                        if (hexagons[x - 1, z + 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x - 1, z + 1]);
                    }
                    if (z + 1 < _map.GetLength(1))
                    {
                        if (hexagons[x, z + 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x, z + 1]);
                    }
                    if (x - 1 >= 0)
                    {
                        if (hexagons[x - 1, z].land != Land.OCEAN)
                            neighbours.Add(hexagons[x - 1, z]);
                    }
                    if (x + 1 < _map.GetLength(0))
                    {
                        if (hexagons[x + 1, z].land != Land.OCEAN)
                            neighbours.Add(hexagons[x + 1, z]);
                    }
                    if (z - 1 >= 0)
                    {
                        if (hexagons[x, z - 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x, z - 1]);
                    }
                    if (x - 1 >= 0 && z - 1 >= 0)
                    {
                        if (hexagons[x - 1, z - 1].land != Land.OCEAN)
                            neighbours.Add(hexagons[x - 1, z - 1]);
                    }
                }
                hexagons[x,z].HexaNeighbours = neighbours;
            }
        }

        WorldManager.GetInstance().world = hexagons;
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
