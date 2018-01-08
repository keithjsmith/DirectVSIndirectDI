using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Axe : IWeapon
    {
        private int _minDamage;

        public int BonusHitChance { get; set; }
        public int MaxDamage { get; set; }
        public string Name { get; set; }
        public bool IsTwohanded { get; set; }

        //unique class property.  Could be used in the ToString
        //or some functionality in the game related to having
        //two blades on the axe
        public bool IsDoubleBladed { get; set; }

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
        //this constructor to create instances of the Axe datatype
        [InjectionConstructor]
        public Axe()
        {
            //making a basic axe here

            MaxDamage = 15;//since MinDamage business rules
                           //depend on the value of MaxDamage, set it first!!
            MinDamage = 2;
            Name = "Paul Bunyan Special";
            BonusHitChance = 10;
            IsTwohanded = true;
            IsDoubleBladed = false;
        }

        public Axe(int minDamage, int maxDamage, string name,
            int bonusHitChance, bool isTwohanded, bool isDoubleBladed)
        {
            //allowing for the creation of other axes
            //Follow the same rules as we had in the default ctor
            //but use the parameters as the values instead of
            //hard coding them!
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            BonusHitChance = bonusHitChance;
            IsTwohanded = isTwohanded;
            IsDoubleBladed = IsDoubleBladed;
        }//end FQ ctor
    }
}
