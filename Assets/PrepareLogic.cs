using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PrepareLogic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("startGame", 0.3f);
    }
    void startGame()
    {
        SceneManager.LoadScene("wechat lobby");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
