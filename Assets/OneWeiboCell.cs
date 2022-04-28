using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OneWeiboCell : MonoBehaviour
{
    [SerializeField]
    TMP_Text userName;
    [SerializeField]
    TMP_Text word;
    [SerializeField]
    TMP_Text likedCount;

    [SerializeField]
    Button likeButton;
    [SerializeField]
    Button deleteButton;

    OneWeiboInfo weiboInfo;

    bool hasLiked;
    bool isLiking = false;
    

    public void init(OneWeiboInfo _info)
    {
        weiboInfo = _info;
        updateWeiboCell();
    }

    // Start is called before the first frame update
    void Awake()
    {
        likeButton.onClick.AddListener(onLikeButton);
        deleteButton.onClick.AddListener(onDeleteButton);
    }

    public void updateWeiboCell()
    {
        userName.text = weiboInfo.userName;
        word.text = weiboInfo.word;
        likedCount.text = (weiboInfo.likes + (isLiking ? 1 : 0)).ToString();
    }

    void onDeleteButton()
    {
        WeiboManager.Instance.removeWeibo(weiboInfo);
    }

    void onLikeButton()
    {
        //WeiboManager.Instance.removeWeibo(weiboInfo);
        isLiking = !isLiking;
        updateWeiboCell();
        if (hasLiked)
        {
            return;
        }
        hasLiked = true;
        ResourceManager.Instance.consumeHP(1);
        GetComponent<Image>().color = Color.grey;
        if (isLiking)
        {
            likedCount.color = Color.red;
        }
        else
        {

            likedCount.color = Color.black;
        }
        if (weiboInfo.isPositive)
        {
            //todo how many fans add should be decided somewhere else
            ResourceManager.Instance.addFansCount(1);
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
