using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBiteGame
{
    /// <summary>
    /// This class is used to set up width,height,direction to the Game
    /// Width varible defines the width of the snake .
    /// Height varible defines the height of the snake 
    /// and directions basically conatins the informtion of moving of snake 
    /// </summary>
    public class setting
    {
        public static int width { get; set; }
        public static int height { get; set; }

        public static string directtions;

        /// <summary>
        /// by default set up the width,heigh and direction
        /// </summary>
        public setting()
        {
            width = 16;
            height = 16;
            directtions = "left";

        }
            

    }
}
