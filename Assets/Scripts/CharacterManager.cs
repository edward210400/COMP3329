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
	public static int life = 3;
	public static int score = 0;


	void Start () {
		charController = gameObject.GetComponent<CharacterController>();
	}

	void Update () {
		Vector3 pos=gameObject.transform.position;
		if(!line.Equals(targetLine)){
			if(targetLine==0 &&  pos.x<-2){
				gameObject.transform.position = new Vector3 (-2,pos.y,pos.z);
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
			}else if(targetLine==2 &&  pos.x>2){
				gameObject.transform.position = new Vector3 (2f,pos.y,pos.z);
				line = targetLine;
				movec.x = 0;
				canmove = true;
			}
		}
		checkInputs ();
		if (!charController.isGrounded) {
			movec.y = -4;
		}
		charController.Move (movec*Time.deltaTime);
	}

	void checkInputs(){
		if(Input.GetKeyDown(KeyCode.LeftArrow) && canmove && line>0){
			targetLine--;
			canmove = false;
			movec.x = -4f;
		}
		if(Input.GetKeyDown(KeyCode.RightArrow) && canmove && line<2){
			targetLine++;
			canmove = false;
			movec.x = 4f;
		}
	}

	void OnCollisionEnter(Collision obj) {

		string name = obj.gameObject.name;
		string this_name = gameObject.name;
		Debug.Log("Collided with " + name);
		Debug.Log("The current object is " + this_name);
		// if player collided with vitamin
		if (name == "vitamin"){
			Destroy(obj.gameObject);
			score += 100;
		}

		if (name == "mask"){
			Destroy(obj.gameObject);
			score += 200;
		}
		
		if (name == "vaccine"){
			Destroy(obj.gameObject);
			score += 300;
		}

		if (name == "alpha_variant"){
			Destroy(obj.gameObject);
			life -= 1;
			score -= 100;
		}

		if (name == "delta_variant"){
			Destroy(obj.gameObject);
			life -= 1;
			score -= 200;
		}
		
		if (name == "omicron_variant"){
			Destroy(obj.gameObject);
			score -= 300;
		}

	}
	void OnGUI () {
	GUI.Label(new Rect(100, 0, 400, 400), "Score: " +score);
	GUI.Label(new Rect(100, 50, 400, 400), "Life: " + life);
	if (life <= 0 ){
		GUI.Label(new Rect(Screen.width/2-100,Screen.height/2,500,100),"Game Over");
		Time.timeScale = 0;
	}

}
}
