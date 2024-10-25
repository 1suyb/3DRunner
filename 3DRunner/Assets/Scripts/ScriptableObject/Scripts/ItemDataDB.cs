using System;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Consumable,
    Resource,
}


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
   public bool CanStack;
   public int MaxStackAmount;


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
       bool canstack,
       int maxstackamount
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
       CanStack = canstack;
       MaxStackAmount = maxstackamount;

    }
   public ItemData(){}
}


[CreateAssetMenu(fileName = "ItemData", menuName ="DataScriptableObject/ItemDataDB")]
public class ItemDataDB : DataBase<ItemData>
{
}
