﻿using System.Threading.Tasks;
using AutoDealer.Business.Interfaces.CommandFunctionality.Base;
using AutoDealer.Business.Models.Commands.Order;

namespace AutoDealer.Business.Interfaces.CommandFunctionality.Order
{
    public interface IDeliveryRequestCommandFunctionality : IBaseGenericCreateDeleteCommandFunctionality<DeliveryRequestCreateCommand>
    {
        Task AssignAsync(DeliveryRequestAssignCommand command);
        Task Promote(DeliveryRequestPromoteCommand command);
    }
}
