using UnityEngine;
using UnityEngine.UI;

public class MBSMinimap : MonoBehaviour
{
    [SerializeField] float fltXCentre=50f;
    [SerializeField] float fltYCentre=50f;
    [SerializeField] float fltAngleOffset = 90;
    [SerializeField] float fltRadiusMax;
    [SerializeField] float fltScale;
    [SerializeField] Image imgPoint;
    public GameObject gmoSheepPoint;
    [SerializeField] GameObject gmoMiniMapEntry;
    [SerializeField] Transform trnMinimap;
    [SerializeField] Transform trnReference;
    [SerializeField] Transform trnRefPoint;
    [SerializeField] Vector3 vecOffset;
    [SerializeField] float fltAngle;
    [SerializeField] float fltDistance;
    [SerializeField] float fltXpos;
    [SerializeField] float fltYpos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       gmoSheepPoint= Instantiate(gmoMiniMapEntry, trnMinimap);

        if (GetComponent<MBSTrollMobile>() != null)
        {
            gmoSheepPoint.GetComponent<Image>().enabled = false;
        }

        gmoSheepPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        vecOffset = trnRefPoint.position - transform.position;

        fltAngle = Vector3.SignedAngle(trnReference.forward, vecOffset, Vector3.down) + fltAngleOffset;
        fltDistance = vecOffset.magnitude + fltScale;
        
        if (fltDistance > fltRadiusMax)
        {
            fltDistance= fltRadiusMax;
        }

        fltXpos = fltXCentre + Mathf.Cos(fltAngle * Mathf.Deg2Rad) * fltDistance;
        fltYpos = fltYCentre + Mathf.Sin(fltAngle * Mathf.Deg2Rad) * (fltDistance);

        gmoSheepPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(fltXpos, fltYpos);

    }

    public void FnMapOff()
    {
        gmoSheepPoint.SetActive(false);

    }

}
