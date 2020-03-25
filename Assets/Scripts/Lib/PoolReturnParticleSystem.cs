using UnityEngine;
using System.Collections;

//--------------------------------------
//> 0 : 지정된 시간.
// -1 : 파티클 시간.
//Quaternion _r = Quaternion.FromToRotation(Vector3.forward, -transform.forward);
//_p = PoolManager.ins.Instantiate("HitParticles", _hit.point, _r).GetComponent<ParticleSystem>();
//_p.Stop ();
//_p.Play ();
//--------------------------------------

[RequireComponent(typeof(ParticleSystem))]
public class PoolReturnParticleSystem : MonoBehaviour {
	ParticleSystem particle;
	public float duration = -1;

	void Awake(){
		if (particle == null) {
			particle = GetComponent<ParticleSystem> ();
		}
	}

	void OnEnable(){
		//Debug.Log (this + "OnEnable");
		if (duration <= 0) {
			duration = particle.startLifetime;
			//duration = particle.duration;
			//Debug.Log (" > " + duration
			////	+ " :" + particle.duration
			//	+ " :" + particle.main.duration
			//	+ " :" + particle.startLifetime
			//);
		}
		CancelInvoke ();
		Invoke ("Destroy", duration);
	}

	void OnDisalbe(){
		CancelInvoke ();
	}

	void Destroy(){
		gameObject.SetActive (false);
	}

}
