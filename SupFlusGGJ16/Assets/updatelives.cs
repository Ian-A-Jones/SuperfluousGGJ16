﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;   

public class updatelives : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        GetComponent<Text>().text = "x" + VillagerManager.totalLives;
	}
}
