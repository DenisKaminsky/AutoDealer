﻿using System;
using System.Threading.Tasks;
using AutoDealer.Business.Control;
using AutoDealer.Business.Functionality.CommandFunctionality.Base;
using AutoDealer.Business.Interfaces.CommandFunctionality.Order;
using AutoDealer.Business.Interfaces.Factories;
using AutoDealer.Business.Interfaces.UnitOfWork;
using AutoDealer.Business.Models.Commands.Order;
using AutoDealer.Data.Interfaces.RelationsProviders.Order;
using AutoDealer.Data.Interfaces.Repositories;
using AutoDealer.Data.Models.Order;
using AutoDealer.Miscellaneous.Enums;
using FluentValidation;

namespace AutoDealer.Business.Functionality.CommandFunctionality.Order
{
    public class DeliveryRequestCommandFunctionality : BaseGenericCreateDeleteCommandFunctionality<DeliveryRequestCreateCommand, DeliveryRequest>, IDeliveryRequestCommandFunctionality
    {
        private readonly IGenericReadRepository _readRepository;
        private readonly IDeliveryRequestRelationsProvider _relationsProvider;

        public DeliveryRequestCommandFunctionality(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IGenericWriteRepository writeRepository, IValidatorFactory validatorFactory, IGenericReadRepository readRepository, IDeliveryRequestRelationsProvider relationsProvider) : base(unitOfWork, mapperFactory, writeRepository, validatorFactory)
        {
            _readRepository = readRepository;
            _relationsProvider = relationsProvider;
        }

        public async Task AssignAsync(DeliveryRequestAssignCommand command)
        {
            using (await BusinessLocks.DeliveryRequestAssignmentLock.LockAsync())
            {
                await ValidatorFactory.GetValidator<DeliveryRequestAssignCommand>().ValidateAndThrowAsync(command);

                var deliveryRequest = await _readRepository.GetByIdAsync<DeliveryRequest>(command.DeliveryRequestId);
                deliveryRequest.StatusId = (int)DeliveryRequestStatuses.InProgress;
                deliveryRequest.SupplierManagerId = command.SupplierManagerId;

                await WriteRepository.UpdateAsync(deliveryRequest);
                await UnitOfWork.CommitAsync();
            }
        }

        public async Task Promote(DeliveryRequestPromoteCommand command)
        {
            using (await BusinessLocks.DeliveryRequestPromotionLock.LockAsync())
            {
                await ValidatorFactory.GetValidator<DeliveryRequestPromoteCommand>().ValidateAndThrowAsync(command);

                await UnitOfWork.BeginTransactionAsync();
                var deliveryRequest = await _readRepository.GetByIdAsync<DeliveryRequest>(command.DeliveryRequestId, _relationsProvider.JoinInfoForPromotion);
                var newStatus = deliveryRequest.StatusId + 1;
                if (newStatus == (int)DeliveryRequestStatuses.Closed)
                {
                    deliveryRequest.CompletedDate = DateTime.UtcNow;
                    if (deliveryRequest.Order == null)
                    {
                        deliveryRequest.Car.Amount += deliveryRequest.Amount;
                    }
                }
                deliveryRequest.StatusId = newStatus;

                await WriteRepository.UpdateAsync(deliveryRequest);
                await UnitOfWork.CommitAsync();
            }
        }
    }
}
