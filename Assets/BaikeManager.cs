using Pool;
using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaikeEntryInfo
{
    public string keyword;
    public string content;

}
public class BaikeManager : Singleton<BaikeManager>
{

    public string addLinkToAddBaikeItems(string text)
    {
        var finalText = text;
        foreach (var keyword in lockedKeywords)
        {
            finalText = finalText.Replace(keyword, "<#ffff00><u><link>" + keyword + "</link></u></color>");
        }
        return finalText;
    }
    [HideInInspector]
    public List<string> unlockedKeywords = new List<string>();
    [HideInInspector]
    public List<string> lockedKeywords = new List<string>();
    [HideInInspector]
    public List<BaikeEntryInfo> searchKeyWords = new List<BaikeEntryInfo>();
    Dictionary<string, int> keywordCountByName = new Dictionary<string, int>();
    Dictionary<string, BaikeEntryInfo> keywordInfoByName = new Dictionary<string, BaikeEntryInfo>();

    public string randomUnlockedKeyword { get { return Utils.randomList(unlockedKeywords); } }

    // Start is called before the first frame update
    void Start()
    {

        searchKeyWords = CsvUtil.LoadObjects<BaikeEntryInfo>("baikeEntry");
        foreach (var keyInfo in searchKeyWords)
        {
            keywordCountByName[keyInfo.keyword] = 0;
            keywordInfoByName[keyInfo.keyword] = keyInfo;
            lockedKeywords.Add(keyInfo.keyword);
        }

    }

    public List<BaikeEntryInfo> unlockedBaikeEntries()
    {
        var res = new List<BaikeEntryInfo>();
        foreach(var key in unlockedKeywords)
        {
            res.Add(keywordInfoByName[key]);
        }
        return res;
    }

    public void addKeywordCount(string keyword)
    {
        //GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage(keyword + "+1");
        keywordCountByName[keyword]++;
        //if (keywordCountByName[keyword] >= keywordInfoByName[keyword].unlockCount)
        {
            unlockedKeywords.Add(keyword);
            lockedKeywords.Remove(keyword);

            EventPool.Trigger("showBaike");
            //DialogueLua.SetVariable("keywordsCount", unlockedKeywords.Count);

            //Sequencer.Message("keywordsCount_1");
            //EventPool.Trigger("dialogueConditionChanged");
            //GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("解锁" + keyword);
            //EventPool.Trigger("addOption", keyword);
            EventPool.Trigger("baikeEntryChanged");
        }

    }
}
