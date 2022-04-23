using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    Animator anim;
    Animation _anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        _anim = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            anim.Play("Base Layer.jumping", 0, 0);
    
        } else if (Input.GetKey("down"))
        {
            anim.Play("Base Layer.running", 0, 0);
        }
    }
}
