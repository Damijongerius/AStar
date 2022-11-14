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

    public static bool running; 

    private static WorldManager instance;

    public Hexagon[,] world;

    private void Start()
    {
        instance = this;
        HexMap hm = new HexMap(sizeX,sizeY,mats,prefabHex);
    }

    public void CalculatePath(GameObject _start, GameObject _end)
    {
        Debug.Log("calcpath");
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
        Debug.Log(start + "-" + end);
        IList<IAStarNode> returnd = AStar.GetPath(start, end);

        Debug.Log(returnd);
        foreach (IAStarNode node in returnd)
        {
            foreach(Hexagon hexa in world)
            {
                if(hexa == node)
                {
                    if(hexa.hex.layer == 0)
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
