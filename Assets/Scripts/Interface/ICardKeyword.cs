using Enum;

namespace Interface
{
    public interface ICardKeyword
    {
        public CardKeywordType KeywordType { get; set; }
        public string Description { get; set; }

        public void ApplyKeyword(ICard card);
    }
}
