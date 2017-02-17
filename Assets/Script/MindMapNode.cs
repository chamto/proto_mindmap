using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindMapNode : MonoBehaviour 
{
	public LineRenderer _line = null; 


	// Use this for initialization
	void Start () 
	{
		MindMapManager mmmgr = (MindMapManager)MonoBehaviour.FindObjectOfType(typeof(MindMapManager));

		_line.SetPosition (0, mmmgr._currentPos);
		_line.SetPosition (1, this.transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void TouchDown(Vector3 pos)
	{
		MindMapManager mmmgr = (MindMapManager)MonoBehaviour.FindObjectOfType(typeof(MindMapManager));
		mmmgr._currentPos = pos; //생성된 노드의 현재위치를 저장한다. 


		Debug.Log ("  " + this.name);
	}
}
