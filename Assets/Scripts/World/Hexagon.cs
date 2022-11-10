using Pathing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : IAStarNode
{
    IEnumerable<IAStarNode> IAStarNode.Neighbours => throw new System.NotImplementedException();

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

