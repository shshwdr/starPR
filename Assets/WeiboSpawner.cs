using Sinbad;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WeiboSentenceInfo {
    public string words;
    public int isPositive;
    public int isNegative;

}


public class WeiboSpawner : Singleton<WeiboSpawner>
{
    List<string> positiveSenteces = new List<string>();
    List<string> negativeSenteces = new List<string>();
    List<WeiboSentenceInfo> weiboSentenceInfos = new List<WeiboSentenceInfo>();
    public string getPraiseOne()
    {
        return "微笑哥哥，我想你啦！";
    }

    public WeiboSentenceInfo getOneWeiboSentence()
    {
        return Utils.randomList(weiboSentenceInfos);
    }

    // Start is called before the first frame update
    void Start()
    {

        var tweiboSentenceInfos = CsvUtil.LoadObjects<WeiboSentenceInfo>("weiboSentences");
        foreach(var info in tweiboSentenceInfos)
        {
            if (info.words !=null && info.words!= "")
            {

                weiboSentenceInfos.Add(info);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
