using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public Animator leftArm, rightArm;

    Timer LAttack1, LAttack2;
	// Use this for initialization
	void Start () {

        LAttack1 = gameObject.AddComponent<Timer>();
        LAttack1.Setup("LeftHandAttack", 1, true);

        LAttack1.StartTimer();

        LAttack2 = gameObject.AddComponent<Timer>();
        LAttack2.Setup("RightHandAttack", 1, true);
        LAttack2.enabled = false;
        //LAttack2.StartTimer();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(LAttack1.complete)
        {
            LAttack1.Reset();
            leftArm.SetBool("Attack1", true);

            LAttack1.enabled = false;

            LAttack2.enabled = true;
            LAttack2.StartTimer();
        }

        if (LAttack2.complete)
        {
            rightArm.SetBool("Attack1", true);
            LAttack2.Reset();
            LAttack2.enabled = false;

            LAttack1.enabled = true;
            LAttack1.StartTimer();
        }

    }
}
