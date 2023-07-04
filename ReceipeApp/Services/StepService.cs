using ReceipeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceipeApp.Services
{
    class StepService
    {
        // StepService maintains a list of steps
        private readonly List<Step> stepList;

        // Initialize step service with an empty list of steps
        public StepService()
        {
            stepList = new List<Step>();
        }

        // Get a step by its ID
        public Step GetStepById(int id)
        {
            return stepList.FirstOrDefault(s => s.Number == id);
        }

        // Create a list of steps from user input
        public List<Step> CreateStepsFromInput(string input)
        {
            // Create a new list to store the steps
            List<Step> stepList = new List<Step>();

            // Split the input string into an array of steps
            string[] stepArray = input.Split(';');

            // Loop through the array of steps
            for (int i = 0; i < stepArray.Length; i++)
            {
                // Create a new Step object
                Step step = new Step();

                // Assign the step number and description
                step.Number = i + 1;
                step.Description = stepArray[i].Trim();

                // Add the step to the list
                stepList.Add(step);
            }

            // Return the list of steps
            return stepList;
        }

        // Get all steps
        public IEnumerable<Step> GetAllSteps()
        {
            return stepList;
        }

        // Update a step by its ID
        public void UpdateStep(int id, Step payload)
        {
            // Check if the payload is null
            if (payload == null)
                throw new ArgumentException($"Step with id {id} not found.");

            // Get the step with the given ID
            Step step = GetStepById(id);

            // If the step is null, throw an exception
            if (step == null)
                throw new ArgumentNullException(nameof(step));

            // Update the step description
            step.Description = payload.Description;
        }

        // Delete a step by its ID
        public void DeleteStep(int id)
        {
            // Get the step with the given ID
            Step step = GetStepById(id);

            // If the step is null, throw an exception
            if (step == null)
                throw new ArgumentException($"Step with id {id} not found.");

            // Remove the step from the list
            stepList.Remove(step);
        }
    }
}
