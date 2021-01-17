using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class GameMainManager : MonoBehaviour
{
    public PlayableDirector _event1director;
    public GameObject _player;
    public GameObject _enemy;

    public GameObject _timeUI;
    private GameObject _timeUIinst;
    public GameObject _timeIcon;

    public GameObject _lifeIcon;

    public GameObject _menuIcon;

    private List<GameObject> _playerLifes;

    private float _gameOverWait;

    private bool _isGameOver;

    // Start is called before the first frame update
    void Start()
    {
        // 初期イベントの発火
        _event1director.Play();

        _gameOverWait = 3.0f;
        _isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(_isGameOver)
        {
            _gameOverWait -= Time.deltaTime;
            if(_gameOverWait < 0)
            {
                SceneManager.LoadScene("ResultScene");
            }
        }
        
        if(_playerLifes != null)
        {
            for (int i = 0; i < _playerLifes.Count; i++)
            {
                _playerLifes[i].SetActive(false);
            }
            for(var i = 0; i < _player.GetComponent<Player>().Life; i++)
            {
                _playerLifes[i].SetActive(true);
            }
        }
    }

    // UIの初期化
    void InitializeGameUI()
    {
        // タイマ開始
        var timeIcon = Instantiate(_timeIcon) as GameObject;
        timeIcon.transform.SetParent(UnityEngine.Object.FindObjectOfType<Canvas>().transform);

        // タイマアイコン生成
        _timeUIinst = Instantiate(_timeUI) as GameObject;
        _timeUIinst.transform.SetParent(UnityEngine.Object.FindObjectOfType<Canvas>().transform);

        // メニューアイコン生成
        var menuIcon = Instantiate(_menuIcon) as GameObject;
        menuIcon.transform.SetParent(UnityEngine.Object.FindObjectOfType<Canvas>().transform);

        // プレイヤライフアイコン生成
        _playerLifes = new List<GameObject>();
        for(var i = 0; i < 3; i++)
        {
            _playerLifes.Add( Instantiate(_lifeIcon) as GameObject );
            _playerLifes[i].transform.SetParent(UnityEngine.Object.FindObjectOfType<Canvas>().transform);
            _playerLifes[i].transform.position = new Vector3( 60 + i * 40, 480, 0);
            
        }
    }

    void OnEnable()
    {
        _event1director.stopped += OnPlayableDirectorStopped;
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        // イベント1終了
        if (_event1director == aDirector)
        {
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
            
            // アイコン初期化・表示
            InitializeGameUI();
        }


    }

    void OnDisable()
    {
        _event1director.stopped -= OnPlayableDirectorStopped;
    }

    // ゲームオーバー開始処理
    public void GameOver()
    {
        if(!_isGameOver)
        {
            _player.GetComponent<Player>().OnDeath();
            _isGameOver = true;
        }
    }
}
