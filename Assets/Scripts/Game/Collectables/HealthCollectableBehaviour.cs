using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthCollectableBehaviour : MonoBehaviour,ICollectableBehaviour
{
  
    [SerializeField]private float healthAmount;
   
    public void OnCollected(GameObject player)
   
    {
        player.GetComponent<HealthController>().AddHealth(healthAmount);
    }
}
