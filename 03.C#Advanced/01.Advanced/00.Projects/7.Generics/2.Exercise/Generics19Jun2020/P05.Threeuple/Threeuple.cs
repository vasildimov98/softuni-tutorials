﻿using System;

namespace P05.Threeuple
{
    public class Threeuple<T1, T2, T3>
    {
        public Threeuple(T1 item1, T2 item2, T3 item3)
        {
            this.Item1 = item1;
            this.Item2 = item2;
            this.Item3 = item3;
        }

        public T1 Item1 { get; private set; }
        public T2 Item2 { get; private set; }
        public T3 Item3 { get; private set; }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2} -> {this.Item3}";
        }

        public static Threeuple<T1, T2, T3> Create(T1 item1, T2 item2, T3 item3)
        {
            return new Threeuple<T1, T2, T3>(item1, item2, item3);
        }
    }
}
