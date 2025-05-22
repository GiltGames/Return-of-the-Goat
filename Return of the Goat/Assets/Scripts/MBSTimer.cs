using TMPro;
using UnityEngine;

public class MBSTimer : MonoBehaviour
{

   public float fltTimer;
    [SerializeField] TextMeshProUGUI txtTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fltTimer += Time.deltaTime;
        txtTimer.text = "Time: " + Mathf.FloorToInt( fltTimer);
    }
}
