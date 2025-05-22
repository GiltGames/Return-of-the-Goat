using UnityEngine;

public class MBSTrackDeadZone : MonoBehaviour
{
    [SerializeField] Transform trnTracked;
    [SerializeField] Vector3 vecPos;

    [SerializeField] bool isYLocked;
    [SerializeField] float fltXLimit;
    [SerializeField] float fltZLimit;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        vecPos = transform.position;

        if (isYLocked)
        {
            vecPos.y = transform.position.y;


        }

        if (trnTracked.position.x - transform.position.x < -fltXLimit)
        {
            vecPos.x = trnTracked.position.x + fltXLimit;

        }

        if (trnTracked.position.x - transform.position.x > fltXLimit)
        {
            vecPos.x = trnTracked.position.x - fltXLimit;

        }

        if (trnTracked.position.z - transform.position.z < -fltZLimit)
        {
            vecPos.z = trnTracked.position.z + fltZLimit;

        }

        if (trnTracked.position.z- transform.position.z > fltZLimit)
        {
            vecPos.z = trnTracked.position.z - fltZLimit;

        }


        transform.position = vecPos;


    }
}
