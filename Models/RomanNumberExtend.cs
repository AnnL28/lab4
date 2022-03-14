using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace l4_2.Models
{
    public class RomanNumberExtend : RomanNumber
    {
        public static ushort ToInt(string num)
        {
            num = new string(num.Reverse().ToArray());
            ushort int_num = 0;
            for (int i = 0; i < num.Length; i++)
            {
                switch (num[i])
                {
                    case 'M':
                        int_num += 1000;
                        break;
                    case 'D':
                        int_num += 500;
                        break;
                    case 'C':
                        int_num += 100;
                        if (i > 0)
                        {
                            if (num[i - 1] == 'M' || num[i - 1] == 'D')
                            {
                                int_num -= 200;
                            }
                        }
                        break;
                    case 'L':
                        int_num += 50;
                        break;
                    case 'X':
                        int_num += 10;
                        if (i > 0)
                        {
                            if (num[i - 1] == 'C' || num[i - 1] == 'L')
                            {
                                int_num -= 20;
                            }
                        }
                        break;
                    case 'V':
                        int_num += 5;
                        break;
                    case 'I':
                        int_num += 1;
                        if (i > 0)
                        {
                            if (num[i - 1] == 'X' || num[i - 1] == 'V')
                            {
                                int_num -= 2;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            return int_num;
        }
        public RomanNumberExtend(string num) : base(ToInt(num)) { }
    }
}
