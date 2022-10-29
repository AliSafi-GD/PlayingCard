namespace PublicScripts.Entity
{
    public class ECard
    {
        public enum Symbols
        {
            Heart,
            Spade,
            Diamond,
            Clubs
        }
        public Symbols Symbol { get; set; }
        public int ID { get; set; }
        public int Number { get; set; }
        public ECard()
        {
        }

        public ECard(Symbols symbol, int id, int number)
        {
            Symbol = symbol;
            ID = id;
            Number = number;
        }
        
        public ECard(ECard eCard)
        {
            Symbol = eCard.Symbol;
        }
    }
}