namespace GameEngine.Map
{
    public abstract class MapObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public bool IsNavigatable { get; set; }

        public MapOrientation Orientation { get; set; }
    }
}