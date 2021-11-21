using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxet.Tournament
{
    //Класс игрока со свойствами имя, время ожидания и типом транспорта
    public class Player : IComparable<Player>
    {


        public string Name { get; set; }

        public int WaitTime { get; set; }

        public int VehicleType { get; set; }

        public Player(string name, int waittime, int type)
        {
            Name = name;
            WaitTime = waittime;
            VehicleType = type;
        }

        //Метод который использует список для сортировки игроков по убыванию времени ожидания
        public int CompareTo(Player other)
        {
            return other.WaitTime.CompareTo(this.WaitTime);
        }
    }
}
