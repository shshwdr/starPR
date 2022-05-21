using Pool;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OneWeiboInfo
{
    public string userName;
    public string word;
    public int likes;
    public bool isPositive;
    public WeiboSentenceInfo weiboSentenceInfo;
    public List<string> keywords;
    public string image;
    public bool isLiking;
    public bool isDisabled;

}

public class WeiboManager : Singleton<WeiboManager>
{

    float weiboMaxCount = 50f;
    float weiboAddTime = 5f;
    float weiboAddTimer = 0;
    int weiboCount = 0;

    List<OneWeiboInfo> currentWeibos = new List<OneWeiboInfo>();
    Dictionary<string, HashSet<OneWeiboInfo>> currentWeibosWithKeywords = new Dictionary<string, HashSet<OneWeiboInfo>>();
    public List<OneWeiboInfo> CurrentWeibos { get { return currentWeibos; } }
    public List<OneWeiboInfo> CurrentWeibosWithKeyWords(string keywords)
    {
        if (!currentWeibosWithKeywords.ContainsKey(keywords))
        {
            return new List<OneWeiboInfo>();
        }
        return currentWeibosWithKeywords[keywords].ToList();
    }
    public void removeWeibo(OneWeiboInfo info)
    {
        foreach(var key in info.keywords)
        {
            currentWeibosWithKeywords[key].Remove(info);
        }
        weiboCount--;
        EventPool.Trigger("updateWeibos");
    }
    public OneWeiboInfo getOneWeibo(bool hasToHaveImage = false)
    {
        OneWeiboInfo res = new OneWeiboInfo();
        res.userName = WeiboNameSpawner.Instance.getName();
        var oneWeiboSentence = WeiboSpawner.Instance.getOneWeiboSentence(hasToHaveImage);
        res.weiboSentenceInfo = oneWeiboSentence;
        res.word = oneWeiboSentence.words;
        res.isPositive = oneWeiboSentence.isPositive>0;
        res.image = oneWeiboSentence.image;
        res.likes = Random.Range(0, 10);
        res.keywords = new List<string>();

        foreach (var lockedKey in WeiboKeywordsManager.Instance.lockedKeywords)
        {
            if (res.word.Contains(lockedKey))
            {
                res.keywords.Add(lockedKey);
                currentWeibosWithKeywords[lockedKey].Add(res);
            }
        }
        foreach (var lockedKey in WeiboKeywordsManager.Instance.unlockedKeywords)
        {
            if (res.word.Contains(lockedKey))
            {
                res.keywords.Add(lockedKey);
                currentWeibosWithKeywords[lockedKey].Add(res);
            }
        }
        weiboCount++;
        return res;
    }

    public void spawnWeibos(int count,bool hasToHaveImage = false)
    {
        for (int i = 0; i < count; i++)
        {
            currentWeibos.Add(getOneWeibo(hasToHaveImage));
        }
        
        EventPool.Trigger("updateWeibos");
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (var keyword in WeiboKeywordsManager.Instance.searchKeyWords)
        {
            currentWeibosWithKeywords[keyword.keyword] = (new HashSet<OneWeiboInfo>());
        }
        spawnWeibos(1,true);
        spawnWeibos(10);


    }

    // Update is called once per frame
    void Update()
    {
        if (weiboCount < weiboMaxCount)
        {
            weiboAddTimer += Time.deltaTime;
            if (weiboAddTimer >= weiboAddTime)
            {
                spawnWeibos(1);
                weiboAddTimer = 0;
            }
        }
    }
}
