using UnityEngine;
public class CWJumpTrigger : MonoBehaviour{
    CWPlayerControl playerControl;
    int groundCount = 0;
    void Start(){
        playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<CWPlayerControl>();
    }
    private void OnTriggerEnter2D(Collider2D collision){
        if(!collision.isTrigger){
            groundCount++;
            playerControl.is_grounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(!collision.isTrigger){
            groundCount--;
            playerControl.is_grounded = groundCount > 0;
        }
    }
}
