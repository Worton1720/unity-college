using UnityEngine;
public class UpDownPlatform : MonoBehaviour{
	public float min_y, max_y, speed, deflection;
	public float pause_duration = 1f;
	public bool is_going_down;
	Vector3 start_position;
	float pause_timer = 0f;
	void Start(){
		start_position = transform.position;
		if (min_y == 0) min_y = -2;
		if (max_y == 0) max_y = 2;
		if (speed == 0) speed = 0.01f;
	}
	void FixedUpdate(){
		if (pause_timer > 0){
			pause_timer -= Time.fixedDeltaTime;
			return;
		}
		deflection = transform.position.y - start_position.y;
		if (deflection >= max_y){
			is_going_down = true;
			pause_timer = pause_duration;
		}
		if (deflection <= min_y){
			is_going_down = false;
			pause_timer = pause_duration;
		}
		if (is_going_down) transform.Translate(new Vector3(0, -speed, 0));
		if (!is_going_down) transform.Translate(new Vector3(0, speed, 0));
	}
}
