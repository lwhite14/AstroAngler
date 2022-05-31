﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flock/Behaviour/Alignment")]
public class AlignmentBehaviour : FilterFlockBehaviour
{
    public override Vector2 calculateMove(FlockAgent agent, List<Transform> context, Flock flock)
    {
        //if no neighbours return no maintain current heading
        if (context.Count == 0)
        {
            return agent.transform.up;
        }
        //add all points together and average
        Vector2 alignmentMove = Vector2.zero;
        List<Transform> filteredContext = (filter == null) ? context : filter.Filter(agent, context);
        foreach (Transform item in filteredContext)
        {
            alignmentMove += (Vector2)item.transform.up;
        }
        alignmentMove /= context.Count;

       
        return alignmentMove;
    }

    
    
}
