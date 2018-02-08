using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class demo : MonoBehaviour
{

    public string key, secret, accesstoken;

    [SerializeField]
    Twitter.TwitterUser newUser;
    [SerializeField]
    Twitter.Tweet[] tweets;

    private void Start()
    {
        accesstoken = Twitter.API.GetTwitterAccessToken(key, secret);
        newUser = Twitter.API.GetProfileInfo("TwitterDev", accesstoken, false);
        tweets = Twitter.API.GetUserTimeline("TwitterDev", 5, accesstoken);
    }
}