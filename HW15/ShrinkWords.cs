using System;
using System.Collections.Generic;

public class ShrinkWords
{

    private string _word;
    private List<string> _vocab = new List<string>{
                "MTAO", "OF", "TEC", "MXD", "T", "O", "AF", "AE", "A",
                "TAZ", "MTBXAE", "ABCDE", "TAEC", "MTOZE", "MITXFAEC", "MTAFC", "MTAFOC", "MTZABC",
                "MTAFOC", "MITXFFEC", "XAEC", "MTAFEC", "F", "MTBXAEC", "ZAEC", "MFECFEC", "TAX",
                "MTXAFEC", "TAFEC", "MXAFECI", "TAE", "ITXAFC", "MTAFOCC", "MITXAFEOC", "D", "MXITABFEC",
                "AC", "MTAFOC", "MD", "MTXABCD", "OA", "MITXAFEC", "OFMIT", "TED", "MTAEC",
                "MITXFAEE", "TAF", "TAC", "AEOC", "TA", "MITXAFC", "ITXAFEC", "MITXAFE", "MITAFEC"
            };
    public ShrinkWords(string word)
    {
        _word = word;
    }
    public void Solve()
    {
        ShrinkableWords(new List<string>());
    }
    private bool ShrinkableWords(List<string> result)
    {
        if (_word == "")
        {
            Output(result);
            return true;
        }
        // Each letter in the word is a choice to remove it. Loop through the word
        for (int x = 0; x < _word.Length; x++)
        {
            // If the word created by removing the letter is included in vocab, recursively call function
            if (_vocab.Contains(_word.Remove(x, 1)) || (_vocab.Contains(_word) && _word.Length == 1))
            {
                result.Add(_word);
                string temp = _word[x].ToString();
                _word = _word.Remove(x, 1);
                if (ShrinkableWords(result)) return true;
                _word = _word.Insert(x, temp);
                result.Remove(_word);
            }
        }
        return false;
    }
    private void Output(List<string> result)
    {
        foreach (string thing in result)
        {
            Console.Write(thing + " -> ");
        }
        Console.WriteLine("(empty)");
    }
}
