using Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class WorldManager : MonoBehaviour
{
    public GameObject prefabHex;
    public Material[] mats;

    public int sizeX;
    public int sizeY;

    public static bool running; 

    private static WorldManager instance;

    public Hexagon[,] world;

    private List<Hexagon> path = new List<Hexagon>();

    private void Start()
    {
        instance = this;
        Generate();
    }

    public void Generate()
    {
        if(world != null)
        {
            foreach(Hexagon hexa in world)
            {
                Destroy(hexa.hex);         
            }
        }
        HexMap hm = new HexMap(sizeX, sizeY, mats, prefabHex);
    }

    public void CalculatePath(GameObject _start, GameObject _end)
    {
        Hexagon start = null;
        Hexagon end = null;

        foreach (Hexagon hexa in world)
        {
            if(hexa.hex == _start)
            {
                start = hexa;
            }
            if(hexa.hex == _end)
            {
                end = hexa;
            }
        }
        IList<IAStarNode> returnd = AStar.GetPath(start, end);

        foreach(Hexagon hexa in path)
        {
            hexa.hex.layer = 0;
        }
        path.Clear();
        foreach (IAStarNode node in returnd)
        {
            foreach(Hexagon hexa in world)
            {
                if(hexa == node)
                {
                    path.Add(hexa);
                    if (hexa.hex.layer == 0)
                        hexa.hex.layer = 8;
                }
            }
        }
    }
   

    public static WorldManager GetInstance()
    {
        return instance;
    }
}
