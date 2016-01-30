using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets._2D;

public class PastVillager : MonoBehaviour {

    private PlatformerCharacter2D m_Character;

    public List<Action> actions;
    public int size;
    public int t = 0;

    private void Awake()
    {
        m_Character = GetComponent<PlatformerCharacter2D>();
    }

    // Use this for initialization
    void Start () {
	
	}

    public void Setup(List<Action> _Actions)
    {
        actions = new List<Action>();
        actions.AddRange(_Actions);
        size = actions.Count;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (t < actions.Count)
        {
            //Debug.Log("Move: " + actions[t].move + " ");
            GetComponent<Rigidbody2D>().transform.position = actions[t].pos;
            t++;
        }
	}

    void FixedUpdate()
    {
        if (t < actions.Count)
        {
            m_Character.Move(actions[t].move, false, actions[t].jump);
        }
    }

}
