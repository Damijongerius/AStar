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
    public int y;
    public IEnumerable<IAStarNode> Neighbours 
    {
        get;
    }

    public Hexagon(Land land, int x, int y, IEnumerable<IAStarNode> neighbours)
    {
        this.land = land;
        this.x = x;
        this.y = y;
        Neighbours = neighbours;
    }

    public float CostTo(IAStarNode neighbour)
    {
        //foreach 
        throw new System.NotImplementedException();
    }

    public float EstimatedCostTo(IAStarNode goal)
    {
        //calculate distance to goal
        throw new System.NotImplementedException();
    }
}

