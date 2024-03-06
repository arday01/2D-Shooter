using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestoryController : MonoBehaviour
{
   public void DestoryEnemy(float delay)
   {
      Destroy(gameObject,delay);
   }
}
