namespace Task2_8
{
    internal class GameField
    {
        internal GameField()
        {
            Width = 10;
            Height = 10;
            GameItems = new GameItem[0];
            Characters = new Character[0];
        }
        public int Width { get; set; }
        public int Height { get; set; }

        internal GameItem[] GameItems { get; set; }

        

        internal Character[] Characters{get;set;}
    }
}
