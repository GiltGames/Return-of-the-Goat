using UnityEngine;

[CreateAssetMenu(fileName = "Score", menuName = "Scriptable Objects/Score")]
public class Score : ScriptableObject
{
    public int intScore;
    public int intHighScore;
    public float fltSFXVol;
    public float fltMusicVol;
}
