namespace EncapsulationDemo
{
    using System;
    using System.Collections.Generic;
    public class MyStringBuilder
    {
        private List<string> list;

        public MyStringBuilder()
        {
            this.list = new List<string>();
        }

        public MyStringBuilder AppendLine(string line)
        {
            list.Add(line);
            list.Add(Environment.NewLine);

            this.SomeMethod(this);

            return this;
        }

        public void SomeMethod(MyStringBuilder myStringBuilder)
        {

        }
    }
}
