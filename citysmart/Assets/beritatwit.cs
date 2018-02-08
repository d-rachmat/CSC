using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class beritatwit : MonoBehaviour
{

    public string key, secret, accesstoken;
    public GameObject TContainer;
    public Transform CContainer;
    public Image[] iconprofile;
    public Text[] tweet;

    [SerializeField]
    Twitter.TwitterUser newUser;
    [SerializeField]
    Twitter.Tweet[] tweets;

    private void Start()
    {
        accesstoken = Twitter.API.GetTwitterAccessToken(key, secret);
        newUser = Twitter.API.GetProfileInfo("@infocianjur", accesstoken, false);
        tweets = Twitter.API.GetUserTimeline("@infocianjur", 5, accesstoken);
      
        updateData(Texture2D);
    }

    void updateData(Texture2D tex)
    {
        for (int i = 0; i < tweets.Length; i++)
        {
            GameObject twitContainer = (GameObject)Instantiate(TContainer);
            twitContainer.transform.SetParent(CContainer);
            twitContainer.transform.GetChild(0).GetChild(1).GetComponent<Text>().text = newUser.name;
            StartCoroutine(GetIcon());
            twitContainer.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }

    IEnumerator GetIcon()
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(newUser.profile_image_url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);

        }
    }


}

