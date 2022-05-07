using PixelCrushers.DialogueSystem.MenuSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : Singleton<MainMenu>
{
    MenuUtility menuUtility;
    // Start is called before the first frame update
    void Start()
    {
        menuUtility = GameObject.FindObjectOfType<MenuUtility>();
    }

    public void changeAppGeneral()
    {
        menuUtility.save();
    }

    public void openWeixin()
    {
        changeAppGeneral();
        SceneManager.LoadScene("wechat lobby");
    }

    public void openWeibo()
    {

        changeAppGeneral();
        SceneManager.LoadScene("weibo lobby");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
