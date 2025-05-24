using TMPro;
using UnityEngine;

public class MBSResetScore : MonoBehaviour
{

    [SerializeField] Score soScore;
    [SerializeField] TextMeshProUGUI txtHighScore;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soScore.intScore = 0;
        soScore.intHighScore = PlayerPrefs.GetInt("HIGH", 0);
        txtHighScore.text = " "+soScore.intHighScore+" ";
    }

   public void FnClearHighScore()
    {
        soScore.intHighScore = 0;
        PlayerPrefs.SetInt("HIGH",soScore.intHighScore);
        txtHighScore.text = " " + soScore.intHighScore + " ";

    }


}
