using UnityEngine;
using UnityEngine.AI;

public class MBSFollower : MonoBehaviour
{

    public Transform trnFollowing;
       [SerializeField] float fltSpeed;
    [SerializeField] float fltPanicSpeed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float fltRandomWanderRange;
    [SerializeField] Vector3 vecRandomWanderAim;
    [SerializeField] float fltStopDistance;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = fltSpeed;

        FnWander();

    }

    // Update is called once per frame
    void Update()
    {
        if (trnFollowing == null)
        {
            if ((agent.destination - transform.position).magnitude < fltStopDistance)
            {
                FnWander();

            }

        }

        else
        {
            agent.destination = trnFollowing.position;

        }

    }

   public void FnFollow()
    {
        agent.destination= trnFollowing.position;



    }


    void FnWander()
    {
       
        
        agent.enabled = true;

        vecRandomWanderAim = transform.position;
        vecRandomWanderAim.x += Random.Range(-fltRandomWanderRange, fltRandomWanderRange);
        vecRandomWanderAim.z += Random.Range(-fltRandomWanderRange, fltRandomWanderRange);


        agent.SetDestination(vecRandomWanderAim);


    }

    

}
