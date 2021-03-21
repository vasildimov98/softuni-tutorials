namespace _02.WordCruncherGame
{
    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;

    internal class WordCruncher : IEnumerable<string>
    {
        private readonly List<Permutation> wordsPermutation;
        private readonly SortedSet<string> wordPaths;

        public WordCruncher(List<string> words, string targetText)
        {
            this.wordsPermutation = this.GenerateWordsPermutation(words, targetText);
            this.wordPaths = new SortedSet<string>();
            this.PutAllWordPathsToSortedSet();
        }

        private void PutAllWordPathsToSortedSet()
        {
            foreach (var wordPath in this.GetAllWordsPath())
            {
                var currentWordPath = string.Join(" ", wordPath);
                this.wordPaths.Add(currentWordPath);
            }
        }

        private IEnumerable<IEnumerable<string>> GetAllWordsPath()
        {
            var wordPaths = new List<string>();
            foreach (var word in this.VisitAllWordsPath(this.wordsPermutation, new List<string>()))
            {
                if (word != null)
                    wordPaths.Add(word);
                else
                {
                    yield return wordPaths;
                    wordPaths = new List<string>();
                }
            }
        }

        private IEnumerable<string> VisitAllWordsPath(List<Permutation> wordsPermutation, List<string> words)
        {
            if (wordsPermutation == null)
            {
                foreach (var word in words)
                    yield return word;

                yield return null;
            }
            else
            {
                foreach (var currPermutation in wordsPermutation)
                {
                    words.Add(currPermutation.CurrentWord);

                    foreach (var currentWord in this.VisitAllWordsPath(currPermutation.NextWords, words))
                        yield return currentWord;

                    words.RemoveAt(words.Count - 1);
                }
            }
        }

        private List<Permutation> GenerateWordsPermutation(List<string> words, string targetText)
        {
            if (string.IsNullOrEmpty(targetText) 
                || words.Count == 0)
                return null;

            List<Permutation> currPermutations = null;
            foreach (var currentWord in words)
            {
                if (targetText.StartsWith(currentWord))
                {
                    var otherWords = words.Where(w => w != currentWord).ToList();
                    var nextWords = this.GenerateWordsPermutation(otherWords, targetText.Substring(currentWord.Length));
                    var permutation = new Permutation(currentWord, nextWords);

                    if (permutation.NextWords == null
                        && permutation.CurrentWord != targetText)
                        continue;

                    if (currPermutations == null)
                        currPermutations = new List<Permutation>();

                    currPermutations.Add(permutation);
                }
            }

            return currPermutations;
        }

        public IEnumerator<string> GetEnumerator()
            => this.wordPaths.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}