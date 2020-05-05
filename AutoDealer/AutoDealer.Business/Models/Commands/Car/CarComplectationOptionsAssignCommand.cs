using System.Collections.Generic;
using AutoDealer.Business.Interfaces.Models;

namespace AutoDealer.Business.Models.Commands.Car
{
    public class CarComplectationOptionsAssignCommand :ICreateCommand
    {
        public int ComplectationId { get; }
        public IEnumerable<string> Options { get; }

        public CarComplectationOptionsAssignCommand(int complectationId, IEnumerable<string> options)
        {
            ComplectationId = complectationId;
            Options = options;
        }
    }
}
