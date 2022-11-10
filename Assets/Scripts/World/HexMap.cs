using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class HexMap
{
    //movement per hextile
    private readonly float x = 1f;
    private readonly float z = 0.74f;

    private readonly int seed;

    private readonly int sizeX;
    private readonly int sizeZ;

    // // \\ // \\ // \\
    public HexMap(int _sizeX, int _sizeZ)
    {
        this.sizeX = _sizeX;
        this.sizeZ = _sizeZ;

        seed = GenerateSeed();

        GenerateNoise();
    }
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    private void GenerateMap()
    {
    }

    // // \\ // \\ // \\
    private float[,] GenerateNoise()
    {
        float[,] map = new float[sizeX,sizeZ];
        for(int x = 0; x < sizeX; x++)
        {
            for(int z = 0; z < sizeZ; z++)
            {
                float vx = sizeX + seed;
                float vz = sizeZ + seed;
                map[x,z] = Mathf.PerlinNoise(vx, vz);
            }
        }
        return map;
    }
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    private int GenerateSeed()
    {
        System.Random rnd = new System.Random();
        return rnd.Next();
    }
    // \\ // \\ // \\ //

    // // \\ // \\ // \\
    public int GetSeed()
    {
        return seed;
    }
    // \\ // \\ // \\ //
}
