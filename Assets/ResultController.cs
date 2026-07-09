using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    public TextMeshProUGUI resultText;

    public AudioSource clearAudio;
    public AudioSource gameOverAudio;


    void Start()
    {
        string result = PlayerPrefs.GetString("Result");


        resultText.text = result;


        if(result == "Game Clear!")
        {
            clearAudio.Play();
        }
        else
        {
            gameOverAudio.Play();
        }
    }


    public void Retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
}