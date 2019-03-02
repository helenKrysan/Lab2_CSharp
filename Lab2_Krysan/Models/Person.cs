using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_Krysan.Models
{
    class Person
    {
        private DateTime _dateOfBirth;
        private string _name;
        private string _surname;
        private string _email;

        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _dateOfBirth = dateOfBirth;
        }

        public Person(string name, string surname, string email)
        {
            _name = name;
            _surname = surname;
            _email = email;
        }

        public Person(string name, string surname, DateTime dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _dateOfBirth = dateOfBirth;
        }

        public DateTime DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            private set
            {
                _dateOfBirth = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                _name = value;
            }
        }


        public string Surname
        {
            get
            {
                return _surname;
            }
            private set
            {
                _surname = value;
            }
        }

        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                _email = value;
            }
        }

        public bool IsAdult
            {
            get
            {
                if (CountAge() >= 18) return true;
                return false;
            }
         }

        public string SunSign
        {
            get
            {
                return DeterminateSign();
            }
        }

        public string ChineseSign
        {
            get
            {
                return DeterminateChineaseSign();
            }
        }

        public bool IsBirthday
        {
            get
            {
                if (DateTime.Now.Month == _dateOfBirth.Month && DateTime.Now.Day == _dateOfBirth.Day)
                {
                    return true;
                }
                return false;
            }
        }


        private int CountAge()
        {
            DateTime now = DateTime.Today;
            int age = 0;

            if (now.Month < _dateOfBirth.Month || now.Day < _dateOfBirth.Day)
            {
                age = now.Year - _dateOfBirth.Year - 1;
            }
            else
            {
                age = now.Year - _dateOfBirth.Year;
            }

            if (age > 135) throw new InvalidOperationException();

            return age;
        }

        private string DeterminateSign()
        {
            int day = _dateOfBirth.Day;
            string sign = "";
            switch (_dateOfBirth.Month)
            {
                case 1:
                    {
                        if (day >= 1 && day <= 19)
                        {
                            sign = "Capricorn";
                        }
                        sign = "Aquarius";
                        break;
                    }
                case 2:
                    {
                        if (day >= 1 && day <= 18)
                        {
                            sign = "Aquarius";
                        }
                        sign = "Pisces";
                        break;
                    }
                case 3:
                    {
                        if (day >= 1 && day <= 20)
                        {
                            sign = "Pisces";
                        }
                        sign = "Aries";
                        break;
                    }
                case 4:
                    {
                        if (day >= 1 && day <= 19)
                        {
                            sign = "Aries";
                        }
                        sign = "Taurus";
                        break;
                    }
                case 5:
                    {
                        if (day >= 1 && day <= 20)
                        {
                            sign = "Taurus";
                        }
                        sign = "Gemini";
                        break;
                    }
                case 6:
                    {
                        if (day >= 1 && day <= 20)
                        {
                            sign = "Gemini";
                        }
                        sign = "Cancer";
                        break;
                    }
                case 7:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Cancer";
                        }
                        sign = "Leo";
                        break;
                    }
                case 8:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Leo";
                        }
                        sign = "Virgo";
                        break;
                    }
                case 9:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Virgo";
                        }
                        sign = "Libra";
                        break;
                    }
                case 10:
                    {
                        if (day >= 1 && day <= 22)
                        {
                            sign = "Libra";
                        }
                        sign = "Scorpio";
                        break;
                    }
                case 11:
                    {
                        if (day >= 1 && day <= 21)
                        {
                            sign = "Scorpio";
                        }
                        sign = "Sagittarius";
                        break;
                    }
                case 12:
                    {
                        if (day >= 1 && day <= 21)
                        {
                            sign = "Sagittarius";
                        }
                        sign = "Capricorn";
                        break;
                    }
                default:
                    {
                        throw new InvalidOperationException();
                    }
            }
            return sign;
        }

        private string DeterminateChineaseSign()
        {
            int year = Math.Abs(2008 - _dateOfBirth.Year) % 12;
            string sign = "";
            switch (year)
            {
                case 0:
                    {
                        sign = "Rat";
                        break;
                    }
                case 1:
                    {
                        sign = "Ox";
                        break;
                    }
                case 2:
                    {
                        sign = "Tiger";
                        break;
                    }
                case 3:
                    {
                        sign = "Rabbit";
                        break;
                    }
                case 4:
                    {
                        sign = "Dragon";
                        break;
                    }
                case 5:
                    {
                        sign = "Snake";
                        break;
                    }
                case 6:
                    {
                        sign = "Horse";
                        break;
                    }
                case 7:
                    {
                        sign = "Goat";
                        break;
                    }
                case 8:
                    {
                        sign = "Monkey";
                        break;
                    }
                case 9:
                    {
                        sign = "Rooster";
                        break;
                    }
                case 10:
                    {
                        sign = "Dog";
                        break;
                    }
                case 11:
                    {
                        sign = "Pig";
                        break;
                    }
                default: throw new InvalidOperationException();
            }
            return sign;
        }


    }
}
