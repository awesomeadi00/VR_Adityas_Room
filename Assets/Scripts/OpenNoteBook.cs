using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenNoteBook : MonoBehaviour
{
    public GameObject cover;
    public HingeJoint bookHinge;

    // Start is called before the first frame update
    void Start()
    {
        bookHinge = cover.GetComponent<HingeJoint>();
        bookHinge.useMotor = false;
    }

    //Simple function which will be called when picked up to activate the hingejoint. 
    public void OpenBook() {
        bookHinge.useMotor = true;
    }
}
