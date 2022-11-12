﻿using Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject prefabHex;
    public Material[] mats;

    public int sizeX;
    public int sizeY;

    private static WorldManager instance;

    public List<Hexagon> world = new List<Hexagon>();

    private void Start()
    {
        instance = this;
        HexMap hm = new HexMap(sizeX,sizeY,mats,prefabHex);
    }
   

    public static WorldManager GetInstance()
    {
        return instance;
    }
}
