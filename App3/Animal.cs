using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App3
{
    public class Animal
    {
        public string Name{ get; set; }
        public Uri ImagePath { get; set; }
        public Uri SoundPath { get; set; }

        public enum Class
        {
            Dog,
            Cat,
            Rodert
        };

        public enum State
        {
            Good ,
            Neutral ,
            Bad
        };

        public State animalState { get; set; }
        public Class animalClass { get; set; }

        public static State CurrenState(Class animalClass, Food.Type typeFood)
        {
            if ((animalClass == Class.Cat) && (typeFood == Food.Type.Fish))
            {
                return State.Good;
            }
            if ((animalClass == Class.Cat) && (typeFood == Food.Type.Meat))
            {
                return State.Good;
            }
            if ((animalClass == Class.Dog) && (typeFood == Food.Type.Fish))
            {
                return State.Neutral;
            }
            if ((animalClass == Class.Dog) && (typeFood == Food.Type.Meat))
            {
                return State.Good;
            }
            if ((animalClass == Class.Rodert) && (typeFood == Food.Type.Fish))
            {
                return State.Neutral;
            }
            if ((animalClass == Class.Rodert) && (typeFood == Food.Type.Meat))
            {
                return State.Neutral;
            }

            return State.Bad;

        }
    }
}
