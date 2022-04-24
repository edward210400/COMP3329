using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyPoint : MonoBehaviour
{
    public GameObject ObjectToDestroy = null;
    public Text pointText = null;
    public Text thisText = null;
    // Start is called before the first frame update
    void Start()
    {
        thisText.text = pointText.text;
        Destroy (ObjectToDestroy, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
