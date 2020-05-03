using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Car;
using AutoDealer.Business.Models.Commands.Miscellaneous;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Miscellaneous
{
    public interface IColorCodeCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<ColorCodeCreateCommand>
    {
        Task AssignAsync(CarColorAssignmentCommand assignCommand);

        Task UnassignAsync(CarColorAssignmentCommand unassignCommand);
    }
}
