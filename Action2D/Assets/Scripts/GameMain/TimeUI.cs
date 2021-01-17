using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeUI : MonoBehaviour
{
    private Text _TimeText;
    private float _Timer;

    static public bool TimeOver{ get; set; }

    // Start is called before the first frame update
    void Start()
    {
        // タイマ表示用テキストコンポーネント取得
        _TimeText = GetComponent<Text>();

        // タイマ初期化
        _Timer = 10;
        TimeOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_Timer > 0)
        {
            _Timer -= Time.deltaTime;     // 整数化
            int iTime = (int)_Timer;
            _TimeText.text = iTime.ToString();
            
            if(_Timer < 0)
            {
                TimeOver = true;
                var manager = GameObject.Find("GameMainManager");
                manager.GetComponent<GameMainManager>().GameOver();
            }
        }
    }
}
