using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public List<GameObject> list = new List<GameObject> ();
	int index = 0;
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			if (list.Count > 0) {
				Vector3 _pos = transform.position + Random.insideUnitSphere*3;

				ParticleSystem _ps = PoolManager2.ins.Instantiate (list [index], _pos, transform.rotation).GetComponent<ParticleSystem>();
				_ps.Stop ();
				_ps.Play ();
			}
		} else if (Input.GetMouseButtonDown (1)) {
			if (list.Count > 0) {
				index = ( index + 1 ) % list.Count;
			}
		}
	}
}
