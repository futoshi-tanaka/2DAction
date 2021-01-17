using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour
{
    private Button _button;

    // Start is called before the first frame update
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
        SceneManager.LoadScene("TitleScene");
    }
}
