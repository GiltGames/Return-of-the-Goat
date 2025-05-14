using UnityEngine;

public class MBSTrailpoiint : MonoBehaviour
{
    public Transform trnAttachedGoat;
    [SerializeField] GameObject gmoNextPoint;
    public GameObject gmoPreviousPoint;
    [SerializeField] GameObject gmoTrailPointPrefab;
    [SerializeField] Transform trnTrailEnd;
    [SerializeField] float fltActiveDistance;
    [SerializeField] int intPointCount;
    [SerializeField] float fltDistance;
    [SerializeField] int intMaxPoints;
    [SerializeField] Transform[] trntrailpoints;
   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intMaxPoints = trnAttachedGoat.GetComponent<MBSTrailerSetter>().intNoofPoints;
    }

    // Update is called once per frame
    void Update()
    {
        fltDistance = (trnAttachedGoat.position - transform.position).magnitude;

        if (fltDistance > fltActiveDistance )
        {

            trnTrailEnd.position = trntrailpoints[intMaxPoints-1].position;
          
            for ( int i =  intMaxPoints-2; i >=0; i-- )
            {
             //   Debug.Log(i+" "+ trntrailpoints[i + 1].position +"" +trntrailpoints[i].position);

                trntrailpoints[i+1].position = trntrailpoints[i].position;

            }
            trntrailpoints[0].position = transform.position;
            transform.position = trnAttachedGoat.position;
            
        }
        

      
    }
}
