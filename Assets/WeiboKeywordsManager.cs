using PixelCrushers.DialogueSystem;
using Pool;
using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeiboKeywordsInfo
{
    public string keyword;
    public int unlockCount;

}

public class WeiboKeywordsManager : Singleton<WeiboKeywordsManager>
{
    [HideInInspector]
    public List<string> unlockedKeywords = new List<string>();
    [HideInInspector]
    public List<string> lockedKeywords = new List<string>();
    [HideInInspector]
    public List<WeiboKeywordsInfo> searchKeyWords = new List<WeiboKeywordsInfo>();
    Dictionary<string, int> keywordCountByName = new Dictionary<string, int>();
    Dictionary<string, WeiboKeywordsInfo> keywordInfoByName = new Dictionary<string, WeiboKeywordsInfo>();

    public string randomUnlockedKeyword { get { return Utils.randomList(unlockedKeywords); } }

    // Start is called before the first frame update
    void Start()
    {

        searchKeyWords = CsvUtil.LoadObjects<WeiboKeywordsInfo>("searchKeyWord");
        foreach(var keyInfo in searchKeyWords)
        {
            keywordCountByName[keyInfo.keyword] = 0;
            keywordInfoByName[keyInfo.keyword] = keyInfo;
            if(keyInfo.unlockCount <= keywordCountByName[keyInfo.keyword])
            {
                unlockedKeywords.Add(keyInfo.keyword);
            }
            else
            {
                lockedKeywords.Add(keyInfo.keyword);
            }
        }

    }

    public void addKeywordCount(string keyword)
    {
        GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage(keyword + "+1");
        keywordCountByName[keyword]++;
        if(keywordCountByName[keyword]>= keywordInfoByName[keyword].unlockCount)
        {
            unlockedKeywords.Add(keyword);
            lockedKeywords.Remove(keyword);

            DialogueLua.SetVariable("keywordsCount", unlockedKeywords.Count);

            Sequencer.Message("keywordsCount_1");
            GameObject.FindObjectOfType<WeiboCenterPopup>().addMessage("解锁"+keyword);
            EventPool.Trigger("addOption", keyword);
            EventPool.Trigger("updateWeibos");
        }
 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
