using System;
using UnityEngine;
using UnityStandardAssets._2D;

/// <summary>
/// Class for controller Villager
/// </summary>
[RequireComponent(typeof(PlatformerCharacter2D))]
public class Villager : MonoBehaviour
{
    private PlatformerCharacter2D m_Character;
    private bool m_Jump;
    [SerializeField] float xDir;

    private float health = 1;

    //Target X position for Villager to aim for when they're waiting in queue
    public float targetX;

    /// <summary>
    /// Whether the Villager is advancing in the queue
    /// </summary>
    public bool advancing;

    /// <summary>
    /// If the Villager alive?
    /// </summary>
    public bool alive
    {
        get
        {
            return health > 0;
        }
    }

    //Whether it's currently in control by the player
    public bool activePlayer = false;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }

    private void Update()
    {
        if (alive)
        {
            if (activePlayer)
            {   

                xDir = 0;
                xDir = ((Input.GetKey(KeyCode.D)) ? 1 : xDir);
                xDir = ((Input.GetKey(KeyCode.A)) ? -1 : xDir);

                if (!m_Jump)
                {
                    // Read the jump input in Update so button presses aren't missed.
                    m_Jump = Input.GetKeyDown(KeyCode.Space);
                }
            }
            else
            {
                if (Mathf.Abs(transform.localPosition.x - targetX) > .5f)
                {
                    xDir = Mathf.Clamp01(targetX - transform.localPosition.x);
                }
                else
                {
                    advancing = false;
                }   
            }
        }
        else
        {
        }
    }

    private void FixedUpdate()
    {
        if (activePlayer)
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);

            xDir = ((Input.GetKey(KeyCode.D)) ? 1 : xDir);
            xDir = ((Input.GetKey(KeyCode.A)) ? -1 : xDir);

            // Pass all parameters to the character control script.
            m_Character.Move(xDir, crouch, m_Jump);
            m_Jump = false;
        }
        else
        {
            m_Character.Move(xDir, false, false);
        }
    }
    
    /// <summary>
    /// Kills player
    /// </summary>
    public void Kill()
    {
        health = 0;
    }

    /// <summary>
    /// Sets target for Villager to aim for in the x axis
    /// </summary>
    /// <param name="xPos">Target X Position</param>
    public void SetTarget(float xPos)
    {
        targetX = xPos;
        advancing = true;
    }
}

