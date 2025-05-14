using System.Collections;
using TMPro;
using UnityEngine;

public class MBSLeaderHits : MonoBehaviour
{
    [SerializeField] Transform trnLastinLine;
    [SerializeField] TMP_Text txtSpeech;
    [SerializeField] float fltSpeechOffTime=1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        txtSpeech.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Leader hit "+collision.transform.name);

        if (collision != null)
        { 
        
            if (collision.transform.GetComponent<MBSTrailerSetter>() != null)
            {

                if (collision.transform.GetComponent<MBSFollower>().trnFollowing == null)
                {

                    Debug.Log("Change Follower Trail");

                    collision.transform.GetComponent<MBSFollower>().trnFollowing = trnLastinLine;

                    collision.transform.GetComponent<MBSFollower>().FnFollow();

                    trnLastinLine = collision.transform.GetComponent<MBSTrailerSetter>().trnTrail;

                    txtSpeech.text = "Follow me";
                    txtSpeech.gameObject.SetActive(true);
                    StartCoroutine(IESpeechOff());
                }


            }



        
        
        }

    }


    IEnumerator IESpeechOff()
    {
        yield return new WaitForSeconds(fltSpeechOffTime);
        txtSpeech.text = null;
        txtSpeech.gameObject.SetActive(false);


        yield return null;
    }


}
