using System;
using System.Text.RegularExpressions;

namespace NumberToWords
{
    /// <summary>
    /// Luis Arias [ariassd@gmail.com]
    /// Octubre 2019
    /// </summary>
    public static class DecimalToWords
    {
        private static readonly string[] UNITS =
            { "", NumberToWordResources.one, NumberToWordResources.two, NumberToWordResources.three, NumberToWordResources.four,
            NumberToWordResources.five,NumberToWordResources.six, NumberToWordResources.seven, NumberToWordResources.eight, NumberToWordResources.nine };
        private static readonly string[] TENS =
            {NumberToWordResources.ten, NumberToWordResources.eleven, NumberToWordResources.twelve, NumberToWordResources.thirteen, NumberToWordResources.fourteen,
            NumberToWordResources.fifteen, NumberToWordResources.sixteen, NumberToWordResources.seventeen, NumberToWordResources.eighteen, NumberToWordResources.nineteen,
            NumberToWordResources.twenty, NumberToWordResources.thirty,  NumberToWordResources.forty,  NumberToWordResources.fifty,  NumberToWordResources.sixty,
            NumberToWordResources.seventy, NumberToWordResources.eighty, NumberToWordResources.ninety};
        private static readonly string[] HUNDREDS =
            {"", NumberToWordResources.one_hundred, NumberToWordResources.Two_Hundred, NumberToWordResources.three_hundred, NumberToWordResources.four_hundred, NumberToWordResources.five_hundred,
            NumberToWordResources.six_hundred, NumberToWordResources.seven_hundred, NumberToWordResources.eight_hundred, NumberToWordResources.nine_hundred};


        public static string ToWords(this decimal number, bool showDecimals)
        {
            Regex r;
            string strNumber = number.ToString();
            string literal = "";
            string decimalString = null;
            strNumber = strNumber.Replace(".", ",");
            if (strNumber.IndexOf(",") == -1) strNumber = $"{strNumber},00";
            r = new Regex(@"\d{1,9},\d{1,2}");
            MatchCollection mc = r.Matches(strNumber);
            if (mc.Count > 0)
            {
                string[] numArray = strNumber.Split(',');
                if (numArray[1] != "00") decimalString = ToWords(Convert.ToDecimal(numArray[1]), false);
                else decimalString = NumberToWordResources.zero;
                if (Int64.Parse(numArray[0]) == 0) literal = NumberToWordResources.zero;
                else if (Int64.Parse(numArray[0]) > 999999) literal = getMillions(numArray[0]);
                else if (Int64.Parse(numArray[0]) > 999) literal = getThousands(numArray[0]);
                else if (Int64.Parse(numArray[0]) > 99) literal = getHundreds(numArray[0]);
                else if (Int64.Parse(numArray[0]) > 9) literal = getTens(numArray[0]);
                else literal = getUnits(numArray[0], noun: false);
                if (showDecimals) literal = $"{literal} {NumberToWordResources.with} {decimalString} {getDecimals(numArray[1].Trim().Length)}";

                return literal.Replace("  ", " ");
            }
            else return literal = null;
        }

        private static string getDecimals(int length)
        {
            System.Collections.Generic.List<string> decimalPart = new System.Collections.Generic.List<string>
            { NumberToWordResources.tenths,NumberToWordResources.cents,NumberToWordResources.thousandths,NumberToWordResources.ten_thousandths,NumberToWordResources.hundred_thousandths,
                NumberToWordResources.millionths,NumberToWordResources.ten_millionths,NumberToWordResources.hundred_millionths,NumberToWordResources.billionths };
            return decimalPart.Count > length ? decimalPart[length - 1] : "";
        }

        private static string getUnits(string number, bool noun)
        {
            string num = number.Substring(number.Length - 1);
            return number == "1" && noun? NumberToWordResources.one_noun : UNITS[int.Parse(num)];
        }

        private static string getTens(string number)
        {
            int n = int.Parse(number);
            if (n < 10) return getUnits(number, false);
            else if (n > 19)
            {
                string u = getUnits(number, false);
                if (u.Equals("")) return TENS[int.Parse(number.Substring(0, 1)) + 8];
                else return $"{TENS[int.Parse(number.Substring(0, 1)) + 8]} {NumberToWordResources.and} {u}";
            }
            else return TENS[n - 10];
        }

        private static string getHundreds(string number)
        {
            if (int.Parse(number) > 99)
            {
                if (int.Parse(number) == 100) return NumberToWordResources.hundred;
                else return $"{HUNDREDS[int.Parse(number.Substring(0, 1))] } { getTens(number.Substring(1))}";
            }
            else return getTens(int.Parse(number).ToString());
        }

        private static string getThousands(string number)
        {
            //if (int.Parse(number) == 1000) return NumberToWordResources.thousand;
            string c = number.Substring(number.Length - 3);
            string m = number.Substring(0, number.Length - 3);
            string n = "";
            if (int.Parse(m) > 0)
            {
                if (m != "1") n = $"{getHundreds(m)} ";
                return $"{n}{NumberToWordResources.thousand} {getHundreds(c)}";
            }
            else return getHundreds(c);
        }

        private static string getMillions(string number)
        {
            string miles = number.Substring(number.Length - 6);
            string million = number.Substring(0, number.Length - 6);
            string n = "";
            if (million.Length > 3) n = $"{getThousands(million)} {NumberToWordResources.millions}";
            else if (million.Length > 1 && million.Length < 4) n = $"{getHundreds(million)} {NumberToWordResources.millions}";
            else n = $"{getUnits(million, noun: true)} {(Int64.Parse(million) > 1? NumberToWordResources.millions : NumberToWordResources.million)}";
            return $"{n} {getThousands(miles)}";
        }
    }
}
