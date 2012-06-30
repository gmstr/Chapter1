namespace GameEngine.Map
{
    public class AreaMap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public MapTile[,] FloorTiles { get; set; }

        public MapObject[] MapObjects { get; set; }
    }

    public class MapObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public MapOrientation Orientation { get; set; }
    }

    public enum MapOrientation
    {
        North,
        East,
        South,
        West
    }

    public class MapTile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
    }
}