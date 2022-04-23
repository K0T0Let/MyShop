namespace MyShop.data.Utilit.MethodsExtension
{
    public static class StringExtension
    {
        public static double ToDouble(this string s)
        {
            double result = 0;
            if (double.TryParse(s, out var x))
                result = x;
            else
            {
                if (s.Contains("."))
                    s = s.Replace(".", ",");
                else if (s.Contains(","))
                    s = s.Replace(",", ".");
                try { result = double.Parse(s); }
                catch { }
                    
            }
            return result;
        }

        public static bool TryToDouble(this string s, out double d)
        {
            double result = 0;
            bool resultTry = false;

            if (double.TryParse(s, out var x))
            {
                result = x;
                resultTry = true;
            }
            else
            {
                if (s.Contains("."))
                    s = s.Replace(".", ",");
                else if (s.Contains(","))
                    s = s.Replace(",", ".");
                resultTry = double.TryParse(s, out var i);
                result = i;
            }

            d = result;
            return resultTry;
        }
    }
}
