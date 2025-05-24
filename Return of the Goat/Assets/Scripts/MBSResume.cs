using UnityEngine;

public class MBSResume : MonoBehaviour
{

    [SerializeField] GameObject gmoPauseScreen;

    // Start is called once before the first execution of Update after the MonoBehaviour is created



    public void FnResume()
    {
        Time.timeScale = 1.0f;
        GetComponent<MBSPause>().isPaused = false;
        gmoPauseScreen.SetActive(false);
    }


}
