using AutoMapper;
using FluentValidation;
using JM.Application.Common.Generic;
using JM.Domain.DTOs;
using JM.Domain.Entities;
using JM.Domain.RTOs;
using JM.Infrastructure.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JM.Application.Services.Supplier_S
{
    public class GetSupplierByIdQuery : IRequest<ResponseResult>
    {
        public int SupplierId { get; set; }
    }
    public class GetSupplierByIdQueryValidator : AbstractValidator<GetSupplierByIdQuery>
    {
        public GetSupplierByIdQueryValidator()
        {
            RuleFor(x => x.SupplierId)
            .GreaterThan(0)
            .WithMessage("Supplier Id must be greater than 0.");
        }
    }
    public class GetSupplierByIdHandler : IRequestHandler<GetSupplierByIdQuery, ResponseResult>
    {
        private readonly IUnitOfWorkJM _unitOfWork;
        private readonly IMapper _mapper;
        public GetSupplierByIdHandler(IUnitOfWorkJM unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResult> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                var validator = new GetSupplierByIdQueryValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    rr.Message = "Error: " + string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                    rr.StatusCode = 1000;
                    rr.IsSuccessStatus = false;
                    return rr;
                }

                var result = await _unitOfWork.SupplierRepo.GetSupplierAll();
                rr.Message = "Successfull";
                rr.StatusCode = 2000;
                rr.IsSuccessStatus = true;
                rr.Data = result;
                return rr;


            }
            catch (Exception ex)
            {
                _unitOfWork.Rollback();
                rr.Message = "Failed!! " + ex.Message;
                rr.StatusCode = 4000;
                rr.IsSuccessStatus = false;
                return rr;
                throw;
            }

        }
    }
}
