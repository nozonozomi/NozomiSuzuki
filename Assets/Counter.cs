using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIを使うためのライブラリ
using UnityEngine.SceneManagement; //Sceneを使うためのライブラリ

public class Counter : MonoBehaviour
{
    public Text count;

    public TMPro.TextMeshProUGUI timeText; //TextMeshProを使うための変数

    public int hitCount = 0;

    private float time = 60f;

    public GameObject StartText;

    private GunController gun;

    private AudioSource hitAudio;
    private AudioSource startAudio;
    private AudioSource bgmAudio;
    private AudioSource clearAudio;
    private AudioSource gameoverAudio;

    public bool isGameEnd = false; //ゲームオーバーかどうかの判定

    void Start()
    {
        gun = GameObject.Find("Gun").GetComponent<GunController>();

        AudioSource[] audioSources = GetComponents<AudioSource>();

        hitAudio = audioSources[0]; // HitAudioのAudioSourceを取得
        startAudio = audioSources[1]; // StartAudioのAudioSourceを取得
        bgmAudio = audioSources[2]; // BGMのAudioSourceを取得
        clearAudio = audioSources[3]; // ClearAudioのAudioSourceを取得
        gameoverAudio = audioSources[4]; // GameOverAudioのAudioSourceを取得
        
        gun.canControl = false; //Gunの操作を不可能にする

        startAudio.Play(); //StartAudioを再生する

        Invoke("HideStartText", 4.0f); //4秒後にHideStartText()を呼び出す
    }
    void Update()
    {
        if(gun.canControl)
        {
            time -= Time.deltaTime; //残り時間を減らしていく
        }

        if(!isGameEnd && time <= 0f) //残り時間が0になったとき
        {
            time = 0f;
            GameEnd();
        }

        timeText.text = "Time: " + Mathf.Ceil(time); //Textに残り時間を表示する
        
        this.count.text = hitCount.ToString() + "Hit"; //TextにHitCountの値を代入していく

        if(hitCount >= 20) //HitCountが20以上になったとき
        {
            this.count.color = Color.red; //Textの色を赤にする
        }
        else if (hitCount >= 10) //HitCountが10以上になったとき
        {
            this.count.color = Color.yellow; //Textの色を黄色にする
        }
        else //HitCountが5未満のとき
        {
            this.count.color = Color.white; //Textの色を白にする
        }
    }
    void HideStartText()
    {
        StartText.SetActive(false); //StartTextを非表示にする
        gun.canControl = true; //Gunの操作を可能にする
        bgmAudio.Play(); //BGMを再生する
    }

    public void PlayHitSound() //HitAudioを再生するメソッド
    {
        hitAudio.Play();
    }

    void GameEnd() //ゲーム終了時の処理
    {
        isGameEnd = true; //ゲーム終了の判定をtrueにする
        gun.canControl = false; //Gunの操作を不可能にする
        FindObjectOfType<TargetGenerator>().enabled = false; //TargetGeneratorの処理を止める
        bgmAudio.Stop(); //BGMを停止する

        if(hitCount >= 20) //HitCountが20以上のとき
        {
            PlayerPrefs.SetString("Result", "Game Clear!"); //ResultにClear!を代入する
        }
        else //HitCountが20未満のとき
        {
            PlayerPrefs.SetString("Result", "Game Over"); //ResultにGame Overを代入する
        }

        SceneManager.LoadScene("ResultScene"); //ResultSceneに遷移する
    }
}