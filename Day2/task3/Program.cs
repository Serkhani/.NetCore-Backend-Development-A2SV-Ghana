    bool PalindromeChecker(string text)
    {
        string retStr = "";
        foreach (char ch in text)
        {
            int ascii_val = (int)ch;
            if ((97 <= ascii_val && ascii_val <= 122) || (48 <= ascii_val && ascii_val <= 57))
            {
                retStr += ch;
            }
            else if (65 <= ascii_val && ascii_val <= 90)
            {
                retStr += (char)(ascii_val + 32);
            }
        }
        retStr = retStr.ToLower();
        for (int l = 0; l < retStr.Length / 2; l++)
        {
            if (retStr[l] != retStr[retStr.Length - l - 1])
            {
                return false;
            }
        }
        return true;
    }

    // Psuedo-Testing
    Console.WriteLine(PalindromeChecker("A man, a plan, a canal: Panama")==true)
    Console.WriteLine(PalindromeChecker("race a car")==false)
    Console.WriteLine(PalindromeChecker("")==true)
    Console.WriteLine(PalindromeChecker(" ")==true)
    Console.WriteLine(PalindromeChecker("12321")==true)
    Console.WriteLine(PalindromeChecker("not a palindrome")==false)