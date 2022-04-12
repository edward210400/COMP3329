using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController charController;
	Vector3 movec = Vector3.zero;
	bool canmove = true;
	int line = 1;
	int targetLine = 1;
	Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
	private Rigidbody rb = null;
	public float jumpForce = 2.0f;

	void Start () {
		charController = gameObject.GetComponent<CharacterController>();
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void Update () {
		Vector3 pos=gameObject.transform.position;
		movec.z = 4f;
		if(Input.GetKeyDown(KeyCode.Space) && charController.isGrounded){
			Debug.Log("Jump");
			// gameObject.transform.position = new Vector3 ( pos.x, 10f,pos.z);
            movec.y = 5f;
        }
		if(!line.Equals(targetLine)){
			if(targetLine==0 &&  pos.x<-3){
				gameObject.transform.position = new Vector3 (-3f,pos.y,pos.z);
				line = targetLine;
				movec.x = 0;
				canmove = true;
			}else if(targetLine==1 &&  (pos.x>0 || pos.x<0)){
				if(line==0 && pos.x>0){
					gameObject.transform.position = new Vector3 (0,pos.y,pos.z);
					line = targetLine;
					movec.x = 0;
					canmove = true;
				}else if(line==2 && pos.x<0){
					gameObject.transform.position = new Vector3 (0,pos.y,pos.z);
					line = targetLine;
					movec.x = 0;
					canmove = true;
				}
			}else if(targetLine==2 &&  pos.x>3){
				gameObject.transform.position = new Vector3 (3f,pos.y,pos.z);
				line = targetLine;
				movec.x = 0;
				canmove = true;
			}
		}
		checkInputs ();
		if (!charController.isGrounded) {
			movec.y += -4 * Time.deltaTime;
		}
		charController.Move(movec*Time.deltaTime);
	}

	void checkInputs(){
		if(Input.GetKeyDown(KeyCode.LeftArrow) && canmove && line>0){
			targetLine--;
			canmove = false;
			movec.x = -6f;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && canmove && line<2){
			targetLine++;
			canmove = false;
			movec.x = 6f;
		}
	}
}
