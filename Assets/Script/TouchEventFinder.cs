using UnityEngine;
using System.Collections;

public class TouchEventFinder : MonoBehaviour {

	public string _touchDown = "TouchDown";


	// Use this for initialization
	void Start () {

	}
	
	void Update () 
	{
	//ref : https://docs.unity3d.com/420/Documentation/Manual/PlatformDependentCompilation.html
	#if UNITY_EDITOR

		if(Input .GetMouseButtonDown (0)) // 만약(다음내용을 자세하게.마우스왼버튼누름)
		{
			TouchEventUpdate();
		}
	#else
		if (TouchPhase.Began == Input.GetTouch (0).phase) 
		{
			if (Input.touchCount > 0) 
			{
				TouchEventUpdate();
			}


		}

	#endif


	}

	void TouchEventUpdate()
	{
		Vector2 pos = Input.mousePosition; //화면상의 마우스 위치얻기
		Vector3 theTouch = new Vector3 (pos.x, pos.y, -10f);//3차원이 기본인 유니티에서 z값 0위로 만들어준다.
		//벡터 2를 벡터 3에 넣는다. 자료형변회ㅏㄴ.
		Ray ray = Camera.main.ScreenPointToRay (theTouch);
		RaycastHit hit;
		Physics.Raycast (ray, out hit, Mathf.Infinity);//피직스 (물리엔진) 에서 레이케스트한다. (직선으로 쏜다한다.)
		//(반직선을 ,결과값을 얻는다, 수학적.무한대값)
		if (null != hit.collider) // 콜리더 = 충돌체   반직선(ray 시작은있지만 끝이없다) 과 만나는 충돌체가 있다면 
		{
			Transform tr = hit.collider.GetComponent<Transform> ( );
			// 선택되는 하나의 객체의 위치정보를 얻어오겠다.= 만난것.충돌체의.첫번째걸얻겠다<그자료형은 트렌스폼이어야 한다>
			//UnityEngine.Debug.Log ("안녕" + tr.name);
			// 유니티엔진의 디버그창에 출력(로그=출력해주는 함수이름)해라(트렌스폼의.이름을)

			//tr.SendMessage (_touchDown, pos, SendMessageOptions.DontRequireReceiver);
			tr.SendMessage (_touchDown, ToPointOnXYPlan(ray,0), SendMessageOptions.DontRequireReceiver);

		}

		//viewport : width 1 / height 1 
//		Debug.Log ("1-->" + pos); //test 
//		Debug.Log ("2-->" + Camera.main.ScreenToViewportPoint(theTouch)); //test 
//		Debug.Log ("3-->" + Camera.main.ScreenToViewportPoint(theTouch)); //test
//		Debug.Log ("4-->" + ray); //test




	}

	//임의의 xy평면 위에 있는 점 구하기    
	public Vector3 ToPointOnXYPlan(Ray ray, float dest_ZPos)
	{
		//orgin.z + (dir.z * ?) = dest.z
		//? = - orgin.z / dir.z + dest.z / dir.z
		//dest.z = 0
		//? = - orgin.z / dir.z

		float length = (-ray.origin.z + dest_ZPos) / ray.direction.z;

		return ray.origin + ray.direction * length;
	}


	//콜백함수 원형 , 터치 이벤트를 받고 싶은 객체에 이 함수를 넣는다
	public void TouchDown(Vector3 pos)
	{
	}
}
