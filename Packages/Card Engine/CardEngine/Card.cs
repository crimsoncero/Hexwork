

namespace CardEngine
{
    public abstract class Card
    {
        public int ID { get; private set; }

        public Card (int id)
        {
            ID = id;
        }
    }
}
