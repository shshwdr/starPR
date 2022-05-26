using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeiboReportMenu : MonoBehaviour,ISelectable
{
    OneWeiboInfo oneWeibo;
    [SerializeField]
    TMP_Text weiboText;
    [SerializeField]
    Transform reportReasonsParent;
    OneWeiboCell weiboCell;



    string currentReportReason;
    public void select(int index )
    {
        currentReportReason = WeiboReportManager.Instance.getReportReasons()[index].name;
    }

    public void init(OneWeiboInfo w,OneWeiboCell weiboCell)
    {
        oneWeibo = w;
        this.weiboCell = weiboCell;
        weiboText.text = oneWeibo.word;
        int i = 0;
        var reportReasons = WeiboReportManager.Instance.getReportReasons();
        if (reportReasonsParent.childCount< reportReasons.Count)
        {
            Debug.LogError("not enough report reasons");
        }
        for (; i < reportReasons.Count; i++)
        {
            if (reportReasons[i].displayName.Length > 0)
            {
                reportReasonsParent.GetChild(i).gameObject.SetActive(true);
                reportReasonsParent.GetChild(i).GetComponent<SelectionButton>().init(reportReasons[i].displayName, this, i);
            }
            else
            {
                break;
            }
        }
        for(;i< reportReasonsParent.childCount; i++)
        {

            reportReasonsParent.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void submit()
    {

        if (ResourceManager.Instance.tryConsumeHP(2))
        {
            if (oneWeibo.weiboSentenceInfo.reportReasons != null && oneWeibo.weiboSentenceInfo.reportReasons.Count == 0)
            {

                GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("没有需要举报的内容");
            }
            else if (oneWeibo.weiboSentenceInfo.reportReasons.Contains(currentReportReason))
            {
                GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("举报成功");
                ResourceManager.Instance.addFansCountFromWeibo(10);
                oneWeibo.isDisabled = true;
                oneWeibo.hasReported = true;
                weiboCell.updateWeiboCell();
            }
            else
            {
                GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("举报失败，试试别的");
            }
            gameObject.SetActive(false);
        }
        else
        {
            GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("体力不足");
        }
    }
    public void cancel()
    {
        gameObject.SetActive(false);
    }
}
