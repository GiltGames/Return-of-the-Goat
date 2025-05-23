using TMPro;
using Unity.Hierarchy;
using UnityEngine;

public class MBSCountGoats : MonoBehaviour
{
    [SerializeField] Transform[] trnGoats = new Transform[50];
    public int intMaxGoats;
    public int intGoatsAttached;
    [SerializeField] float fltTimebetweenCounts=1.0f;
    [SerializeField] float fltCountTimer;
  
    [SerializeField] TextMeshProUGUI txtGoatCount;
    [SerializeField] MBSScore mbsScore;
    [SerializeField] Transform trnFinal;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mbsScore = GetComponent<MBSScore>();
    }

    // Update is called once per frame
    void Update()
    {
     

        fltCountTimer += Time.deltaTime;
        if (fltCountTimer > fltTimebetweenCounts)
        {
            fltCountTimer = 0;
            FnCount();
            FnDisplayCount();

        }
    }


    void FnCount()
    {
        MBSFollower[] followers = FindObjectsByType<MBSFollower>(FindObjectsSortMode.None);
        int index = 0;
        foreach (var follower in followers)
        {
            trnGoats[index] = follower.transform;



            index++;
            intMaxGoats = index;

        }
        intGoatsAttached = 0;

        for (int i = 0;i<intMaxGoats;i++)
        {
            if (trnGoats[i].GetComponent<MBSFollower>() != null )
            {

                if (trnGoats[i].GetComponent <MBSFollower>().trnFollowing != null )
                {
                    if (trnGoats[i].GetComponent<MBSFollower>().trnFollowing != trnFinal)
                    {

                        intGoatsAttached++;
                    }
                }


            }


        }


    }


    void FnDisplayCount()
    {
        txtGoatCount.text = "Goats following: " + intGoatsAttached + "/" + (intMaxGoats -  mbsScore.intGoatsSaved);


    }
}
