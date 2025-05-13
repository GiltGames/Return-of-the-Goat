using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MBSMoveContoller : MonoBehaviour
{

    [SerializeField] Transform trnGoat;
    [SerializeField] float fltImpulse;
    [SerializeField] float fltRotSpeed;
    [SerializeField] float fltFwdInput;
    [SerializeField] float fltSideInput;
    [SerializeField] Rigidbody rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = trnGoat.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        FnInput();

    }


    void FnInput()
    {

        fltFwdInput = Input.GetAxis("Vertical");

        if (fltFwdInput >0)
        {
            rb.AddForce(trnGoat.forward * fltFwdInput * fltImpulse, ForceMode.Impulse);


        }

        fltSideInput = Input.GetAxis("Horizontal");

        if (fltSideInput != 0)
        {
            trnGoat.Rotate(0, fltSideInput * fltRotSpeed *Time.deltaTime, 0);


        }

    }

}
