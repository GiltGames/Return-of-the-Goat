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

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(vecRockDirection * Time.deltaTime);

        fltDistance = (transform.position - vecRockTarget).magnitude;

        if (fltDistance < fltRockScatterTriggerDistance )
        {
            FnScatterGoats();

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
        isScattering = true;

        MBSFollower[] followers = FindObjectsByType<MBSFollower>(FindObjectsSortMode.None);
        int index = 0;
        foreach (var follower in followers)
        {
            if ((follower.transform.position - transform.position).magnitude < fltRockScatterDistance)
            {
                follower.FnPanic(follower.transform.position);


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
