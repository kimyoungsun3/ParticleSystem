using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Util {
	public static string GetScoreString(int _val){
		return _val.ToString ("000000");
	}

	public static string GetPrice (int _val){
		return _val.ToString ("$0");
	}

	static float intervalTime = 60f;
	static float intervalStartTime = 0;
	public static void SetInterpolation( float _startTime){
		intervalStartTime = _startTime;
	}
	public static float GetInterpolation(){
		return Mathf.Clamp01 ((Time.time - intervalStartTime) / intervalTime);
	}

}
