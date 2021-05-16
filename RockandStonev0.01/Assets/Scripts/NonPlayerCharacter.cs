using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WUG.BehaviorTreeVisualizer;

public class NonPlayerCharacter : MonoBehaviour, IBehaviorTree
{
    private Coroutine m_BehaviorTreeRoutine;
    private YieldInstruction m_WaitTime = new WaitForSeconds(.1f);
    public NodeBase BehaviorTree { get; set; }

    private string job;

    private void Update()
    {
        job = GetComponent<Dwarf>().subjectJob;
    }

    private void GenerateBehaviorTree()
    {
        //tree for free subject
        //selector (control subject
                //selector (haul item
                    //ishaul(returns false if there are objects to haul also sets item to haul
                    //sequence(look for item needed to haul
                        //inverter 
                            //areitemsnearby picks up item if near sets waypoint to next item needed or delivery place if inventory full
                        //setnext waypoint
                    //sequencer(navigate
                        //navigate





            //selector(subject job farmer
                    //isFarm(returns false if there are objects to haul also sets item to haul
                    //sequence(look for item needed to haul
                        //inverter 
                            //areitemsnearby picks up item if near sets waypoint to next item needed or delivery place if inventory full
                        //setnext waypoint
                    //sequencer(navigate
                        //navigate
            
        /*
        BehaviorTree = new Selector("Control NPC",
                            new Sequence("Pickup Item",
                                new IsNavigationActivityTypeOf(NavigationActivity.PickupItem),
                                new Selector("Look for or move to items",
                                    new Sequence("Look for items",
                                        new Inverter("Inverter",
                                            new AreItemsNearBy(5f)),
                                        new SetNavigationActivityTo(NavigationActivity.Waypoint)),
                                    new Sequence("Navigate to Item",
                                        new NavigateToDestination()))),
                            new Sequence("Move to Waypoint",
                                new IsNavigationActivityTypeOf(NavigationActivity.Waypoint),
                                new NavigateToDestination(),
                                new Timer(2f,
                                    new SetNavigationActivityTo(NavigationActivity.PickupItem))));
        */
    }

    private IEnumerator RunBehaviorTree()
    {
        while (enabled)
        {
            if (BehaviorTree == null)
            {
                $"{this.GetType().Name} is missing Behavior Tree. Did you set the BehaviorTree property?".BTDebugLog();
                continue;
            }

            (BehaviorTree as Node).Run();

            yield return m_WaitTime;
        }
    }

    private void OnDestroy()
    {
        if (m_BehaviorTreeRoutine != null)
        {
            StopCoroutine(m_BehaviorTreeRoutine);
        }
    }
}
