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
    public class GetSupplierAllQuery : IRequest<ResponseResult>
    {
        public int CompanyId { get; set; }
    }
    public class GetSupplierAllQueryValidator : AbstractValidator<GetSupplierAllQuery>
    {

        public GetSupplierAllQueryValidator()
        {

            RuleFor(x => x.CompanyId)
            .GreaterThan(0)
            .WithMessage("Company Id must be greater than 0.");

        }
    }
    public class GetAllSupplierHandler : IRequestHandler<GetSupplierAllQuery, ResponseResult>
    {
        private readonly IUnitOfWorkJM _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllSupplierHandler(IUnitOfWorkJM unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<ResponseResult> Handle(GetSupplierAllQuery request, CancellationToken cancellationToken)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                var validator = new GetSupplierAllQueryValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    rr.Message = "Error: " + string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                    rr.StatusCode = 1000;
                    rr.IsSuccessStatus = false;
                    return rr;
                }
                var result = await _unitOfWork.SupplierRepo.GetSupplierAll(request.CompanyId);
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
