using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstProject_W_F
{
    internal class GameLogic
    {

        int size = 4;
        int[,] map;
        int spaseX;
        int spaseY;
        static Random random = new Random();

        public GameLogic()
        {
            map = new int[size, size];
        }
        public void Start()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                    map[x, y] = ConvertCoordinatesToPosition(x, y) +1;
            spaseX = size - 1;
            spaseY = size - 1;
            map[spaseX, spaseY] = 0;
        }
        private int ConvertCoordinatesToPosition(int x,int y)
        {
            if (x < 0) x = 0;
            if (x > size - 1) x = size - 1;
            if(y < 0) y = 0;
            if(y> size - 1) y = size - 1;
            return y * size + x;
        }
        private void ConvertPositionToCoords(int position, out int x, out int y)
        {
            if(position < 0) position = 0;  
            if(position > size * size - 1) position = size*size - 1;
            x = position% size;
            y = position/size;
        }
        public void ShiftRandom()
        {
            int number = random.Next(0, 4);
            int x = spaseX;
            int y = spaseY;
            switch (number)
            {
                case 0:x--;break;
                case 1:x++;break;
                case 2:y--;break;
                case 3:y++;break;
            }
            Shift(ConvertCoordinatesToPosition(x, y));
        }
        public void Shift(int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (Math.Abs(spaseX - x) + Math.Abs(spaseY - y) != 1)
                return;
            map[spaseX, spaseY] = map[x, y];
            map[x, y] = 0;
            spaseX = x;
            spaseY = y;


        }
        public int GetNumber (int position)
        {
            int x, y;
            ConvertPositionToCoords(position, out x, out y);
            if (x < 0 || x >= size) return 0;
            if (y < 0 || y >= size) return 0;
            return map[x, y];

        }

        public bool CheckNumbers()
        {
            if(!(spaseX==size-1 && spaseY==size-1)) return false;
            for(int x = 0; x < size; x++)
                for(int y = 0; y < size; y++)
                {
                    if (!(x == size - 1 && y == size - 1))
                        if (map[x, y] != ConvertCoordinatesToPosition(x, y) + 1) return false;
                }
            return true;
        }


    }
}
