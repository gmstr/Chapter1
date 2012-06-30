using System.Collections.Generic;

namespace GameEngine.Map
{
    public class AreaMap
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public List<MapTile> FloorTiles { get; set; }
        public List<MapObject> MapObjects { get; set; }
    }
}