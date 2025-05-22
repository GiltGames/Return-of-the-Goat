using UnityEngine;

public class MBSLookat : MonoBehaviour
{
    [SerializeField] Transform trnLookedAt;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

    // Update is called once per frame
    void Update()
    {
    
        transform.LookAt(trnLookedAt);

    }
}
