using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController charController;
	Vector3 movec = Vector3.zero;
	bool canmove = true;
	int line = 1;
	int targetLine = 1;
	public int life = 1;
	public static int score = 0;
	
	public Text ScoreUI;
	public Text LifeUI;

	public bool Finished = false;

	Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
	private Rigidbody rb = null;
	public float jumpForce = 2.0f;

    
	// Animator animator;

	void Start () {
		life = 3;
		score = 0;
		charController = gameObject.GetComponent<CharacterController>();
		rb = gameObject.GetComponent<Rigidbody>();
		Time.timeScale = 1;
		// animator = GetComponent<Animator>();
		
	}

	void Update () {
		Vector3 pos=gameObject.transform.position;
		movec.z = 4f;
		if(Input.GetKeyDown(KeyCode.UpArrow) && charController.isGrounded){
			Debug.Log("Jump");
			// gameObject.transform.position = new Vector3 ( pos.x, 10f,pos.z);
			// animator.SetBool("isGrounded", false);
            movec.y = 9f;
        }
		// if(charController.isGrounded){
		// 	animator.SetBool("isGrounded", true);
		// }
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
			movec.y += -4 * (Time.deltaTime*4f);
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

	void OnCollisionEnter(Collision obj) {

		string name = obj.gameObject.tag;
		string this_name = gameObject.name;
		Debug.Log("Collided with " + name);
		Debug.Log("The current object is " + this_name);
		// if player collided with vitamin
		if (name == "Vitamin"){
			Destroy(obj.gameObject);
			score += 100;
			ScoreUI.text = "Score :" + score.ToString();
			LifeUI.text = "Life :" + life.ToString();
		}

		if (name == "Mask"){
			Destroy(obj.gameObject);
			score += 200;
			ScoreUI.text = "Score :" + score.ToString();
			LifeUI.text = "Life :" + life.ToString();
		}
		
		if (name == "Vaccine"){
			Destroy(obj.gameObject);
			score += 300;
			ScoreUI.text = "Score :" + score.ToString();
			LifeUI.text = "Life :" + life.ToString();
		}

		if (name == "alpha_variant"){
			Destroy(obj.gameObject);
			life -= 1;
			score -= 100;
			ScoreUI.text = "Score :" + score.ToString();
			LifeUI.text = "Life :" + life.ToString();
		}

		if (name == "delta_variant"){
			Destroy(obj.gameObject);
			life -= 1;
			score -= 200;
			ScoreUI.text = "Score :" + score.ToString();
			LifeUI.text = "Life :" + life.ToString();
		}
		
		if (name == "omicron_variant"){
			Destroy(obj.gameObject);
			life -= 1;
			score -= 300;
			ScoreUI.text = "Score :" + score.ToString();
			LifeUI.text = "Life :" + life.ToString();
		}
		if (name == "Finish Line"){
			Finished = true;
		}

	}
}
