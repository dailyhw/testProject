using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;

	public float hp;
	public float hpMax;

	public GameObject _GM;
	public GM _GMst;

	public UISprite hpBar;

	// Use this for initialization
	void Start () {
		hpMax = hp;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("up"))
		{
			float val = speed * Time.deltaTime;
			if( transform.position.y > 375.0f )
			{
				return;
			}
			transform.position += new Vector3( 0, val, 0 );
		}
		else if (Input.GetKey ("down"))
		{
			float val = speed * Time.deltaTime;
			if( transform.position.y < -375.0f )
			{
				return;
			}
			transform.position -= new Vector3( 0, val, 0 );
		}
	}


	// 충돌 시 HP 감소
	void OnTriggerEnter(Collider other)
	{
		hp -= 10.0f;
		hpBar.fillAmount = hp * 0.01f;
		if( hp <= 0 )
		{
			GameEnd();
		}
	}

	void OnClick()
	{
		Debug.Log ("Click");
	}

	void GameEnd()
	{
		Debug.Log ("Game End");
		Time.timeScale = 0;
	}
}
