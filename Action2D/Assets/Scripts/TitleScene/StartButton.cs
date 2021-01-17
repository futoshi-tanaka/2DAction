using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    private Button _button;

    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(OnClickButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        SceneManager.LoadScene("GameMainScene");
    }
}
