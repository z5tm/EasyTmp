using System;
using System.Collections.Generic;

namespace EasyTmp;

public class EasyArgs
{
    private List<string> _ttb;
    
    
    public static EasyArgs Build() => new EasyArgs(){_ttb = new List<string>()};
    public EasyArgs Blue(string text)
    {
        var bluetrimmedtext = text.Trim();
        var bluetext = $"<color=blue>{bluetrimmedtext}</color>";
        _ttb.Add(bluetext);
        return this;
    }

    public EasyArgs Orange(string text)
    {
        var orangetrimmedtext = text.Trim();
        var orangetext = $"<color=orange>{orangetrimmedtext}</color>";
        _ttb.Add(orangetext);
        return this;
    }
    public EasyArgs Red(string text)
    {
        var redtrimmedtext = text.Trim();
        var redtext = $"<color=orange>{redtrimmedtext}</color>";
        _ttb.Add(redtext);
        return this;
    }

    public EasyArgs Yellow(string text)
    {
        var yellowtrimmedtext = text.Trim();
        var yellowtext = $"<color=orange>{yellowtrimmedtext}</color>";
        _ttb.Add(yellowtext);
        return this;
    }
    public EasyArgs Pos(long num, string text1)
    {
        var text = $"<pos={num}>{text1}</pos>";
        _ttb.Add(text);
        return this;
    }
    public EasyArgs Parameter(string text)
    {
        var parametertrimmed = text.Trim();
        var param = $"<color=orange>[</color><color=blue>{parametertrimmed}</color><color=orange>]</color>";
        _ttb.Add(param);
        return this;
    }
    public EasyArgs Parameters(string text)
    {
        var split = text.Split([' '], StringSplitOptions.RemoveEmptyEntries); // this, of course, splits the text into a list ! remove empty entries juusst in case i ever want to use this elsewhere.

        for (int i = 0; i < split.Length; i++) // set i to 0 first, iteration 0 -- check if i is less than split length (if true continue), then after each run iterate i by one.
        {
            var part = split[i]; // this is a cool way to use the iterations we just created to define which part of the split we're in !
            bool isLast = (i == split.Length - 1); // this checks if it's last, so i can add spaces if it's not !
        
            var formatted = $"<color=orange>[</color><color=blue>{part}</color><color=orange>]</color>";

            if (isLast)
            {
                _ttb.Add(formatted); // this adds the formatted text without the extra space like we do below, since it's the last !
                return this; // this just leaves.
            }

            _ttb.Add(formatted + " ");
        }
    
        return this;
    } // sorry for comments, new concept
    public EasyArgs CmdArguments(string text)
    {
        var split = text.Split([' '], StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < split.Length; i++)
        {
            var part = split[i];
            bool isLast = (i == split.Length - 1);
            bool isFirst = (i == 0);

            var argumentsStart = "<color=orange>Arguments:</color>\n";
            var begin = $"<color=blue>{part}</color>";
            var formatted = $"<color=orange>[</color><color=blue>{part}</color><color=orange>]</color>";
            
            if (isFirst)
            {
                _ttb.Add(argumentsStart + begin);
                return this;
            }
            if (isLast)
            {
                _ttb.Add(formatted);
                return this;
            }

            _ttb.Add(formatted + " ");
        }
    
        return this;
    }
    public EasyArgs Space()
    {
        _ttb.Add(" ");
        return this;
    }
    public EasyArgs NewLine()
    {
        _ttb.Add("\n");
        return this;
    }

    public string Done()
    {
        var gaming = string.Join("", _ttb);
        return gaming;
    }
}