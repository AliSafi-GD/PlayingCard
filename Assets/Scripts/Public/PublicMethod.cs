
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    public static class PublicMethod
    {
        
        
        
        public enum Symbol
        {
            Joker,Heart,Spade,Clubs,Diamond
        }

        public static Stack<ECard> Shuffle(this Stack<ECard> cards)
        {
            List<ECard> localCards = new List<ECard>();
            var count = cards.Count;
            for (int i = 0; i < count; i++)
            {
                localCards.Add(cards.Pop());
            }

            localCards = localCards.OrderBy(x => Random.Range(0, localCards.Count)).ToList();
            return new Stack<ECard>(localCards);
        }
        public static List<ECard> Shuffle(this List<ECard> cards)
        {
            cards = cards.OrderBy(x => Random.Range(0, cards.Count)).ToList();
            return cards;
        }
    }

    public static class SampleUserName
    {
        private static List<string> names = new List<string>
        {
            "Adams",
            "Baker",
            "Clark",
            "Davis",
            "Evans",
            "Frank",
            "Ghosh",
            "Hills",
            "Irwin",
            "Jones",
            "Klein",
            "Lopez",
            "Mason",
            "Nalty",
            "Ochoa",
            "Patel",
            "Quinn",
            "Reily",
            "Smith",
            "Trott",
            "Usman",
            "Valdo",
            "White",
            "Xiang",
            "Yakub",
            "Zafar",
            "Sneezy",
            "Sleepy",
            "Dopey",
            "Doc",
            "Happy",
            "Bashful",
            "Grumpy",
            "Mufasa",
            "Sarabi",
            "Simba",
            "Nala",
            "Kiara",
            "Kovu",
            "Timon",
            "Pumbaa",
            "Rafiki",
            "Shenzi"
        };

        private static List<string> noRepeat = new List<string>();

        public static string GetRandomName()
        {
            string n = names[Random.Range(0, names.Count)];

            while (noRepeat.Contains(n))
            {
                n = names[Random.Range(0, names.Count)];
            }

            return n;
        }

        public static void Close()
        {
            noRepeat.Clear();
        }
    }

    public class TurnManager
    {
        [SerializeField] private int max;
        [SerializeField] private int current = 0;
        public TurnManager(int max)
        {
            this.max = max;
        }
        public TurnManager(int current,int max)
        {
            this.max = max;
            this.current = current;
        }

        public void NextTurn()
        {
            current = current+1 >= max ?0:++current;
        }

        public int Get
        {
            get
            {
//                Debug.Log(current);
                return current;
            }
        }
    }