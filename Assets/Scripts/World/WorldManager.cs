using Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public GameObject prefabHex;
    public Material[] mats;

    public int sizeX;
    public int sizeY;

    private List<Hexagon> world = new List<Hexagon>();

    private void start()
    {
    }
}
