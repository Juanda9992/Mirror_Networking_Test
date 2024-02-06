using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class Door_Coroutine : NetworkBehaviour
{
    [SerializeField] private Door_Behaviour[] allDoors;
    [SerializeField] private float timeBetweenUpdates;

    private IEnumerator MoveDoors()
    {
        while(true)
        {
            for(int i = 0; i< allDoors.Length;i++)
            {
                if(Random.Range(0,2) == 1)
                {
                    allDoors[i].UpdateBehaviour();
                }

            }
            yield return new WaitForSeconds(timeBetweenUpdates);
        }
    }
    public override void OnStartServer()
    {
        StartCoroutine("MoveDoors");
    }


}
