using Pathing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Hexagon : IAStarNode
{
    public Land land;

    public GameObject hex;

    public int x;
    public int z;

    //this may be kinda cheating but as the goal wont change its possible
    private static int xGoal;
    private static int zGoal;

    public IEnumerable<IAStarNode> Neighbours => HexaNeighbours;

    public List<Hexagon> HexaNeighbours;

    public Hexagon(Land _land, int _x, int _z, GameObject _hex)
    {
        this.land = _land;
        this.x = _x;
        this.z = _z;
        this.hex = _hex;
    }

    public float CostTo(IAStarNode _neighbour)
    {
        foreach (Hexagon neighbor2 in HexaNeighbours)
        {
            if (neighbor2 == _neighbour)
            {
                return (float)neighbor2.land;
            }
        }
        return 0;
    }

    public float EstimatedCostTo(IAStarNode _goal)
    {
        int xcost = xGoal - x;
        int zcost = zGoal - z;
        return xcost + xcost >> 31 ^ xcost >> 31 + zcost + zcost >> 31 ^ zcost >> 31;
    }

    public static void SetEnd(int _x, int _z)
    {
        xGoal = _x;
        zGoal = _z;
    }
}

