using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndgameScene : MonoBehaviour
{
    public TMP_Text endgame_text;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        endgame_text.text = "Your score is " + TimerManager.PlayerScore + " ! congratulations !";
        Invoke("RelaunchGame", 5.0f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    void RelaunchGame ()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
