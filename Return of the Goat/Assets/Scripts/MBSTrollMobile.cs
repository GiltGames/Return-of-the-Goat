using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.Hierarchy;
using TMPro;

public class MBSTrollMobile : MonoBehaviour
{
    
    [SerializeField] Transform[] trnGoats = new Transform[50];
    [SerializeField] MBSLeaderHits mbsLeader;
    [SerializeField] float fltSpeed;
    [SerializeField] float fltSpeedRun;
    [SerializeField] float fltActivateRange;
    [SerializeField] float fltDistance;
    [SerializeField] float fltStrikeRange;
    [SerializeField] NavMeshAgent agent;
    [SerializeField] bool isActive;
    [SerializeField] bool isDead;
    [SerializeField] int intMaxGoats;
    [SerializeField] int intTrollType;
    [SerializeField] int intCurrentTarget;
    [SerializeField] float fltAttackTime =3;
    [SerializeField] TMP_Text txtSpeech;
    [SerializeField] Transform trnTrollGrave;
    [SerializeField] float fltGraveStopDist;
    [SerializeField] MBSScore mbsScore;
    [SerializeField] Animator anim;

    [Header ("Rising")]
    [SerializeField] bool isUndeground;
    [SerializeField] bool isRising;
    [SerializeField] GameObject gmoEmergePrefab;
    [SerializeField] GameObject gmoEmerge;
    [SerializeField] float fltRiseTime;
    [SerializeField] float fltRiseRate;
    [SerializeField] Transform trnEmergeParent;
    [SerializeField] float fltEmergeHeightOffset;
    [SerializeField] BoxCollider boxCollider;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isActive = false;
        isDead = false;
        agent.enabled = false;
        //agent.SetDestination(transform.position);

        MBSFollower[] followers = FindObjectsByType<MBSFollower>(FindObjectsSortMode.None);
        int index = 0;
        foreach (var follower in followers)
        {
            trnGoats[index] = follower.transform;
            index++;
            intMaxGoats = index;
           
        }
        txtSpeech.text = "Hmmm";
        mbsScore.intGoats = intMaxGoats;
        mbsScore.txtGoatsLeft.text = "Goats left: " + intMaxGoats;

        anim = GetComponent<Animator>();
        anim.SetTrigger("Idle");

        boxCollider = GetComponent<BoxCollider>();
        
        switch (intTrollType)
        {
            case 0:

                agent.enabled = true;

                break;


                case 1:

                isUndeground = true;

                boxCollider.enabled = false;

               


                break;


        }

        


    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            switch (intTrollType)
            {
                case 0:

                    FnAdvance();




                break;

                case 1:
                    FnAdvance();

                break;



            }

        }

        else
        {
            if (isDead)
            {
                FnRunAway();
            }

            else
            {


                for (int i = 0; i < intMaxGoats; i++)
                {
                    fltDistance = (transform.position - trnGoats[i].position).magnitude;

                    if (fltDistance < fltActivateRange)
                    {

                        if (!isUndeground)
                        {
                            FnActivate();
                            FnSetTarget(i);
                        }

                        else
                        {

                            if (!isRising)
                            {
                                FnStartRise();
                            }
                        }
                    }


                }
            }

        }
        if (isRising)
        {
            FnRising();
        }

    }

    void FnAdvance()
    {
        fltDistance = fltActivateRange * 5;
        for (int i = 0; i < intMaxGoats; i++)
        {
          

           

            if ((transform.position - trnGoats[i].position).magnitude < fltDistance)
            {
             
                fltDistance = (transform.position - trnGoats[i].position).magnitude;
                intCurrentTarget = i;

            }

            FnSetTarget(intCurrentTarget);


        }

        if (fltDistance < fltStrikeRange)
        {
            FnClub(intCurrentTarget);

        }

    }

    public void FnButted()
    {
        isDead = true;
        isActive = false;
        agent.SetDestination(trnTrollGrave.position);
        txtSpeech.text = "Ouch!";
        anim.SetTrigger("run");
        agent.speed = fltSpeedRun;


    }

    void FnClub(int intTarget)
    {
        if (trnGoats[intTarget].GetComponent<MBSFollower>().trnFollowing != null)
        {

            mbsLeader.trnLastinLine = trnGoats[intTarget].GetComponent<MBSFollower>().trnFollowing;
        }
        
        trnGoats[intTarget].GetComponent<MBSFollower>().FnPanic(transform.position);


        agent.speed = 0;

        txtSpeech.text = "Hold Still!";
        anim.SetTrigger("attack1");

        StartCoroutine(IEDelay());

    }

    void FnActivate()

    {

       

            isActive = true;
            agent.enabled = true;
            agent.speed = fltSpeed;
        txtSpeech.text = "Goats...";
            anim.SetTrigger("walk");
       


    }

    void FnSetTarget(int IntTargetGoat)
    {
        agent.SetDestination(trnGoats[IntTargetGoat].position);
        intCurrentTarget = IntTargetGoat;
        //txtSpeech.text = "Goat " + intCurrentTarget;
    }

    void FnRunAway()
    {
        if ((trnTrollGrave.position - transform.position).magnitude < fltGraveStopDist)
        {
            agent.enabled = false;
            gameObject.SetActive(false);

        }

    }


    IEnumerator IEDelay()
    {
        yield return new WaitForSeconds(fltAttackTime);

        agent.speed = fltSpeed;

        txtSpeech.text = "Goats...";
        anim.SetTrigger("walk");

        yield return null;
    }


    void FnStartRise()
    {
        isRising = true;
        gmoEmerge= Instantiate(gmoEmergePrefab, trnEmergeParent);
        Vector3 vecEmergePoint = transform.position;
        vecEmergePoint.y = fltEmergeHeightOffset;
        gmoEmerge.transform.position = vecEmergePoint;
        Destroy(gmoEmerge, fltRiseTime);



    }

    void FnRising()
    {
        transform.Translate(Vector3.up * Time.deltaTime * fltRiseRate);


        if(transform.position.y > 0)
        {
            isRising = false;
            boxCollider.enabled = true;
            agent.enabled = true;
            isUndeground = false;

        }

    }

}
