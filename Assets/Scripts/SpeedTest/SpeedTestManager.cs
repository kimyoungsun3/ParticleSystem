using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTestManager : MonoBehaviour {
	public Text text;
	int maxCount = 500;
	int count = 10;
	int plusCount = 50;
	public Transform part;
	public Transform anim;

	int mode = 0;
	List<Transform> listPart = new List<Transform>();
	List<Transform> listAni = new List<Transform>();

	void Start(){
		Vector3 _pos;
		Transform _t;
		Transform _p = transform;
		float _y = Camera.main.orthographicSize;
		float _x = Camera.main.aspect * Camera.main.orthographicSize;
		for (int i = 0; i < maxCount; i++) {
			_pos = new Vector3 (Random.Range (-_x, +_x), Random.Range (-_y, +_y), 0);
			_t = Instantiate (part, _pos, Quaternion.identity);
			_t.gameObject.SetActive (false);
			_t.SetParent (_p);

			listPart.Add (_t);
		}

		for (int i = 0; i < maxCount; i++) {
			_pos = new Vector3 (Random.Range (-_x, +_x), Random.Range (-_y, +_y), 0);
			_t = Instantiate (anim, _pos, Quaternion.identity);
			_t.gameObject.SetActive (false);
			_t.SetParent (_p);

			listAni.Add (_t);
		}

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			mode++;
			if (mode >= 4) {
				mode = 0;
				count += plusCount;
				if (count > maxCount) {
					count = 10;
				}
			}

			text.text = count.ToString ();
		}

		switch (mode) {
		case 0:
			takeOnParticle ();
			mode++;
			break;
		//case 1: break;
		case 2:
			takeOnAnimation ();
			mode++;
			break;
		//case 3: break;
		}
		
	}

	void takeOnParticle(){
		int _len = listAni.Count;
		for (int i = 0; i < _len; i++) {
			listAni [i].gameObject.SetActive (false);
		}

		ParticleSystem _p;
		for (int i = 0; i < count; i++) {
			listPart [i].gameObject.SetActive (true);
			_p = listPart [i].GetComponent<ParticleSystem> ();
			_p.Stop ();
			_p.Play ();
		}
	}

	void takeOnAnimation(){
		int _len = listPart.Count;
		for (int i = 0; i < _len; i++) {
			listPart [i].gameObject.SetActive (false);
		}

		Animator _p;
		for (int i = 0; i < count; i++) {
			listAni [i].gameObject.SetActive (true);
			_p = listAni [i].GetComponent<Animator> ();
			_p.Play ("health");
		}

	}
}
