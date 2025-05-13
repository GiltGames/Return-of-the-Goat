using UnityEngine;

public class MBSTrackPosition : MonoBehaviour
{
    [SerializeField] Transform trnTracked;
    [SerializeField] Vector3 vecPos;
    
    [SerializeField] bool isYLocked;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vecPos = trnTracked.position;

        if (isYLocked)
        {
            vecPos.y = transform.position.y;
            

        }


        transform.position = vecPos;
    
    }
}
