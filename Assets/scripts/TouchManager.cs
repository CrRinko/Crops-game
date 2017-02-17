using UnityEngine;
using System.Collections;

public class TouchManager : MonoBehaviour
{
	private bool pickup = false;
	/// 当前视角的摄像机    
	public Camera _camPlayer;
	/// 鼠标射线  
	private Ray _ray;
	/// 射线碰撞的结构   
	private RaycastHit _rayhit;
	/// 鼠标拾取的有效距离  
	private float _fDistance = 20f;

	private GameObject target;

	private GameObject pickup_obj;

	void Update ()
	{  
		//检测鼠标左键的拾取  
		if (Input.GetMouseButtonDown (0)) {  
			//鼠标的屏幕坐标空间位置转射线  
			_ray = _camPlayer.ScreenPointToRay (Input.mousePosition);  
			//射线检测，相关检测信息保存到RaycastHit 结构中  
			if (Physics.Raycast (_ray, out _rayhit, _fDistance)) {  
				//打印射线碰撞到的对象的名称  
				target = _rayhit.collider.gameObject;
				if (pickup == false) {
					if (target.CompareTag ("Tools")) {
						target.GetComponent<ActiveManager> ().enabled = true;
						pickup_obj = target;
						pickup = true;
					} else if(target.CompareTag("Plant")){
						if (target.GetComponent<watermelon> ().Stage == 2) {
							pickup_obj = target.GetComponent<watermelon> ().GetFlower ();
						} else if (target.GetComponent<watermelon> ().Stage == 3) {
							pickup_obj = pickup_obj = target.GetComponent<watermelon> ().GetFruit ();
						}
						if (pickup_obj!=null) {
							pickup = true;
						}
					}
				} else {
					switch (pickup_obj.name) {
					case "xiaochanzi":
						float xBase = _rayhit.point.x;
						float yBase = _rayhit.point.z;
						pickup_obj.GetComponent<Chanzi> ().dig (xBase,yBase);
						break;
					case"mutong":
						if (target.CompareTag("Plant")) {
							pickup_obj.GetComponent<Mutong> ().grow (target);
						} else {
							pickup_obj.GetComponent<Mutong> ().water (_rayhit.point);
						}
						break;
					case "daizi":
						pickup_obj.GetComponent<Daizi> ().topple ();
						break;
					default:
						if (pickup_obj.CompareTag ("Flower")) {
							if (target.CompareTag ("Plant")) {
								pickup_obj.GetComponent<Flower> ().Grow (target);
							}
						}
						break;
					}
				}
			}  
		} else if (Input.GetMouseButtonDown (1)) {
			pickup = false;
			if (pickup_obj != null) {
				pickup_obj.GetComponent<ActiveManager> ().enabled = false;
				if (pickup_obj.CompareTag ("Flower")) {
					Destroy (pickup_obj);
				}
			}
			pickup_obj = null;
			if (target != null) {
				target = null;
			}
		}  
	}
	public bool Pickup{
		get{ 
			return pickup;
		}
	}
}  