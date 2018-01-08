using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    //making this class abstract means it can only 
    //be inherited, never instantiated (make an object
    //of the Character datatype)
    public abstract class Character 
    {
        //4 things in a class

        //fields
        //do we have any business rules ?
        //if yes, we need fields for the properties that will
        //have rules
        //if no, we can use automatic properties for the properties
        //that have no rules
        private int _life;

        //properties
        public int Life
        {
            get { return _life; }
            set
            {
                //business rule, life should not be MORE than max
                if (value <= MaxLife)
                {
                    //good to go!
                    _life = value;
                }//end if
                else
                {
                    _life = MaxLife;
                }//end else
            }//end set
        }//end Life

        public int MaxLife { get; set; }
        public int BlockChance { get; set; }
        public int HitChance { get; set; }
        public string Name { get; set; }

        //ctors
        //not inherited by child classes and therefore not necessary,
        //although you can definitely leverage a ctor in the child

        //methods
        #region Virtual methods moved to IAttack Interface
        //public virtual int CalcBlockChance()
        //{
        //    //to be able to override this in a child class
        //    //make it VIRTUAL

        //    //this basic version just returns block, but this
        //    //will give us the option to do something different
        //    //in child classes
        //    return BlockChance;

        //}//end CalcBlock

        //public virtual int CalcHitChance()
        //{
        //    return HitChance;
        //}//end CalcHitChance

        ////make CalcDamage and return 0
        //public virtual int CalcDamage()
        //{
        //    return 999999;
        //    //starting this with just returning 999999 so that we can
        //    //use the Method from an instance of a Character, we will
        //    //override the method in Monster and Player.

        //}//end CalcDamage

        #endregion

        //TEACH NOTE:  Notes for after defining Version 2 issues
        //we can write an abstract method definition that 
        //enforces a contract to child classes much like
        //an interface, but we still have the same issue 
        //where we would have to come here and re-write the
        //Character class


        //TEACH NOTE: Not created immediately, added after Player class
        //            is created to illustrate another way to implement 
        //            a contract
        //public abstract int Example();
        //YOU CANNOT WRITE AN ABSTRACT METHOD UNLESS IT IS IN
        //AN ABSTRACT CLASS.  This is a very strong reason to
        //use Interfaces instead, because you can implement them
        //in any class

        //If you absolutely have to have default functionality
        //then an abstract method may make the most sense, but
        //interfaces are by far the more accepted means to enforce
        //a behavior to be included in a class

    }
}
