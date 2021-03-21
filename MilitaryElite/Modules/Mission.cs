namespace MilitaryElite.Modules
{
    using System;
    using System.Net.Http.Headers;
    using MilitaryElite.Contracts;
    using MilitaryElite.Enumerators;

    public class Mission : IMission
    {
        public Mission(string codeName, string state)
        {
            this.CodeName = codeName;
            this.State = CompleteMission(state);
        }

        public string CodeName { get; private set; }

        public State State { get; private set; }

        public State CompleteMission(string stateStr)
        {
            var isTryParse = Enum.TryParse<State>(stateStr, out State state);

            if (!isTryParse)
            {
                throw new ArgumentException();
            }

            return state;
        }

        public override string ToString()
        {
            return $"Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
