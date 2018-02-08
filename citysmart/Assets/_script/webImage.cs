using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class webImage : MonoBehaviour {

    public string url = "https://upload.wikimedia.org/wikipedia/commons/a/af/Gunung_Padang_5th_terrace.jpeg";

    IEnumerator Start()
    {
        Texture2D tex;
        tex = new Texture2D(4, 4, TextureFormat.DXT1, false);
        using (WWW www = new WWW(url))
        {
            yield return www;
            www.LoadImageIntoTexture(tex);

            gameObject.GetComponent<Image>().sprite = Sprite.Create(tex,new Rect(0,0,tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
        }
    }
}
