using UnityEngine;

public class MBSPause : MonoBehaviour
{
    public bool isPaused;
    [SerializeField] GameObject gmoPauseScreen;
    [SerializeField] GameObject gmoGameUI;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetKeyDown(KeyCode.Escape))
        {
          if (!isPaused)
            {
                FnPause();
            }
          else
            {
                FnResume();

            }
        }
        

    }

    void FnPause()
    {

        Time.timeScale = 0;
        isPaused = true;
        gmoPauseScreen.SetActive(true);
        gmoGameUI.SetActive(false);

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }

    public void FnResume()
    {
        Time.timeScale = 1.0f;
        isPaused = false;
        gmoPauseScreen.SetActive(false);
        gmoGameUI.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
