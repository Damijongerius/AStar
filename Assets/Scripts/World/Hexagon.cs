using Pathing;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Hexagon : IAStarNode
{
    public IEnumerable<IAStarNode> Neighbours 
    {
        get;
        set;
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

