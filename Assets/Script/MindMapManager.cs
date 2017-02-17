using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindMapManager : MonoBehaviour 
{

	//public Vector3 _currentPos = Vector3.zero;
	public Vector3 	_currentPos = new Vector3(0,0,0);

	public float[,] 	_positions = new float[5, 2]; 
	public int 		_indexCount = 0;
	public bool _load = false;


//	public float _currentPos_x = 0;
//	public float _currentPos_y = 0;
//	public float _currentPos_z = 0;

	// Use this for initialization
	void Start () 
	{
		_positions [0, 0] = 0;
		_positions [0, 1] = 0;

		_positions [1, 0] = 0;
		_positions [1, 1] = 0;

		_positions [2, 0] = 0;
		_positions [2, 1] = 0;

		_positions [3, 0] = 0;
		_positions [3, 1] = 0;

		_positions [4, 0] = 0;
		_positions [4, 1] = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (true == _load) 
		{
			_load = false;

			for (int i = 0; i < 5; i++) 
			{
				GameObject trObj =  MonoBehaviour.Instantiate (Resources.Load ("Prefab/Node")) as GameObject; 
				trObj.transform.position = new Vector3 (_positions[i,0], _positions[i,1], 0);
			}

		}

	}

	public void TouchDown(Vector3 pos)
	{
		Debug.Log (pos);

		GameObject trObj =  MonoBehaviour.Instantiate (Resources.Load ("Prefab/Node")) as GameObject; 
		trObj.transform.position = new Vector3 (pos.x, pos.y, pos.z);


		
		_positions [_indexCount, 0] = pos.x;
		_positions [_indexCount, 1] = pos.y;
		_indexCount++;
	}


}
