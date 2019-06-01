using System;


namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }

        public double CaloriesPerMInute { get; }

        public Activity(string name, double caloriesPerMInute)
        {
            Name = name;
            CaloriesPerMInute = caloriesPerMInute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
