using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Facebook.Unity;

public class loginControl : MonoBehaviour 
{

	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	public GameObject DialogUsername;
	public GameObject DialogProfilePic;
	public GameObject dropdown;
	public Button btnLapor;
	public Button btnLogin;
	public Button profilePic;
	public bool naikturun;
	public GameObject[] allmenu;

	void Awake()
	{
		FB.Init (SetInit, OnHideUnity);
	}

	void SetInit()
	{

		if (FB.IsLoggedIn) {
			Debug.Log ("FB is logged in");
		} else {
			Debug.Log ("FB is not logged in");
		}

		DealWithFBMenus (FB.IsLoggedIn);

	}

	void OnHideUnity(bool isGameShown)
	{

		if (!isGameShown) {
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}

	}

	public void FBlogin()
	{

		List<string> permissions = new List<string> ();
		permissions.Add ("public_profile");

		FB.LogInWithReadPermissions (permissions, AuthCallBack);
	}

	void AuthCallBack(IResult result)
	{

		if (result.Error != null) {
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				Debug.Log ("FB is logged in");
			} else {
				Debug.Log ("FB is not logged in");
			}

			DealWithFBMenus (FB.IsLoggedIn);
		}

	}

	void DealWithFBMenus(bool isLoggedIn)
	{

		if (isLoggedIn) {
			DialogLoggedIn.SetActive (true);
			DialogLoggedOut.SetActive (false);
			//btnLapor.interactable = true;
			btnLogin.interactable = false;
			//profilePic.interactable = true;
			dropdown.SetActive (true);
			FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
			FB.API ("/me/picture?type=square&height=128&width=128", HttpMethod.GET, DisplayProfilePic);

		} else {
			DialogLoggedIn.SetActive (false);
			DialogLoggedOut.SetActive (true);
			//btnLapor.interactable = false;
			btnLogin.interactable = true;
			//profilePic.interactable = false;
			dropdown.SetActive (false);
		}

	}

	void DisplayUsername(IResult result)
	{

		Text UserName = DialogUsername.GetComponent<Text> ();

		if (result.Error == null) {

			UserName.text = "Hi there, " + result.ResultDictionary ["first_name"];

		} else {
			Debug.Log (result.Error);
		}

	}

	void DisplayProfilePic(IGraphResult result)
	{

		if (result.Texture != null) {

			Image ProfilePic = DialogProfilePic.GetComponent<Image> ();

			ProfilePic.sprite = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());

		}

	}

	public void DropDownControl()
	{
		naikturun = !naikturun;
		if (naikturun) {
			dropdown.GetComponent<Animator> ().SetTrigger ("down");
		} else 
		{
			dropdown.GetComponent<Animator> ().SetTrigger ("up");
		}
	}

	public void Home()
	{
		for (int i = 0; i < allmenu.Length; i++) 
		{
			if (allmenu[i].activeInHierarchy) 
			{
				allmenu [i].GetComponent<Animator> ().SetTrigger ("flyOut");
				dropdown.GetComponent<Animator> ().SetTrigger ("up");
				allmenu [i].SetActive (false);
			}
		}
	}
}
