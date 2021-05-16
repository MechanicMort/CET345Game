using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WUG.BehaviorTreeVisualizer;

public abstract class Node : NodeBase
{
    //Keeps track of the number of times the node has been evaluated in a single 'run'.
    public int EvaluationCount;
    private string m_LastStatusReason { get; set; } = "";
    // Runs the logic for the node
    public virtual NodeStatus Run()
    {
        NodeStatus nodeStatus = OnRun();

        //Start of new code
        if (LastNodeStatus != nodeStatus || !m_LastStatusReason.Equals(StatusReason))
        {
            LastNodeStatus = nodeStatus;
            m_LastStatusReason = StatusReason;
            OnNodeStatusChanged(this);
        }
        //End of new code

        EvaluationCount++;

        if (nodeStatus != NodeStatus.Running)
        {
            Reset();
        }

        return nodeStatus;
    }

    public void Reset()
    {
        EvaluationCount = 0;
        OnReset();
    }

    protected abstract NodeStatus OnRun();
    protected abstract void OnReset();
}
