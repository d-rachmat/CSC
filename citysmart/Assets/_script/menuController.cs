using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menuController : MonoBehaviour 
{
	public GameObject[] allmenu;
	public Image a, b;
	public Sprite abiru, bbiru;
	public Sprite amerah, bmerah;

	public Sprite[] allsprite;

	public void changeMenu(GameObject thismenu)
	{
		for (int i = 0; i < allmenu.Length; i++) 
		{
			if (allmenu[i].activeInHierarchy) 
			{
				allmenu [i].GetComponent<Animator> ().SetTrigger ("flyOut");
				allmenu [i].SetActive (false);
			}
		}
		thismenu.SetActive (true);
		thismenu.GetComponent<Animator> ().SetTrigger ("flyIn");
	}

	public void changeUIa()
	{
		a.GetComponent<Image>().sprite = amerah;
		b.GetComponent<Image>().sprite = bbiru;
	}

	public void changeUIb()
	{
		b.GetComponent<Image>().sprite = bmerah;
		a.GetComponent<Image>().sprite = abiru;
	}
}
