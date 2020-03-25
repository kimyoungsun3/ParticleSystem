using UnityEngine;
using System.Collections;

public enum GAME_STATE {Ready, Round, Gaming, Result};
public enum BULLET_KIND {BULLET, MISSILE, LASER, ICE};
public delegate void DelegateVoidFunVoid();

public delegate void VOID_FUNC_VOID();
public delegate void VOID_FUNC_INT(int i);
public delegate void VOID_FUNC_FLOAT(float f);
public delegate void VOID_FUNC_GAMEOBJECT(GameObject _obj);
public delegate void VOID_FUNC_TRANSFORM(Transform _tran);

public class Constant {
	public const int INT_MAX = int.MaxValue;

	//Turret...
	public const int WEAPON_ATTACT_ANGLE = 20;

	//GameData
	
}
