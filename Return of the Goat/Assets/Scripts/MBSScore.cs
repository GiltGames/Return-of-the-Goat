using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MBSScore : MonoBehaviour
{
    [SerializeField] Score SoScore;
    [SerializeField] TextMeshProUGUI txtScore;
    [SerializeField] TextMeshProUGUI txtGoatsSaved;
    public TextMeshProUGUI txtGoatsLeft;
    public int intGoatsSaved;
    public int intGoats;
    [SerializeField] TextMeshProUGUI txtMessage;

    [Header("Next Level")]
    [SerializeField] float fltTimetilNew;
    [SerializeField] MBSNextLevel mbsNextLevel;
    [SerializeField] GameObject gmoNext;

    [Header("Game Over")]
    [SerializeField] bool isGameOver;
    [SerializeField] GameObject gmoRestart;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mbsNextLevel = FindFirstObjectByType<MBSNextLevel>();
        txtScore.text = "Score: " + SoScore.intScore.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            if (Input.anyKeyDown)
            {
                FnRestartGame();

            }


        }


    }


    public void FnUpdateScore(int intAddScore)
    {
        SoScore.intScore += intAddScore;
        txtScore.text = "Score: " + SoScore.intScore.ToString();


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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;


        if (mbsNextLevel.intNewSceneIndex == 0)
        {
            FnGameOver();

        }

        else
        {
            txtMessage.text = "Score: " + SoScore.intScore;
            gmoNext.SetActive(true);
            Debug.Log("New Level Button");
        }
    }

 /*   IEnumerator IENextLevel()
    {
        yield return new WaitForSeconds(fltTimetilNew);

        Time.timeScale = 1.0f;

        

        

        yield return null;
    }
 */
    void FnGameOver()
    {
        txtMessage.text = "Final Score: " + SoScore.intScore;

        if (SoScore.intScore > SoScore.intHighScore)
        {
            SoScore.intHighScore = SoScore.intScore;
            txtMessage.text += "\n \n New High Score";
            PlayerPrefs.SetInt("HIGH",SoScore.intHighScore);


        }


            txtMessage.text += "\n \n Press any key to play again";
        isGameOver=true;
        gmoRestart.SetActive(true);

    }

    public void FnRestartGame()
    {
        SceneManager.LoadScene(0);

    }

   
}
