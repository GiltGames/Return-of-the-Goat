using UnityEngine;

public class MBSGoatAnimation : MonoBehaviour
{
    [SerializeField] Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
          anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
