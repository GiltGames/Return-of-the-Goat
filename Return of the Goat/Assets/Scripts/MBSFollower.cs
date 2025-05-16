using UnityEngine;
using UnityEngine.AI;

public class MBSFollower : MonoBehaviour
{
    [SerializeField] Transform trnLeaderTrail;
    public Transform trnFollowing;
       [SerializeField] float fltSpeed;
    [SerializeField] float fltPanicSpeed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float fltRandomWanderRange;
    [SerializeField] Vector3 vecRandomWanderAim;
    [SerializeField] float fltStopDistance;
    [SerializeField] Vector3 vecPanicAim;
    [SerializeField] float fltPanicRange=10;
    public Vector3 vecTrollAttack;



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
        if (trnFollowing.GetComponent<MBSFollower>() != null)
        {
            if (trnFollowing.GetComponent <MBSFollower>().trnFollowing == null)
            {
                
                FnPanic(trnFollowing.GetComponent<MBSFollower>().vecTrollAttack);
                trnFollowing = null;

            }



        }


    }


    void FnWander()
    {
       
        
        agent.enabled = true;

        vecRandomWanderAim = transform.position;
        vecRandomWanderAim.x += Random.Range(-fltRandomWanderRange, fltRandomWanderRange);
        vecRandomWanderAim.z += Random.Range(-fltRandomWanderRange, fltRandomWanderRange);


        agent.SetDestination(vecRandomWanderAim);


    }

    public void FnPanic(Vector3 vecTroll)
    {
        if (trnFollowing != trnLeaderTrail)
        {


        }
        
        // come back to this - have to move TrnLastinLine down 1


            trnFollowing = null;
            vecTrollAttack = vecTroll;
            agent.enabled = true;
            vecPanicAim = (transform.position - vecTroll) * fltPanicRange;
            agent.SetDestination(vecPanicAim);
            agent.speed = fltPanicSpeed;
        
    }

}
