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
}

public class WeiboManager : Singleton<WeiboManager>
{
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
        currentWeibos.Remove(info);
        EventPool.Trigger("updateWeibos");
    }
    public OneWeiboInfo getOneWeibo()
    {
        OneWeiboInfo res = new OneWeiboInfo();
        res.userName = WeiboNameSpawner.Instance.getName();
        var oneWeiboSentence = WeiboSpawner.Instance.getOneWeiboSentence();
        res.weiboSentenceInfo = oneWeiboSentence;
        res.word = oneWeiboSentence.words;
        res.isPositive = oneWeiboSentence.isPositive>0;
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
                currentWeibosWithKeywords[lockedKey].Add(res);
            }
        }

        return res;
    }

    public void spawnWeibos(int count)
    {
        for (int i = 0; i < count; i++)
        {
            currentWeibos.Add(getOneWeibo());
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        foreach (var keyword in WeiboKeywordsManager.Instance.searchKeyWords)
        {
            currentWeibosWithKeywords[keyword.keyword] = (new HashSet<OneWeiboInfo>());
        }
        spawnWeibos(20);
        EventPool.Trigger("updateWeibos");


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
