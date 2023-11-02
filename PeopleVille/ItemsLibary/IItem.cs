using Enums;

namespace ItemsLibary
{
    public interface IItem
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public Action UseAction { get; set; }
        public ItemRarityEnum ItemRarity { get; set; }
        public ItemEnums TypeOfItem { get; set; }
    }
}
