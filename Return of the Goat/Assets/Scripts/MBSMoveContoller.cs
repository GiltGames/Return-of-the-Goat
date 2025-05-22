using System.Collections;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MBSMoveContoller : MonoBehaviour
{

    [SerializeField] Transform trnGoat;
    [SerializeField] float fltImpulse;
    [SerializeField] float fltRotSpeed;
    [SerializeField] float fltImpulseCharge;
    [SerializeField] float fltFwdInput;
    [SerializeField] float fltSideInput;
    [SerializeField] float fltCharge;
    [SerializeField] float fltChargeStartDelay =1f;
    [SerializeField] float fltChargeDuration =0.5f;
    [SerializeField] Rigidbody rb;
    public bool isCharging;
    [SerializeField] ParticleSystem psCharge;
    [SerializeField] GameObject gmoAura;

    [SerializeField] Animator anim;
    [SerializeField] bool isWalking;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = trnGoat.GetComponent<Rigidbody>();
       

    }

    // Update is called once per frame
    void Update()
    {

        FnInput();

        FnAnimate();

    }


    void FnInput()
    {

        if (!isCharging)
        {

            fltFwdInput = Input.GetAxis("Vertical");
            fltSideInput = Input.GetAxis("Horizontal");
            fltCharge = Input.GetAxis("Fire1");
        }


        if (fltFwdInput >0)
        {
            transform.Translate(Vector3.forward * fltFwdInput * fltImpulse *Time.deltaTime);
            


        }

    

        if (fltSideInput != 0)
        {
            trnGoat.Rotate(0, fltSideInput * fltRotSpeed *Time.deltaTime, 0);


        }

       

        if (fltCharge >0)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
       
            StartCoroutine(IECharge());
        }



    }

    void FnAnimate()
    {
        if (fltFwdInput <=0)
        {
            anim.SetTrigger("idle");
            isWalking = false;
        }

        else
        {
            if (!isWalking)
            {
                isWalking = true;
                anim.SetTrigger("walk");

            }


        }


    }

    IEnumerator IECharge()
    {
        anim.SetTrigger("walk");
        psCharge.gameObject.SetActive(true);
        psCharge.Play();
        isCharging = true;
        yield return new WaitForSeconds(fltChargeStartDelay);

        
        rb.AddForce(trnGoat.forward *fltImpulseCharge, ForceMode.Impulse);
        psCharge.gameObject.SetActive(false);
        gmoAura.SetActive(true);
        yield return new WaitForSeconds(fltChargeDuration);
        gmoAura.SetActive(false);
        isCharging = false;
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero ;

    }


}
