using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {

	public GameObject _BgSetObj;
	public GameObject _BgSetObj2;
	public GameObject _EnemySet1;
	public List<GameObject> nowEnemyChild = new List<GameObject> ();
	public int EnemyInt = 0;
	public float YPos;

	public float _moveSpeed;
	public float _moveSpeedMax;

	public float _xPosMoveChk = 0F;
	public float _xPosMoveChk2 = 0F;

	public float _xPosMoveChkVal1 = 0F;
	public float _xPosMoveChkVal2 = 0F;


	public float timerLim;
	public float timerForSpeed;

	public UILabel Score;
	public int GameScore;
	public int GameScorePer;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		SpeedLimChk ();

		// 원거리 배경은 정상 속도로, 근거리 배경은 1/2의 속도로 스크롤
		_xPosMoveChk += _moveSpeed * Time.deltaTime*0.5f;
		_xPosMoveChk2 += _moveSpeed * Time.deltaTime;


		_BgSetObj.transform.localPosition += new Vector3 (_moveSpeed * -1F * Time.deltaTime*0.5f, 0, 0);
		_BgSetObj2.transform.localPosition += new Vector3 (_moveSpeed * -1F * Time.deltaTime, 0, 0);
		_EnemySet1.transform.localPosition += new Vector3 (_moveSpeed * -1F * Time.deltaTime, 0, 0);

		GameScore += GameScorePer;
		Score.text = GameScore.ToString ();

		if (_xPosMoveChk > 960.0f)
		{
			_xPosMoveChk = 0;
			_BgSetObj.transform.localPosition = new Vector3(960*-1.0f, 0, 0 );
		}
		if (_xPosMoveChk2 > 960.0f) 
		{
			_xPosMoveChk2 = 0;
			_BgSetObj2.transform.localPosition = new Vector3( 960 * -1.0f, 0, 0 );
		}




		if( _EnemySet1.transform.localPosition.x < _xPosMoveChkVal1)
		{
			_xPosMoveChkVal1 -= _xPosMoveChkVal2;
			ResetChildSet();
			EnemyInt++;
			if(EnemyInt>4)
			{
				EnemyInt = 0;
			}
		}
	}

	void SpeedLimChk()
	{
		timerForSpeed += Time.deltaTime;
		if( timerForSpeed > timerLim )
		{
			timerForSpeed = 0;
			if( _moveSpeed < _moveSpeedMax )
			{
				_moveSpeed = _moveSpeed * 1.05f;
			}
			else
			{
				_moveSpeed = _moveSpeedMax;
			}
		}
	}


	void ResetChildSet()
	{
		nowEnemyChild [EnemyInt].transform.localPosition += new Vector3 (1440.0f, 0, 0);
		switch( Random.Range( 1, 4 ) )
		{
		case 1:
			YPos = 0.0f;
			break;
		
		case 2:
			YPos = 180.0f;
			break;

		case 3:
			YPos = -180.0f;
			break;
		}

		nowEnemyChild [EnemyInt].transform.localPosition = new Vector3 (
			nowEnemyChild [EnemyInt].transform.localPosition.x,
			YPos,
			nowEnemyChild [EnemyInt].transform.localPosition.z);
	}
}
