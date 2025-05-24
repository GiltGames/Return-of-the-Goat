using UnityEngine;
using UnityEngine.AI;

public class MBSFollower : MonoBehaviour
{
    [SerializeField] Transform trnLeaderTrail;
        public Transform trnFollowing;
    [SerializeField] Transform trnGoatFollowed;
       [SerializeField] float fltSpeed;
    [SerializeField] float fltPanicSpeed;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] float fltRandomWanderRange;
    [SerializeField] Vector3 vecRandomWanderAim;
    [SerializeField] float fltStopDistance;
    [SerializeField] Vector3 vecPanicAim;
    [SerializeField] float fltPanicRange=10;
    public Vector3 vecTrollAttack;
    [SerializeField] Animator anim;
    [SerializeField] bool isWalking;

    [SerializeField] Transform trnFinal;
    [SerializeField] MBSScore mbsScore;
    [SerializeField] MBSTimer mbsTimer;
    [SerializeField] int intBaseScore = 500;
    [SerializeField] float fltUnitScore;

    [SerializeField] MBSMinimap mbsMinimap;
    [SerializeField] bool isHome;

    




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        agent.speed = fltSpeed;
        agent.enabled = true;
       
        anim = GetComponent<Animator>();


        mbsMinimap = GetComponent<MBSMinimap>();

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

            if ( trnGoatFollowed.GetComponent<MBSFollower>() != null)
            {

                if (trnGoatFollowed.GetComponent<MBSFollower>().trnFollowing == null)
                {
                    FnPanic(trnGoatFollowed.GetComponent<MBSFollower>().vecTrollAttack);
                }
            }

        }

        if (agent.velocity.magnitude < .1f)
        {
            anim.SetTrigger("idle");
            isWalking = false;

        }
        else
        {
            if (!isWalking)
            {
                isWalking = true;
                anim.SetTrigger("walk");
            }


        }

        if (isHome)
        {
            transform.Translate(Vector3.forward *fltSpeed *Time.deltaTime);
        }

    }

   public void FnFollow()
    {

        //called from MBSLeaderHit

        agent.destination= trnFollowing.position;

        trnGoatFollowed = trnFollowing.GetComponent<MBSTrailEndPointMarker>().trnTrailStart.GetComponent<MBSTrailpoiint>().trnAttachedGoat;
        
        
        if (trnFollowing == null)
        {
            
                
                FnPanic(trnGoatFollowed.GetComponent<MBSFollower>().vecTrollAttack);
               


        }


    }


    void FnWander()
    {
       
        
        agent.enabled = true;
        agent.speed = fltSpeed;

        vecRandomWanderAim = transform.position;
        vecRandomWanderAim.x += Random.Range(-fltRandomWanderRange, fltRandomWanderRange);
        vecRandomWanderAim.z += Random.Range(-fltRandomWanderRange, fltRandomWanderRange);


        agent.SetDestination(vecRandomWanderAim);


    }

    public void FnPanic(Vector3 vecTroll)
    {
       
      

            trnFollowing = null;
            vecTrollAttack = vecTroll;
            agent.enabled = true;
            vecPanicAim = (transform.position - vecTroll) * fltPanicRange;
            agent.SetDestination(vecPanicAim);
            agent.speed = fltPanicSpeed;
        
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Finish")
        {
            if (!isHome)
            {


                agent.SetDestination(trnFinal.position);
                trnFollowing = trnFinal;

                fltUnitScore = intBaseScore / mbsTimer.fltTimer;

                mbsScore.FnUpdateScore(Mathf.FloorToInt(fltUnitScore));
                mbsScore.FnUpdateGoatCount();
                mbsMinimap.FnMapOff();
                isHome = true;
                transform.Translate(Vector3.forward*.2f);
                Rigidbody rb= GetComponent<Rigidbody>();
                Destroy(rb);

                Transform trnLeader = FindFirstObjectByType<MBSLeaderHits>().transform;
                trnLeader.GetComponent<MBSLeaderHits>().trnLastinLine = trnLeaderTrail;


            }
        }
    }

}
