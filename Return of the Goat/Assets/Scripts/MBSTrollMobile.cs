using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using Unity.Hierarchy;

public class MBSTrollMobile : MonoBehaviour
{
    
    [SerializeField] Transform[] trnGoats = new Transform[50];
    [SerializeField] float fltSpeed;
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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        isActive = false;
        isDead = false;
        agent.enabled = false;

        MBSFollower[] followers = FindObjectsByType<MBSFollower>(FindObjectsSortMode.None);
        int index = 0;
        foreach (var follower in followers)
        {
            trnGoats[index] = follower.transform;
            index++;
            intMaxGoats = index;
           
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
                        FnActivate();
                        FnSetTarget(i);

                    }


                }
            }

        }
    }

    void FnAdvance()
    {

        for (int i = 0; i < intMaxGoats; i++)
        {
            fltDistance = fltActivateRange *5;

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


    }

    void FnClub(int intTarget)
    {

        
        trnGoats[intTarget].GetComponent<MBSFollower>().FnPanic(transform.position);
        agent.speed = 0;

        StartCoroutine(IEDelay());

    }

    void FnActivate()

    {
        isActive = true;
        agent.enabled = true;
        agent.speed = fltSpeed;
      

    }

    void FnSetTarget(int IntTargetGoat)
    {
        agent.SetDestination(trnGoats[IntTargetGoat].position);
        intCurrentTarget = IntTargetGoat;

    }

    void FnRunAway()
    {


    }


    IEnumerator IEDelay()
    {
        yield return new WaitForSeconds(fltAttackTime);

        agent.speed = fltSpeed;

        yield return null;
    }
}
