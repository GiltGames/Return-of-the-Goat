using UnityEngine;

public class MBSRock : MonoBehaviour
{
    [SerializeField] Transform[] trnGoats = new Transform[50];
    [SerializeField] Vector3 vecRockTarget;
    [SerializeField] Vector3 vecRockDirection;
    [SerializeField] float fltRockSpeed;
    [SerializeField] float fltDistance;
    [SerializeField] float fltRockHitDistance;
    [SerializeField] float fltRockScatterDistance;
    [SerializeField] float fltRockScatterTriggerDistance;
    [SerializeField] bool isScattering;
    [SerializeField] GameObject gmoImpactPrefab;
    [SerializeField] GameObject gmoImpact;
    [SerializeField] MBSLeaderHits mbsLeader;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mbsLeader = FindFirstObjectByType<MBSLeaderHits>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vecRockDirection * Time.deltaTime);

        fltDistance = (transform.position - vecRockTarget).magnitude;

        if (fltDistance < fltRockScatterTriggerDistance )
        {
            if (!isScattering)
            {

                FnScatterGoats();
            }
        }

        if (fltDistance < fltRockHitDistance)
        {


            FnCrash();

        }


    }

    public void FnInitiate(Vector3 vecTarget)
    {
        vecRockTarget = vecTarget;
        vecRockDirection = (vecRockTarget - transform.position).normalized * fltRockSpeed;

    }

    void FnScatterGoats()
    {
       

        MBSFollower[] followers = FindObjectsByType<MBSFollower>(FindObjectsSortMode.None);
        int index = 0;
        foreach (var follower in followers)
        {
            if ((follower.transform.position - transform.position).magnitude < fltRockScatterDistance)
            {
                if (!isScattering)
                {

                    if (follower.GetComponent<MBSFollower>().trnFollowing != null)
                    {

                        mbsLeader.trnLastinLine = follower.GetComponent<MBSFollower>().trnFollowing;
                    }


                    follower.FnPanic(follower.transform.position);
                    isScattering = true;
                }
            }

            

        }


    }
    void FnCrash()
    {
        gmoImpact = Instantiate(gmoImpactPrefab,vecRockTarget,Quaternion.identity);
        Destroy(gmoImpact,2);
        Destroy(gameObject);


    }
}
