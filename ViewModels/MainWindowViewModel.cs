using System;
using System.Collections.Generic;
using System.Text;
using System.Reactive;
using ReactiveUI;
using l4_2.Models;

namespace l4_2.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        string s;
        public string n = "";
        public string n2 = "";
        public char act = '0';
        bool error = false;

        public MainWindowViewModel()
        {
        }

        public void StringReader(string x)
        {
            if (S == "Error") S = "";

            if (x == "+" || x == "-" || x == "/" || x == "*")
            {
                if (act == '0'&&n!="")
                {
                    switch (x)
                    {
                        case "+":
                            act = '+';
                            break;
                        case "-":
                            act = '-';
                            break;
                        case "/":
                            act = '/';
                            break;
                        case "*":
                            act = '*';
                            break;
                        default:
                            break;
                    }
                    S = n + act;
                }
            }

            else
            {
                if (act == '0')
                {
                    n += x;
                    S = n;
                }
                else
                {
                    n2 += x;
                    S = n + act + n2;
                }
            }

        }

        public void res()
        {
            ushort num = RomanNumberExtend.ToInt(n);
            RomanNumber Num = new RomanNumber(num);

            ushort num2 = RomanNumberExtend.ToInt(n2);
            RomanNumber Num2 = new RomanNumber(num2);

            RomanNumber Resh;

            switch (act)
            {
                case '+':
                    try
                    {
                        Resh = Num + Num2;
                    }
                    catch (RomanNumberException ex)
                    {
                        error = true;
                    }
                    if (!error)
                    {
                        Resh = Num + Num2;
                        S = Resh.ToString();
                    }
                    else S = "Error";
                    break;
                case '-':
                    try
                    {
                        Resh = Num - Num2;
                    }
                    catch (RomanNumberException ex)
                    {
                        error = true;
                    }
                    if (!error)
                    {
                        Resh = Num - Num2;
                        S = Resh.ToString();
                    }
                    else S = "Error";
                    break;
                case '/':
                    try
                    {
                        Resh = Num / Num2;
                    }
                    catch (RomanNumberException ex)
                    {
                        error = true;
                    }
                    if (!error)
                    {
                        Resh = Num / Num2;
                        S = Resh.ToString();
                    }
                    else S = "Error";
                    break;
                case '*':
                    try
                    {
                        Resh = Num * Num2;
                    }
                    catch (RomanNumberException ex)
                    {
                        error = true;
                    }
                    if (!error)
                    {
                        Resh = Num * Num2;
                        S = Resh.ToString();
                    }
                    else S = "Error";
                    break;

            }

            act = '0';
            if (S != "Error") n = S; else n = "";
            n2 = "";
            error = false;
        }


        public string S
        {
            set
            {
                this.RaiseAndSetIfChanged(ref s, value);
            }

            get
            {
                return s;
            }
        }

    }


}
