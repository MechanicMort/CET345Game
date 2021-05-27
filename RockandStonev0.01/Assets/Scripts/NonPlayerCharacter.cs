using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using WUG.BehaviorTreeVisualizer;

public class NonPlayerCharacter : MonoBehaviour, IBehaviorTree
{
    private Coroutine m_BehaviorTreeRoutine;
    private YieldInstruction m_WaitTime = new WaitForSeconds(.1f);
    public NodeBase BehaviorTree { get; set; }

    private string job;

    private NavMeshAgent navAgent;

    private GameObject[] findingChunks;
    private GameObject[] storageLocations;


    private void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        StartCoroutine(AIRunTime());
    }

    private void Update()
    {
        job = GetComponent<Dwarf>().subjectJob;

    }


    private IEnumerator AIRunTime()
    {
        yield return new WaitForSeconds(0.5f);
        AI();
        StartCoroutine(AIRunTime());

    }


    private void AI()
    {
        if (job == "Hauling")
        {
            //find item if space in inventory
            if (!GetComponent<Dwarf>().isInvFull)
            {
                navAgent.destination = LookForClosestItemToHaul();
            }
            else
            {
                navAgent.destination = LookForSpaceToStore();
            }

        }
    }


    private Vector3 LookForSpaceToStore()
    {
        storageLocations = GameObject.FindGameObjectsWithTag("StorageBuilding");
        for (int i = 0; i < storageLocations.Length; i++)
        {
            if (storageLocations[i].GetComponent<Storage>().isStorageFull == true)
            {
                storageLocations[i] = null;
            }
        }
        float closeness = Mathf.Infinity;
        Vector3 closestPos = new Vector3(0, 0, 0);
        for (int i = 0; i < storageLocations.Length; i++)
        {
            if (storageLocations[i] != null)
            {
                if (Vector3.Distance(storageLocations[i].transform.position, transform.position) < closeness)
                {
                    closeness = Vector3.Distance(storageLocations[i].transform.position, transform.position);
                    closestPos = storageLocations[i].transform.position;
                }
            }
           
        }

        return closestPos;
    }

    private Vector3 LookForClosestItemToHaul()
    {
        findingChunks = GameObject.FindGameObjectsWithTag("ResourceChunk");
        float closeness = Mathf.Infinity;
        Vector3 closestPos = new Vector3(0,0,0);
        for (int i = 0; i < findingChunks.Length; i++)
        {
            if (Vector3.Distance(findingChunks[i].transform.position , transform.position) < closeness)
            {
                closeness = Vector3.Distance(findingChunks[i].transform.position, transform.position);
                closestPos = findingChunks[i].transform.position;
            }
        }

        return closestPos;
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
