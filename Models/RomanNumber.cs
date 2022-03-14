using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l4_2.Models
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort Number { get; set; }
        public object Clone()
        {
            return new RomanNumber(Number);
        }
        public int CompareTo(object? o)
        {
            if (o is RomanNumber number) return Number.CompareTo(number.Number);
            else throw new ArgumentException("Некорректное значение параметра");
        }

        private char[] RomanDigits = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
        private string[] R_Number = new string[5];
        private string[] correct_number;
        private string s, s2;

        //Конструктор получает представление числа n в римской записи
        public RomanNumber(ushort n)
        {
            if (n == 0 || n > 3999)
            {
                throw new RomanNumberException("Вводимое число или результат действия равны нулю");
            }
            else
            {
                Number = n;
                s = Number.ToString();
                correct_number = new string[s.Length];

                switch (s[s.Length - 1])
                {
                    case '0':
                        R_Number[0] = "";
                        break;
                    case '1':
                        R_Number[0] = "I";
                        break;
                    case '2':
                        R_Number[0] = "II";
                        break;
                    case '3':
                        R_Number[0] = "III";
                        break;
                    case '4':
                        R_Number[0] = "IV";
                        break;
                    case '5':
                        R_Number[0] = "V";
                        break;
                    case '6':
                        R_Number[0] = "VI";
                        break;
                    case '7':
                        R_Number[0] = "VII";
                        break;
                    case '8':
                        R_Number[0] = "VIII";
                        break;
                    case '9':
                        R_Number[0] = "IX";
                        break;
                }
                if (s.Length > 1)
                {
                    switch (s[s.Length - 2])
                    {
                        case '0':
                            R_Number[1] = "";
                            break;
                        case '1':
                            R_Number[1] = "X";
                            break;
                        case '2':
                            R_Number[1] = "XX";
                            break;
                        case '3':
                            R_Number[1] = "XXX";
                            break;
                        case '4':
                            R_Number[1] = "XL";
                            break;
                        case '5':
                            R_Number[1] = "L";
                            break;
                        case '6':
                            R_Number[1] = "LX";
                            break;
                        case '7':
                            R_Number[1] = "LXX";
                            break;
                        case '8':
                            R_Number[1] = "LXXX";
                            break;
                        case '9':
                            R_Number[1] = "XC";
                            break;
                    }
                }
                if (s.Length > 2)
                {
                    switch (s[s.Length - 3])
                    {
                        case '0':
                            R_Number[2] = "";
                            break;
                        case '1':
                            R_Number[2] = "C";
                            break;
                        case '2':
                            R_Number[2] = "CC";
                            break;
                        case '3':
                            R_Number[2] = "CCC";
                            break;
                        case '4':
                            R_Number[2] = "CD";
                            break;
                        case '5':
                            R_Number[2] = "D";
                            break;
                        case '6':
                            R_Number[2] = "DC";
                            break;
                        case '7':
                            R_Number[2] = "DCC";
                            break;
                        case '8':
                            R_Number[2] = "DCCC";
                            break;
                        case '9':
                            R_Number[2] = "CM";
                            break;
                    }
                }
                if (s.Length > 3)
                {
                    switch (s[s.Length - 4])
                    {
                        case '0':
                            R_Number[3] = "";
                            break;
                        case '1':
                            R_Number[3] = "M";
                            break;
                        case '2':
                            R_Number[3] = "MM";
                            break;
                        case '3':
                            R_Number[3] = "MMM";
                            break;
                        case '4':
                            R_Number[3] = "MMMM";
                            break;
                        case '5':
                            R_Number[3] = "MMMMM";
                            break;
                        case '6':
                            R_Number[3] = "MMMMMM";
                            break;
                        case '7':
                            R_Number[3] = "MMMMMMM";
                            break;
                        case '8':
                            R_Number[3] = "MMMMMMMM";
                            break;
                        case '9':
                            R_Number[3] = "MMMMMMMMM";
                            break;
                    }
                }
                if (s.Length > 4)
                {
                    switch (s[s.Length - 5])
                    {
                        case '0':
                            R_Number[4] = "";
                            break;
                        case '1':
                            R_Number[4] = "MMMMMMMMMM";
                            break;
                        case '2':
                            R_Number[4] = "MMMMMMMMMMM";
                            break;
                        case '3':
                            R_Number[4] = "MMMMMMMMMMMM";
                            break;
                        case '4':
                            R_Number[4] = "MMMMMMMMMMMMM";
                            break;
                        case '5':
                            R_Number[4] = "MMMMMMMMMMMMMM";
                            break;
                        case '6':
                            R_Number[4] = "MMMMMMMMMMMMMMM";
                            break;
                        case '7':
                            R_Number[4] = "MMMMMMMMMMMMMMMM";
                            break;
                        case '8':
                            R_Number[4] = "MMMMMMMMMMMMMMMMM";
                            break;
                        case '9':
                            R_Number[4] = "MMMMMMMMMMMMMMMMMM";
                            break;
                    }
                }


                for (int i = s.Length - 1; i >= 0; i--)
                {
                    correct_number[s.Length - 1 - i] = R_Number[i];
                }
            }

        }
        public static RomanNumber operator +(RomanNumber n1, RomanNumber n2)
        {
            if (n2.Number + n1.Number > 3999)
            {
                throw new RomanNumberException("Сумма чисел превышает размер ushort");
            }
            else
                return new RomanNumber(Convert.ToUInt16(n1.Number + n2.Number));
        }

        public static RomanNumber operator -(RomanNumber n1, RomanNumber n2)
        {

            if (n2.Number >= n1.Number)
            {
                throw new RomanNumberException("Уменьшаемое должно быть больше вычитаемого числа");
            }
            else
                return new RomanNumber(Convert.ToUInt16(n1.Number - n2.Number));
        }

        public static RomanNumber operator *(RomanNumber n1, RomanNumber n2)
        {
            if (n2.Number * n1.Number > 3999)
            {
                throw new RomanNumberException("Результат превышает размер типа ushort");
            }
            else
                return new RomanNumber(Convert.ToUInt16(n1.Number * n2.Number));
        }

        public static RomanNumber operator /(RomanNumber n1, RomanNumber n2)
        {
            if (n2.Number == 0)
            {
                throw new RomanNumberException("Делитель не должен равняться нулю");
            }
            else if (n1.Number - n2.Number < 1)
                throw new RomanNumberException("Делимое должно быть больше делителя");
            else
                return new RomanNumber(Convert.ToUInt16(n1.Number / n2.Number));
        }

        public static bool operator ==(RomanNumber n1, RomanNumber n2)
        {
            return (Convert.ToUInt16(n1.Number) == Convert.ToUInt16(n1.Number));
        }

        public static bool operator !=(RomanNumber n1, RomanNumber n2)
        {
            return (Convert.ToUInt16(n1.Number) == Convert.ToUInt16(n1.Number));
        }

        //Возвращает строковое представление римского числа
        public override string ToString()
        {
            s = Number.ToString();
            s2 = "";
            for (int j = 0; j < s.Length; j++)
            {
                if (correct_number != null)
                    s2 += correct_number[j];
            }

            return s2;
        }
    }
}
