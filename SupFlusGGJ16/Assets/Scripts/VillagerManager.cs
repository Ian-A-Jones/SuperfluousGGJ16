using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class VillagerManager : MonoBehaviour {

    public Transform    activeVillagerTrans,
                        remainingVillagersTrans,
                        warpGateEnt,
                        warpGateExit;

    Villager activeVillager;

    [SerializeField] List<Villager> remainingVillagers;


	// Use this for initialization
	void Start ()
    {
        remainingVillagers = new List<Villager>();

        Villager[] villagers = remainingVillagersTrans.GetComponentsInChildren<Villager>();

        remainingVillagers.AddRange(villagers);

	    if(activeVillager == null)
        {
            Villager player = activeVillagerTrans.GetComponentInChildren<Villager>();

            if (player == null)
            {
                NextVillager();
            }
            else
            {
                activeVillager = player;
            }

            activeVillager.activePlayer = true;
        }
	}
	
	// Update is called once per frame
	void Update ()
    {

#if UNITY_EDITOR

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            activeVillager.Kill();
        }

#endif

        if (activeVillager.alive)
        {

        }
        else
        {
            //What needs to happen when active Villager dies
            //1. Level resets to start
            //2. previous Villagers begin their tasks
            //3. Take control of next Villager in list
            NextVillager();
            //4. Teleport Villager to middle
            EnterArena();
        }

        for(int i = 0; i < remainingVillagers.Count; i++)
        {
            //If Villager is not moving forward and not in his correct place
            if(!remainingVillagers[i].advancing &&
                remainingVillagers[i].transform.localPosition.x < i * -2)
            {
                Debug.Log("Villager " + i + " is not in his correct place");
                remainingVillagers[i].SetTarget(i * - 2);
            }
        }
	}

    /// <summary>
    /// Gives player control of next villager
    /// </summary>
    void NextVillager()
    {
        //Prevent 
        if (activeVillager)
            activeVillager.activePlayer = false;

        activeVillager = remainingVillagers[0];
        remainingVillagers.RemoveAt(0);

        activeVillager.activePlayer = true;
    }

    void EnterArena()
    {
        activeVillager.transform.position = warpGateExit.transform.position; 
    }

}
