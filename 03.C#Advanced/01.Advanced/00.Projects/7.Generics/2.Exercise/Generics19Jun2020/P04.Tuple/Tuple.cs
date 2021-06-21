namespace P04.Tuple
{
    public class MyTuple<T1, T2>
    {
        private T1 item1;
        private T2 item2;

        public MyTuple(T1 item1, T2 item2)
        {
            this.Item1 = item1;
            this.Item2 = item2;
        }

        public T1 Item1
        {
            get => this.item1;
            private set => item1 = value;
        }
        public T2 Item2
        {
            get => this.item2;
            private set => item2 = value;
        }

        public override string ToString()
        {
            return $"{this.Item1} -> {this.Item2}";
        }

        public static MyTuple<T1, T2> Create(T1 item1, T2 item2)
        {
            return new MyTuple<T1, T2>(item1, item2);
        }
    }
}
