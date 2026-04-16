using UnityEngine;

public class CameraControl : MonoBehaviour
{
	public GameObject target;
	public float speed = 5f;
	private void Awake(){
		target = GameObject.FindGameObjectWithTag("Player");
	}
	void Update(){
		Vector3 targetPos = target.transform.position + new Vector3(0, 0, -10);
		transform.position = Vector3.Lerp(transform.position, targetPos, speed * Time.deltaTime);
	}
}
