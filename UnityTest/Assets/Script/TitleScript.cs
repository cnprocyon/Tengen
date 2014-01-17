using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {
	GameObject Logo;
	GameObject Title;
	bool titleFlag=false;
	public float time=1f;
	public float interval=0.02f;
	// Use this for initialization
	void Start () {
		Logo=GameObject.Find("LOGO");
		Title = GameObject.Find ("TITLE");
		if (Logo == null || Title == null)
						return;
		StartCoroutine (Timing ());

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			if(titleFlag==true){
				titleFlag=false;
				StartCoroutine(StartLevel());
				Debug.Log("Start Level!");
			}

		}
	}
	IEnumerator Timing(){
		Title.SetActive (false);
		Logo.renderer.material.color = new Color (0f, 0f, 0f, 0f);
		float current = 0;
		while (current<time) {
			SetObjectColor(Logo,new Color (1f, 1f, 1f, current));
			yield return new WaitForSeconds(interval);
			current+=interval;
		}
		yield return new WaitForSeconds(1f);
		current = time;
		while (current>0) {
			SetObjectColor(Logo,new Color (1f, 1f, 1f, current));
			yield return new WaitForSeconds(interval);
			current-=interval;
		}
		yield return new WaitForSeconds(1f);
		Title.SetActive (true);
		SetObjectColor(Title,new Color (0f, 0f, 0f, 0f));
		current = 0;
		while (current<time) {
			SetObjectColor(Title,new Color (1f, 1f, 1f, current));
			yield return new WaitForSeconds(interval);
			current+=interval;
		}
		titleFlag = true;
	}
	IEnumerator StartLevel(){
		float current = time;
		while (current>0) {
			SetObjectColor(Title,new Color (1f, 1f, 1f, current));
			yield return new WaitForSeconds(interval);
			current-=interval;
		}
		Application.LoadLevel ("Level1");
	}
	void SetObjectColor(GameObject obj, Color col){
		Renderer[] render = obj.GetComponentsInChildren<Renderer> ();
		foreach(Renderer r in render){
			r.material.color=col;
		}
		obj.renderer.material.color = col;
	}
}
