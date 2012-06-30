namespace GameEngine.Map
{
    public abstract class MapTile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

        public int Width { get; set; }
        public int Height { get; set; }

        public MapOrientation Orientation { get; set; }
    }
}