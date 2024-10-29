using System;
using System.Collections.Generic;
using UnityEngine; 
[Serializable] 
public class ItemData
{
   public int ID;
   public string Name;
   public int Type;
   public string Description;
   public int Health;
   public int MaxHealth;
   public int Hunger;
   public int MaxHunger;
   public int Stamina;
   public int MaxStamina;
   public int WalkSpeed;
   public int RunSpeed;
   public int JumpForce;
   public float Duration;
   public bool CanStack;
   public int MaxStackAmount;


   public ItemData(
       int id,
       string name,
       int type,
       string description,
       int health,
       int maxhealth,
       int hunger,
       int maxhunger,
       int stamina,
       int maxstamina,
       int walkspeed,
       int runspeed,
       int jumpforce,
       float duration,
       bool canstack,
       int maxstackamount
   )
    {
       ID = id;
       Name = name;
       Type = type;
       Description = description;
       Health = health;
       MaxHealth = maxhealth;
       Hunger = hunger;
       MaxHunger = maxhunger;
       Stamina = stamina;
       MaxStamina = maxstamina;
       WalkSpeed = walkspeed;
       RunSpeed = runspeed;
       JumpForce = jumpforce;
       Duration = duration;
       CanStack = canstack;
       MaxStackAmount = maxstackamount;

    }
   public ItemData(){}
}


[CreateAssetMenu(fileName = "ItemData", menuName ="DataScriptableObject/ItemDataDB")]
public class ItemDataDB : DataBase<ItemData>
{
}
