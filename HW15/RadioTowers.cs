using System;
using System.Collections.Generic;

public class RadioTowers
{
    private double[,] _coords;
    private double _d;
	public RadioTowers (double[,] coords, double d) {
        _coords = coords;
        _d = d;
	}
    public void Solve()
    {
        var results = new List<string>();
        int numberOfFrequencies = 1;
        var frequencies = new List<int>();
        Frequencies(results, numberOfFrequencies, frequencies, 0);
    }

    bool Frequencies(List<string> results, int numberOfFrequencies, List<int> frequencies, int index)
    {
        // Have all towers been assigned a frequency - if so, output
        if (_coords.Length / 2 == frequencies.Count)
        {
            foreach (string thing in results)
            {
                Console.WriteLine(thing);
            }
            return true;
        }
        var newCoords = _coords;
        var possibleFrequencies = new List<int> { };

        // Create a list of possible frequencies from the number of frequencies that we are working with.
        for (int x = 1; x <= numberOfFrequencies; x++)
        {
            possibleFrequencies.Add(x);
        }

        // Subtract frequencies that cannot be chosen for the given tower, because there is a tower within d distance with the same frequency.
        for (int k = index - 1; k >= 0; k--)
        {
            double distance = Math.Sqrt(Math.Pow((newCoords[k, 0] - newCoords[index, 0]), 2) + Math.Pow((newCoords[k, 1] - newCoords[index, 1]), 2));
            if (distance <= _d && possibleFrequencies.Contains(frequencies[k]))
            {
                possibleFrequencies.Remove(frequencies[k]);
            }
        }

        // If there are no possible frequencies, this branch is dead
        if (possibleFrequencies.Count == 0)
        {
            return false;
        }

        // Each remaining possible frequency is a choice - assign each frequency to the tower in a recursive call.
        for (int j = 0; j <= possibleFrequencies.Count - 1; j++)
        {
            frequencies.Add(possibleFrequencies[j]);
            results.Add("Tower " + (index + 1) + " gets Frequency " + possibleFrequencies[j]);
            if (!Frequencies(results, numberOfFrequencies, frequencies, index + 1))
            {
                // If this entire branch is dead, start a new recursive call but increase the number of frequencies to work with.
                if (Frequencies(new List<string>(), numberOfFrequencies + 1, new List<int>(), 0))
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            frequencies.RemoveAt(frequencies.Count - 1);
            results.RemoveAt(frequencies.Count - 1);
        }
        return false;

    }
}
