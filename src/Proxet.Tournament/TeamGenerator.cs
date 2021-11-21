using System;
using System.Collections.Generic;
using System.Linq;

namespace Proxet.Tournament
{
    public class TeamGenerator
    {
        public (string[] team1, string[] team2) GenerateTeams(string filePath)
        {
            //Please implement your algorithm there.

            //Чтение всех строк из файла статистики и инициализация ими списка
            List<string> players_info = System.IO.File.ReadAllLines(filePath).ToList();
            //Удаление первой строки, которая не содержит данных
            players_info.RemoveAt(0);
            
            
            List<Player> players = new List<Player>();
            foreach(var line in players_info)
            {
                //Каждая строка разбивается на три слова, которые передаются в качестве параметров конструктора класса, который отвечает за хранение данных об игроке
                string[] words = line.Split('\t');
                players.Add(new Player(words[0], Convert.ToInt32(words[1]), Convert.ToInt32(words[2])));
            }

            //Сортировка всего списка по критерию времени ожидания по убыванию(Внутри класса Player имплементирован интерфейс IComparable
            players.Sort();
            
            List<Player> firstTeam = new List<Player>();
            List<Player> secondTeam = new List<Player>();

            //Целочисленные счетчики для заполнения комманд тремя 1, тремя 2 и тремя 3.
            int counter1_first = 0, counter1_second = 0, counter2_first = 0, counter2_second = 0, counter3_first = 0, counter3_second = 0;
            foreach(var i in players)
            {
                if (i.VehicleType == 1)
                {
                    if (counter1_first < 3)
                    {
                        firstTeam.Add(i);
                        counter1_first++;
                    }
                    else if (counter1_second < 3)
                    {
                        secondTeam.Add(i);
                        counter1_second++;
                    }
                }
                if (i.VehicleType == 2)
                {
                    if (counter2_first < 3)
                    {
                        firstTeam.Add(i);
                        counter2_first++;
                    }
                    else if (counter2_second < 3)
                    {
                        secondTeam.Add(i);
                        counter2_second++;
                    }
                }
                if (i.VehicleType == 3)
                {
                    if (counter3_first < 3)
                    {
                        firstTeam.Add(i);
                        counter3_first++;
                    }
                    else if (counter3_second < 3)
                    {
                        secondTeam.Add(i);
                        counter3_second++;
                    }
                }
                //Если нужное кол-во игроков набрано - цикл останавливается
                if (firstTeam.Count == 9 && secondTeam.Count == 9)
                {
                    break;
                }
            }

            //Формирование массива с итоговыми именами игроков для каждой комманды
            List<string> result = new List<string>();
            foreach (var i in firstTeam)
            {
                result.Add(i.Name);
            }
            List<string> result2 = new List<string>();
            foreach (var i in secondTeam)
            {
                result2.Add(i.Name);
            }

            return (result.ToArray(), result2.ToArray());
        }
    }
}