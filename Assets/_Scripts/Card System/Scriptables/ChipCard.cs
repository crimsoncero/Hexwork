using System;
using UnityEngine;

namespace CardSystem
{
    [CreateAssetMenu(fileName = "New Chip", menuName = "Chips/Chip")]
    public class ChipCard : CardBase
    {
        [SerializeField]
        private Stats _stats;
        public Stats Stats
        {
            get { return _stats; }
            set { _stats = value; }
        }

        public void SetID()
        {
            ID = 0;
            ID += (int)Stats.Grade * 1_000_000;
            ID += Stats.Number * 1_000;
            ID += (int)Stats.Code;
        }
        







    }

    [Serializable]
    public struct Stats
    {
        public string Name;
        public string Description;
        public Grade Grade;
        public int Number;
        public Code Code;
        public Type Type;
        public int Power;
        public int MegaByte;


    }

    public enum Grade
    {
        None,
        Standard,
        Mega,
        Giga
    }
    public enum Code
    {
        None,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K, 
        L,
        M, 
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W, 
        X, 
        Y, 
        Z,
    }
    public enum Type
    {
        None,
        Fire,
        Aqua,
        Elec,
        Wood,
        Sword,
        Wind,
        Cursor,
        Obstacle,
        Plus,
        Break,
        Null,
    }


}

