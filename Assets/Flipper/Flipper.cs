using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flipper : MonoBehaviour
{
    public int button = 0;

    private HingeJoint2D myHingeJoint;

    private void Start()
    {
        myHingeJoint = GetComponent<HingeJoint2D>();
    }
    void Update()
    {
#if UNITY_EDITOR
            myHingeJoint.useMotor = Input.GetMouseButton(button);
#else
#endif
    }

    public void myHingeJointOn()
    {
            myHingeJoint.useMotor = true;
    }


    public void myHingeJointOff()
    {
        myHingeJoint.useMotor = false;
    }

}