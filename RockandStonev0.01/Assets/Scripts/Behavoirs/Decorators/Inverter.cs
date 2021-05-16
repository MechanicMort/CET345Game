using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WUG.BehaviorTreeVisualizer;

public class Inverter : Decorator
{
    public Inverter(string displayName, Node childNode) : base(displayName, childNode) { }

    protected override void OnReset() { }

    protected override NodeStatus OnRun()
    {

        //Confirm that a valid child node was passed in the constructor
        if (ChildNodes.Count == 0 || ChildNodes[0] == null)
        {
            return NodeStatus.Failure;
        }

        //Run the child node
        NodeStatus originalStatus = (ChildNodes[0] as Node).Run();

        //Check the status of the child node and invert if it is Failure or Success
        switch (originalStatus)
        {
            case NodeStatus.Failure:
                return NodeStatus.Success;
            case NodeStatus.Success:
                return NodeStatus.Failure;
        }

        // Otherwise, it's still running or returning an Unknown code
        return originalStatus;

    }
}
