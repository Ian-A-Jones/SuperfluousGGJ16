using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public Animator leftArm, rightArm;

    Timer LAttack1, RAttack1,
          LAttack2, RAttack2;

    int totalSweeps = 3, currentSweeps = 0,
        totalSlams = 4, currentSlams = 0;
	// Use this for initialization
	void Start () {

        LAttack1 = gameObject.AddComponent<Timer>();
        LAttack1.Setup("LeftHandAttack", 2, true);

        LAttack1.StartTimer();

        RAttack1 = gameObject.AddComponent<Timer>();
        RAttack1.Setup("RightHandAttack", 2.5f, true);
        RAttack1.enabled = false;

        LAttack2 = gameObject.AddComponent<Timer>();
        LAttack2.Setup("LHandSlam", 1f, true);

        RAttack2 = gameObject.AddComponent<Timer>();
        RAttack2.Setup("RHandSlam", 1f, true);


    }

    // Update is called once per frame
    void Update ()
    {
        if (currentSweeps <= totalSweeps)
        {
            if (LAttack1.complete)
            {
                currentSweeps++;
                LAttack1.Reset();
                leftArm.SetBool("Attack1", true);

                LAttack1.enabled = false;

                RAttack1.enabled = true;
                RAttack1.StartTimer();
            }

            if (RAttack1.complete)
            {
                currentSweeps++;
                rightArm.SetBool("Attack1", true);
                RAttack1.Reset();
                RAttack1.enabled = false;

                LAttack1.enabled = true;
                LAttack1.StartTimer();
            }
        }
        else if(currentSlams <= totalSlams)
        {
            if(currentSlams == 0 && !LAttack2.active && !LAttack2.complete)
            {
                LAttack2.StartTimer();
            }
            if (LAttack2.complete)
            {
                currentSlams++;
                LAttack2.Reset();
                leftArm.SetBool("Attack2", true);

                LAttack2.enabled = false;

                RAttack2.enabled = true;
                RAttack2.StartTimer();
            }

            if (RAttack2.complete)
            {
                currentSlams++;
                rightArm.SetBool("Attack2", true);
                RAttack2.Reset();
                RAttack2.enabled = false;

                LAttack2.enabled = true;
                LAttack2.StartTimer();
            }
        }
        else
        {
            currentSweeps = 0;
            currentSlams = 0;
        }

    }
}
