using System;
using System.Collections.Generic;

public class DoctorHours
{
    private List<int> _doctorHours;
    private List<int> _patientHours;
    public DoctorHours(List<int> doctorHours, List<int> patientHours)
    {
        _doctorHours = doctorHours;
        _patientHours = patientHours;
    }

    public void Solve()
    {
        var result = new List<string>();
        Scheduler(result);
    }
    bool Scheduler(List<string> result)
    {
        // If there are no more patients to assign, output
        if (_patientHours.Count == 0)
        {
            foreach (string thing in result)
            {
                Console.WriteLine(thing);
            }
            return true;
        }

        var newPatients = new List<int>(_patientHours);
        var newDoctors = new List<int>(_doctorHours);

        // Each patient is a choice, loop through them
        for (int j = 0; j < _patientHours.Count; j++)
        {
            // If the first doctor can take that patient, recursively call function and perform the necessary changes to the lists
            if (newDoctors[0] >= newPatients[j])
            {
                result.Add("Doctor with " + newDoctors[0] + " hours takes patient with " + newPatients[j] + " hours");
                newDoctors[0] -= newPatients[j];
                newPatients.RemoveAt(j);
                if (newDoctors[0] == 0)
                {
                    newDoctors.RemoveAt(0);
                }
                var temp1 = _patientHours;
                var temp2 = _doctorHours;
                _patientHours = newPatients;
                _doctorHours = newDoctors;
                if (Scheduler(result))
                {
                    return true;
                }
                _patientHours = temp1;
                _doctorHours = temp2;
                newPatients = new List<int>(_patientHours);
                newDoctors = new List<int>(_doctorHours);
                result.RemoveAt(result.Count - 1);
            }
        }
        // If there is no way to assign the patients, this branch is dead.
        return false;
    }
}
