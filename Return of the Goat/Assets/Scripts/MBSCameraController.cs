using Unity.Hierarchy;
using UnityEngine;

public class MBSCameraController : MonoBehaviour
{
    [SerializeField] Transform trnCameraLock;
    [SerializeField] float fltCameraRotSp;
    [SerializeField] float fltMouseTurnInput;
    [SerializeField] float fltInputThreshold;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        FnMouseInput();
    }


    void FnMouseInput()
    {
        fltMouseTurnInput = Input.GetAxis("MouseX");

        if (Mathf.Abs(fltMouseTurnInput) > fltInputThreshold)
        {
            trnCameraLock.Rotate(0, fltMouseTurnInput * fltCameraRotSp * Time.deltaTime, 0);


        }



    }

}
