using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthController : MonoBehaviour
{
   
   [SerializeField]private float currentHealth;
   [SerializeField]private float maximumHealth;
   private float minimumHealth;
   public bool IsInvincible { get; set; }
   public UnityEvent OnDied;
   public UnityEvent OnDamaged;

   public float RemainingHealthPercentage
   {
      get
      {
         return currentHealth / minimumHealth;
      }
   }

   

   public void TakeDamage(float damageAmount)
   {
      if (currentHealth==0)
      {
         return;
      }

      if (IsInvincible)
      {
         return;
      }
      currentHealth -= damageAmount;
      
      if (currentHealth<0)
      {
         currentHealth = 0;
      }

      if (currentHealth==0)
      {
         OnDied.Invoke();
      }
      else
      {
         OnDamaged.Invoke();
      }
   }

   public void AddHealth(float amountToAdd)
   {
      if (currentHealth==maximumHealth)
      {
         return;
      }
      
      currentHealth += amountToAdd;
      
      if (currentHealth>maximumHealth)
      {
         currentHealth = maximumHealth;
      }
   }
}
