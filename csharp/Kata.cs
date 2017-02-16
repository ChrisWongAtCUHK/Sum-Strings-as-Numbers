using System;
using System.Text;
using System.Text.RegularExpressions;
public static class Kata
{
    public static string sumStrings(string a, string b)
    {
        // if both are empty, return 0
        if (String.IsNullOrEmpty(a) && String.IsNullOrEmpty(b)) return "0";
        // if one of them is empty, return the other one
        if (String.IsNullOrEmpty(a)) return b;
        if (String.IsNullOrEmpty(b)) return a;

        // remove the leading 0s
        Regex rgx = new Regex("^0*");
        a = rgx.Replace(a, "");
        b = rgx.Replace(b, "");

        bool carry = false;
        StringBuilder reverseSum = new StringBuilder();

        int pointerA = a.Length - 1;
        int pointerB = b.Length - 1;
        // start from the last digit
        // add them
        // if the sum is greater than 9, carry is true
        // move left 1 digit, take carry in account
        // if one of them has no digit, the other one's remains occupy
        while(true)
        {
            int sum = Add(a[pointerA--].ToString(), b[pointerB--].ToString());

            if (carry) sum++;

            carry = sum > 9;

            reverseSum.Append(sum % 10);

            if (pointerA < 0 || pointerB < 0) 
                break;
        }


        if (pointerA < 0 && pointerB < 0)
        {
            return carry ? "1" + Reverse(reverseSum) : Reverse(reverseSum);
        }
        else if(pointerA < 0)
        {
            return HandleRemain(carry, b, pointerB, reverseSum);
        }
        else if (pointerB < 0)
        {
            return HandleRemain(carry, a, pointerA, reverseSum);
        }

        return null;
    }

    /// <summary>
    /// Add 2 digits
    /// </summary>
    /// <param name="s1"></param>
    /// <param name="s2"></param>
    /// <returns></returns>
    static int Add(string s1, string s2)
    {
        int num1 = Int32.Parse(s1.ToString());
        int num2 = Int32.Parse(s2.ToString());
        return num1 + num2;
    }

    /// <summary>
    /// Reverse a string
    /// </summary>
    /// <param name="sb"></param>
    /// <returns></returns>
    static string Reverse(StringBuilder sb)
    {
        char[] array = sb.ToString().ToCharArray();
        Array.Reverse(array);
        return new String(array);
    }

    /// <summary>
    /// Handle the remain
    /// </summary>
    /// <param name="carry"></param>
    /// <param name="s"></param>
    /// <param name="pointer"></param>
    /// <param name="reverseSum"></param>
    /// <returns></returns>
    static string HandleRemain(bool carry, string s, int pointer, StringBuilder reverseSum)
    {
        while (carry)
        {
            int sum = Add(s[pointer--].ToString(), "1");

            carry = sum > 9;

            reverseSum.Append(sum % 10);

            if (pointer < 0)
            {
                return carry ? "1" + Reverse(reverseSum) : Reverse(reverseSum);
            }
        }
        return s.Substring(0, pointer + 1) + Reverse(reverseSum);
    }
}

