using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{

    //when we implement IAttack, the contract says we need
    //CalcBlockChance, CalcHitChance, and CalcDamage methods, which
    //we already have from the inheritance of Character.  Both
    //sets of rules are in harmony, but we don't want Character
    //to have those methods any longer so we remove them.
    public class Player : Character, IAttack, IPlayer
    {


        #region Notes
        /*
         * //TEACH NOTE:  INITIAL NOTES
            due to inheritance we get:
            All 5 properties (Life, MaxLife, BlockChance, HitChance, Name)
            All 3 methods (CalcHitChance, CalcBlockChance, CalcDamage)

            So here we just need to add the unique
            properties and override method behaviors to make
            the Player class unique

            //TEACH NOTE: Version 2 notes!
            That's for Version 1 of our Dungeon App
            Now we want to create Version 2 of our Dungeon App
            Version 2 will include a new Hero class that
            will have a SuperPower ability.  To make sure this doesn't affect
            the game we need our Monsters to also get this type of
            new ability

            From an efficiency standpoint, we don't want to have to
            go back and rewrite our original code libraries.  We
            want to add on to them instead.

            We could make new datatypes SuperPlayer and SuperMonster
            that include new properties and methods to support this 
            behavior, but we would have to write duplicate code in both
            new datatypes!  To remove this duplication, we COULD go back
            and rewrite out Character class to include the new parts, but
            when Version 3 comes out, we will have to do it all over again.

            Instead, we can use Interfaces to abstract our behaviors 
            rather than building the behaviors into our base parent class
        * */
        #endregion

        //It doesn't matter what datatype is used for the EquippedWeapon
        //it only matters that the datatype implements the IWeapon
        //interface.  All of the things we need in an EquippedWeapon 
        //are included in the contract to implement the IWeapon interface.

        //This is NOT an instance of the IWeapon interface, you cannot make 
        //an instance/variable/implementation of an interface directly.  It 
        //is a placeholder for any class that implements the IWeapon interface
        //public IWeapon EquippedWeapon { get; set; }


        //TEACH NOTE:  This begins as a Sword class
        //public Weapon EquippedWeapon { get; set; }
        public IWeapon EquippedWeapon { get; set; }




        //TEACH NOTE: This note is for after adding our IAttack Interface
        //After implementing the interface, our basic behavior is the same,
        //but now when we make a new SuperPlayer or SuperMonster datatype
        //we can implement tha same interface, plus easily add more
        //to enhance functionality without having to rewrite any of our 
        //original datatypes
        public int CalcBlockChance()
        {
            return BlockChance;
        }
        //for our player class, we had a weapon that had
        //properties used in the calculations of damage and hit chance
        public int CalcDamage()
        {
            //return 999999;
            return (new Random()).Next(EquippedWeapon.MinDamage,
                EquippedWeapon.MaxDamage + 1);
        }

        public int CalcHitChance()
        {
            return HitChance + EquippedWeapon.BonusHitChance;
        }


        //order in which the methods/ctors/properties are written
        //in the class doesn't matter
        public Player()
        {
            MaxLife = 40;
            Name = "Arthur";
            HitChance = 40;
            BlockChance = 25;
            Life = 40;
            EquippedWeapon = new Sword();
            //Our default ctor depends on the Sword class
            //If we changed our hardcoded weapon to use the Axe class instead
            //then it would be dependent on (ie. tightly coupled to) the Axe class.
            //Still the same problem.  Tightly coupled code is bad, mmmk.
        }

        //TEACH NOTE:  IWeapon parameter starts as an Axe class
        public Player(string name, int hitChance, int blockChance, int life,
            int maxLife, IWeapon equippedWeapon)
        {
            //since Life depends on MaxLife... set MaxLife first!!!
            MaxLife = maxLife;
            Name = name;
            HitChance = hitChance;
            BlockChance = blockChance;
            Life = life;
            //Since we accept any class that implements the IWeapon 
            //interface, the Player class doesn't need to know 
            //if it is getting a Sword or Axe class, only that whatever
            //class it receives as a parameter has all the things 
            //that are required for EquippedWeapon to fulfill it's duties
            EquippedWeapon = equippedWeapon;
            //This is known as Constructor injection
        }

        //TEACH NOTE:  Not created until Unity added
        [InjectionConstructor]
        public Player(IWeapon equippedWeapon)
        {
            MaxLife = 40;
            Name = "Arthur";
            HitChance = 40;
            BlockChance = 25;
            Life = 40;
            EquippedWeapon = equippedWeapon;
          
        }


    }
}
