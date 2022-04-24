using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController charController;
	Vector3 movec = Vector3.zero;
	bool canmove = true;
	int line = 1;
	int targetLine = 1;
	public static int life = 1;
	public static int score = 0;

	Vector3 jump = new Vector3(0.0f, 2.0f, 0.0f);
	private Rigidbody rb = null;
	public float jumpForce = 2.0f;
	[Header("Vitamin Particle")]
	public GameObject VitaminParticle = null;
	[Header("Character Body")]
	public GameObject characterBody = null;
	private Renderer characterRenderer = null;
	private Color originalCharColor = new Color (0f,0f,0f,0f);

	Animator anim;

	void Start () {
		life = 1;
		score = 0;
		charController = gameObject.GetComponent<CharacterController>();
		rb = gameObject.GetComponent<Rigidbody>();
		Time.timeScale = 1;
		anim = gameObject.GetComponent<Animator>();
		characterRenderer = characterBody.GetComponent<Renderer>();
		originalCharColor = characterRenderer.material.color;
	}

	void Update () {
		Vector3 pos=gameObject.transform.position;
		movec.z = 4f;
		if(Input.GetKeyDown(KeyCode.UpArrow) && charController.isGrounded){
			Debug.Log("Jump");
			// gameObject.transform.position = new Vector3 ( pos.x, 10f,pos.z);
			anim.Play("Base Layer.jumping", 0, 0);
            movec.y = 9f;
        }
		if(charController.isGrounded){
			// animator.SetBool("isGrounded", true);
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
			Instantiate(VitaminParticle, transform.position, Quaternion.identity); 
			StartCoroutine(ChangeCharacterColor());
			score += 100;
		}

		if (name == "Mask"){
			Destroy(obj.gameObject);
			score += 200;
		}
		
		if (name == "Vaccine"){
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
		SceneManager.LoadScene("New Scene");
		}
	}
	IEnumerator ChangeCharacterColor()
	{
		characterRenderer.material.color = new Color(1f,0f,0f,0f);
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = originalCharColor;
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = new Color(1f,0f,0f,0f);
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = originalCharColor;
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = new Color(1f,0f,0f,0f);
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = originalCharColor;
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = new Color(1f,0f,0f,0f);
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = originalCharColor;
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = new Color(1f,0f,0f,0f);
		yield return new WaitForSeconds(0.1f);
		characterRenderer.material.color = originalCharColor;
	}
}
