
    using System.Collections.Generic;

    [System.Serializable]
    public class EUser
    {
        public string name;
        public int place;
        public List<ECard> cards;

        public EUser(string name, int place, List<ECard> cards)
        {
            this.name = name;
            this.place = place;
            this.cards = cards;
        }
    }
