using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Sword : IWeapon
    {
        //TEACH NOTE: This comment is for after we implement
        //             the IAttack interface in Player        
        //What if we wanted to make more than one type of
        //weapon datatype?
        private int _minDamage;

        public int BonusHitChance { get; set; }
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public bool IsTwohanded { get; set; }

        public int MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be more than the MaxDamage
                if (value < MaxDamage)
                {
                    //less than the MaxDamage, so let it pass
                    _minDamage = value;
                }//end if
                else
                {
                    //they tried to give us a number GREATER than or
                    //equal to MaxDamage, so we will set it to 
                    //MaxDamage
                    _minDamage = MaxDamage;
                }//end else
            }//end set
        }//end MinDamage

        //InjectionConstructor attribute added so that Unity will use
        //this constructor to create instances of the Sword datatype
        [InjectionConstructor]
        public Sword()
        {
            //making a basic sword here

            //If you have ANY properties that have business rules
            //that are based off of any OTHER properties... 
            //set the other properties first!!
            MaxDamage = 10;//since MinDamage business rules
                           //depend on the value of MaxDamage, set it first!!
            MinDamage = 5;
            Name = "Excalibur";
            BonusHitChance = 25;
            IsTwohanded = true;
        }

        public Sword(int minDamage, int maxDamage, string name,
            int bonusHitChance, bool isTwohanded)
        {
            //allowing for the creation of other swords
            //Follow the same rules as we had in the default ctor
            //but use the parameters as the values instead of
            //hard coding them!
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwohanded = isTwohanded;
        }//end FQ ctor

    }//end class
}//end namespace
