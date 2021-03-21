namespace _02.WordCruncherGame
{
    using System.Collections;
    using System.Collections.Generic;
    public class Permutation 
    {
        public Permutation(string currentWord, List<Permutation> nextWords)
        {
            this.CurrentWord = currentWord;
            this.NextWords = nextWords;
        }

        public string CurrentWord { get; private set; }
        public List<Permutation> NextWords { get; private set; }
    }
}