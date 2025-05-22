using TMPro;
using UnityEngine;

public class MBSScore : MonoBehaviour
{
    [SerializeField] Score SoScore;
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtGoatsSaved;
    public TextMeshProUGUI txtGoatsLeft;
    [SerializeField] int intGoatsSaved;
    public int intGoats;
    [SerializeField] TextMeshProUGUI txtMessage;
    

    private void Awake()
    {
        SoScore.intScore = 0;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void FnUpdateScore(int intAddScore)
    {
        SoScore.intScore += intAddScore;
        txtScore.text = "Score " + SoScore.intScore.ToString();


    }    

    public void FnUpdateGoatCount()
    {
        intGoatsSaved++;

        txtGoatsSaved.text = "Goats brought home: "+intGoatsSaved;
        txtGoatsLeft.text = "Goats left: "+ (intGoats - intGoatsSaved);
        if (intGoats == intGoatsSaved)
        {
            FnEndLevel();
        }

    }

    void FnEndLevel()
    { 
        Time.timeScale = 0;
        txtMessage.gameObject.SetActive(true);
        txtMessage.text = "Final "+txtScore.text;


    }

}
