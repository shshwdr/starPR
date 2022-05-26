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
    Button reportButton;

    [SerializeField]
    GameObject imagePanel;

    [SerializeField]
    GameObject imageContent;


    OneWeiboInfo weiboInfo;
    

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
        reportButton.onClick.AddListener(onReportButton);
    }

    public void OnClickImage()
    {
        MeituManager.Instance.addImage(weiboInfo.image);
        MainMenu.Instance.openMeitu();
    }

    public void onReportButton()
    {
        if (weiboInfo.isDisabled)
        {
            return;
        }
        GameObject.FindObjectOfType<WeiboReportMenu>(true).gameObject.SetActive(true);
        GameObject.FindObjectOfType<WeiboReportMenu>(true).init(weiboInfo,this);
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
        likedCount.text = (weiboInfo.likes + (weiboInfo.isLiking ? 1 : 0)).ToString();


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

        if (weiboInfo.isDisabled)
        {

            GetComponent<Image>().color = Color.grey;
        }
        else
        {

            GetComponent<Image>().color = Color.white;
        }
        if (weiboInfo.isLiking || weiboInfo.hasReported)
        {
            likedCount.color = Color.red;
        }
        else
        {

            likedCount.color = Color.black;
        }
    }

    void onDeleteButton()
    {
        WeiboManager.Instance.removeWeibo(weiboInfo);
    }

    void onLikeButton()
    {
        if (ResourceManager.Instance.tryConsumeHP(1))
        {
            //WeiboManager.Instance.removeWeibo(weiboInfo);
            weiboInfo.isLiking = !weiboInfo.isLiking;
            if (weiboInfo.isDisabled)
            {
                return;
            }
            weiboInfo.isDisabled = true;
            updateWeiboCell();
            if (weiboInfo.isPositive)
            {
                //todo how many fans add should be decided somewhere else
                ResourceManager.Instance.addFansCount(1);
            }
        }
        else
        {
            GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("体力不足");
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
