using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    class Player : IComparable<Player>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Position { get; set; }
        public string Salary { get; set; }

        public Player(string Name, string Surname, string Nickname, string Position, string Salary)
        {
            this.Name = Name;
            this.Surname = Surname;
            this.Nickname = Nickname;
            this.Position = Position;
            this.Salary = Salary;
        }

        public int CompareTo(Player other)
        {
            return Nickname.CompareTo(other.Nickname);
        }
    }
}
