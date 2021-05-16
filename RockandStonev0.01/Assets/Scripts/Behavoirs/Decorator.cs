using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WUG.BehaviorTreeVisualizer;

public abstract class Decorator : Node
{
    public Decorator(string displayName, Node node)
    {
        Name = displayName;
        ChildNodes.Add(node);
    }
}
