using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuButton : MonoBehaviour
{
    public Button _menuButton;

    public Button _titleButton;

    private bool _isShowMenu;
    private Button _titleButtonPrefab;

    // Start is called before the first frame update
    void Start()
    {
        _menuButton = GetComponent<Button>();
        _menuButton.onClick.AddListener(OnClickButton);

        _isShowMenu = false;

        _titleButtonPrefab = Instantiate(_titleButton) as Button;
        _titleButtonPrefab.transform.SetParent(UnityEngine.Object.FindObjectOfType<Canvas>().transform);
        _titleButtonPrefab.transform.position = new Vector3(-1000, 0, 0);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickButton()
    {
        Debug.Log("menu button on click");
        _isShowMenu = !_isShowMenu;

        if(_isShowMenu)
        {
            _titleButtonPrefab.transform.position = new Vector3(480, 250, 0);
        }
        else
        {
            _titleButtonPrefab.transform.position = new Vector3(-1000, 0, 0);
        }
        
    }
}
