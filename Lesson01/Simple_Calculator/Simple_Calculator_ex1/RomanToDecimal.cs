namespace Simple_Calculator_ex1
{
    public class RomanToDecimal
    {
        private const int MAX_VALUE = 3999;
        private const int MAX_REPEATS = 3;
        private const int MIN_REPEATS = 1;
        /*
         ****************************************************************************************************
         * Write exceptions for the specifications for a method that converts a Roman numeral to an integer.*
         ****************************************************************************************************
         
         * The Specifications are as follows:
         * * I, X, C, M can be repeated up to 3 times consecutively (e.g., 4 is IV, not IIII)
         * * V, L, D cannot be repeated
         * * Only I, X, C can be used as subtractive numerals
         * * The largest value that can be represented is 3999 (MMMCMXCIX)
         
         */

        public int RomanToInt(string symbol)
        {
            Dictionary<char, int> romanMap = new Dictionary<char, int>
            {
                {'I', 1},
                {'V', 5},
                {'X', 10},
                {'L', 50},
                {'C', 100},
                {'D', 500},
                {'M', 1000}
            };
            int total = 0;
            int prevValue = 0;
            /* * ..Length - 1 : is to start from the last character of the string and subtract 1 to get the correct index i.e. for a string of length 2, the last index is 1
             * * i-- : is to decrement the index to move backwards through the string
            */
            if(string.IsNullOrEmpty(symbol) || string.IsNullOrWhiteSpace(symbol))
            {
                throw new ArgumentException("Input cannot be null or empty");
            }                               
            int count = 1;
            for (int i = 1; i < symbol.Length; i++)
            {
                //System.Diagnostics.Debug.WriteLine($"Current symbol: {symbol[i]}, Count: {count}");


                if (!romanMap.ContainsKey(symbol[i]))
                {
                    throw new ArgumentException($"Invalid Roman numeral character: {symbol[i]}");
                }
                if (symbol[i] == symbol[i - 1])
                {
                    count++;
                    if (IsNotRepeated_V_L_D(symbol[i], count))
                    {
                        throw new ArgumentException($"Character {symbol[i]} cannot be repeated");
                    }
                    if(RepeatedMax_3_Times(symbol[i], count))
                    {
                        throw new ArgumentException($"Character {symbol[i]} cannot be repeated more than 3 times");
                    }
                }
                else
                {
                    count = 1;
                }
            }

            for (int i = symbol.Length - 1; i >= 0; i--)
            {
                char currentChar = symbol[i];
                int currentValue = romanMap[currentChar];
                if (currentValue < prevValue)
                {
                    if (IsSubtractiveNumeral(currentChar))
                    {
                        total -= currentValue;
                    }
                    else
                    {
                        throw new ArgumentException($"Character {currentChar} cannot be used as a subtractive numeral");
                    }
                }
                else
                {
                    total += currentValue;
                }
                prevValue = currentValue;
            }
            return LargestValue_3999(total) ? throw new ArgumentException($"Value exceeds the maximum limit of {MAX_VALUE}") :
                   total;
        }


        private bool IsNotRepeated_V_L_D(char currentChar, int count)
        {
            if ((currentChar == 'V' || currentChar == 'L' || currentChar == 'D') && count > MIN_REPEATS)
            {
                return true;
            }
            return false;
        }
        private bool RepeatedMax_3_Times(char currentChar, int count)
        {
            if ((currentChar == 'I' || currentChar == 'X' || currentChar == 'C' || currentChar == 'M') && count > MAX_REPEATS)
            {
                return true;
            }
            return false;
        }
        private bool IsSubtractiveNumeral(char currentChar)
        {
            if (currentChar == 'I' || currentChar == 'X' || currentChar == 'C')
            {
                return true;
            }
            return false;
        }
        private bool LargestValue_3999(int value)
        {
            if (value >= MAX_VALUE)
            {
                return true;
            }
            return false;
        }

    }
}
