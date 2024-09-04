using Enum;

namespace Interface
{
    public interface IMinionCard : IStatable,ICard
    {
        public int Star { get; set; }
        public CardAttributeType MinionAttributeType { get; set; }
        public CardRatingType MinionRatingType { get; set; }
        public JobType MinionJobType { get; set; }
        public CardType TypeOfCard { get; set; }
    }
}
