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

    [SerializeField]
    GameObject imagePanel;

    [SerializeField]
    GameObject imageContent;


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

    public void OnClickImage()
    {
        MainMenu.Instance.openMeitu();
    }
    public void updateWeiboCell()
    {
        userName.text = weiboInfo.userName;
        var finalText = weiboInfo.word;
        foreach (var keyword in WeiboKeywordsManager.Instance.lockedKeywords)
        {
            finalText = finalText.Replace(keyword, "<link>" + keyword + "</link>");
        }
        word.text = finalText;
        likedCount.text = (weiboInfo.likes + (isLiking ? 1 : 0)).ToString();


        if(weiboInfo.image!=null && weiboInfo.image.Length > 0)
        {
            imagePanel.SetActive(true);
            Utils.destroyAllChildren(imageContent.transform);
            Instantiate(Resources.Load("MeituImage/" + weiboInfo.image), imageContent.transform);
        }
        else
        {
            imagePanel.SetActive(false);
        }
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
