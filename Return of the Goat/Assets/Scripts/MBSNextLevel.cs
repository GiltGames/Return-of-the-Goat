using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MBSNextLevel : MonoBehaviour
{
    public int intNewSceneIndex;
    public int intCurrentScene;
    [SerializeField] Score soScore;
    [SerializeField] Slider sldSFX;
    [SerializeField] Slider sldMus;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sldSFX.value = soScore.fltSFXVol;
        sldMus.value = soScore.fltMusicVol;
    }

    // Update is called once per frame
    void Update()
    {
        soScore.fltSFXVol = sldSFX.value;
        soScore.fltMusicVol = sldMus.value;
    }


    public void FnLoadScene()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(intNewSceneIndex);

    }
}
