using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeiboSentenceInfo {
    public string words;
    public int isPositive;
    public string image;
    public int isNegative;
}


public class WeiboSpawner : Singleton<WeiboSpawner>
{
    List<string> positiveSenteces = new List<string>();
    List<string> negativeSenteces = new List<string>();
    List<WeiboSentenceInfo> weiboSentenceInfos = new List<WeiboSentenceInfo>();
    Dictionary<string, HashSet<WeiboSentenceInfo>> weibosWithKeywords = new Dictionary<string, HashSet<WeiboSentenceInfo>>();
    HashSet<WeiboSentenceInfo> weiboWithImage = new HashSet<WeiboSentenceInfo>();



    public WeiboSentenceInfo getOneWeiboSentence(bool hasToHaveImage = false)
    {
        if (hasToHaveImage)
        {
            return Utils.randomHashSet(weiboWithImage);
        }
        var randomKeyword = WeiboKeywordsManager.Instance.randomUnlockedKeyword;
        return Utils.randomHashSet(weibosWithKeywords[randomKeyword]);
    }

    // Start is called before the first frame update
    void Start()
    {

        foreach (var keyword in WeiboKeywordsManager.Instance.searchKeyWords)
        {
            weibosWithKeywords[keyword.keyword] = (new HashSet<WeiboSentenceInfo>());
        }
            var tweiboSentenceInfos = CsvUtil.LoadObjects<WeiboSentenceInfo>("weiboSentences");
        foreach(var info in tweiboSentenceInfos)
        {
            if (info.words !=null && info.words!= "")
            {

                weiboSentenceInfos.Add(info);

                foreach(var keyword in WeiboKeywordsManager.Instance.searchKeyWords)
                {
                    if (info.words.Contains(keyword.keyword))
                    {
                        weibosWithKeywords[keyword.keyword].Add(info);
                    }
                }
                if (info.image != null && info.image.Length > 0)
                {
                    weiboWithImage.Add(info);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
