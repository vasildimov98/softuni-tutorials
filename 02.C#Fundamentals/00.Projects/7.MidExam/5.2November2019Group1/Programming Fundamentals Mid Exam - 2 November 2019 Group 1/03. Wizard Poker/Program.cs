using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Biscuits_Factory
{
    class Program
    {
        static void Main()
        {
            List<string> listOfCards = Console
                .ReadLine()
                .Split(":")
                .ToList();

            string command = "";

            List<string> deck = new List<string>();
            while ((command = Console.ReadLine()) != "Ready")
            {
                string[] allCommands = command.Split();

                string action = allCommands[0];

                if (action == "Add")
                {
                    AddCard(listOfCards, deck, allCommands);
                }
                else if (action == "Insert")
                {
                    InsertCard(listOfCards, deck, allCommands);
                }
                else if (action == "Remove")
                {
                    RemoveCard(listOfCards, deck, allCommands);
                }
                else if (action == "Swap")
                {
                    SwapCards(deck, allCommands);
                }
                else
                {
                    for (int i = 0; i < deck.Count / 2; i++)
                    {
                        string temp = deck[i];
                        deck[i] = deck[deck.Count - 1 - i];
                        deck[deck.Count - 1 - i] = temp;
                    }
                }
            }

            Console.WriteLine(string.Join(" ", deck));
        }

        private static void SwapCards(List<string> deck, string[] allCommands)
        {
            string cardName1 = allCommands[1];
            string cardName2 = allCommands[2];

            for (int i = 0; i < deck.Count; i++)
            {
                if (deck[i] == cardName1)
                {
                    deck[i] = cardName2;
                    continue;
                }

                if (deck[i] == cardName2)
                {
                    deck[i] = cardName1;
                    break;
                }
            }
        }

        private static void RemoveCard(List<string> listOfCards, List<string> deck, string[] allCommands)
        {
            string cardName = allCommands[1];

            if (deck.Contains(cardName))
            {
                listOfCards.Add(cardName);
                deck.Remove(cardName);
            }
            else
            {
                Console.WriteLine("Card not found.");
            }
        }

        private static void InsertCard(List<string> listOfCards, List<string> deck, string[] allCommands)
        {
            string cardName = allCommands[1];
            int index = int.Parse(allCommands[2]);
            if (listOfCards.Contains(cardName) && index >= 0 && index < deck.Count)
            {
                deck.Insert(index, cardName);
                listOfCards.Remove(cardName);
            }
            else
            {
                Console.WriteLine("Error!");
            }
        }

        private static void AddCard(List<string> listOfCards, List<string> deck, string[] allCommands)
        {
            string cardName = allCommands[1];
            if (listOfCards.Contains(cardName))
            {
                deck.Add(cardName);
                listOfCards.Remove(cardName);
            }
            else
            {
                Console.WriteLine("Card not found.");
            }
        }
    }
}
