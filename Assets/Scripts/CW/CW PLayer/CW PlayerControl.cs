using UnityEngine;
using UnityEngine.InputSystem;
public class CWPlayerControl : MonoBehaviour{
	InputAction move, jump;
	Rigidbody2D rb;
	Vector2 move_direction;
	public float speed = 125f, max_speed = 5f, jump_force = 50;
	public float max_slope_angle = 40f;
	public bool is_grounded = false;
	bool jump_pressed = false;
	bool on_steep_slope = false;
	void Start(){
		move = InputSystem.actions.FindAction("Move");
		jump = InputSystem.actions.FindAction("Jump");
		rb = GetComponent<Rigidbody2D>();
	}
	void Update(){
		move_direction = move.ReadValue<Vector2>();
		if (jump.WasPressedThisFrame() && is_grounded) jump_pressed = true;
	}
	void OnCollisionStay2D(Collision2D col){
		on_steep_slope = false;
		foreach (ContactPoint2D contact in col.contacts){
			float angle = Vector2.Angle(contact.normal, Vector2.up);
			if (angle > max_slope_angle){
				on_steep_slope = true;
				break;
			}
		}
	}
	void OnCollisionExit2D(Collision2D col){
		on_steep_slope = false;
	}
	void FixedUpdate(){
		if (jump_pressed){
			rb.AddForceY(jump_force);
			jump_pressed = false;
		}
		if (!on_steep_slope && Mathf.Abs(rb.linearVelocity.x) <= max_speed)
			rb.AddForceX(move_direction.x * speed);
	}
}
