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
    public class CreateUpdateSupplierCommand : BaseModelCreateUpdateRTO, IRequest<ResponseResult>
    {
        public SupplierRTO supplierRTO { get; set; }
    }
    public class CreateUpdateSupplierCommandValidator : AbstractValidator<CreateUpdateSupplierCommand>
    {

        public CreateUpdateSupplierCommandValidator()
        {

            RuleFor(x => x.supplierRTO.SupplierName)
                .NotEmpty().WithMessage("Supplier Name is required")
                .Length(2, 100).WithMessage("Supplier Name must be between 2 and 100 characters");

            RuleFor(x => x.supplierRTO.ContactPersonNumber)
                .Matches(@"^\+?[0-9]*$").WithMessage("Contact Person Number must be a valid phone number");

        }
    }
    public class CreateUpdateSupplierHandler : IRequestHandler<CreateUpdateSupplierCommand, ResponseResult>
    {
        private readonly IUnitOfWorkJM _unitOfWork;
        private readonly IMapper _mapper;
        public CreateUpdateSupplierHandler(IUnitOfWorkJM unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        public async Task<ResponseResult> Handle(CreateUpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            ResponseResult rr = new ResponseResult();
            int result = 0;
            try
            {
                var validator = new CreateUpdateSupplierCommandValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    rr.Message = "Error: " + string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                    rr.StatusCode = 1000;
                    rr.IsSuccessStatus = false;
                    return rr;
                }
                if (request.supplierRTO.SupplierId>0)
                {
                    var dataUp = _mapper.Map<Supplier>(request.supplierRTO);
                    dataUp.UpdateBy=request.UpdateBy;
                    dataUp.UpdatePc=request.UpdatePc;
                    dataUp.UpdateOn=request.UpdateOn;

                    _unitOfWork.BeginTransaction();
                    result = await _unitOfWork.SupplierRepo.UpdateSupplierById(dataUp);
                    _unitOfWork.Commit();
                    if (result > 0)
                    {
                        rr.Message = "Property Setting Updated Successfully";
                        rr.StatusCode = 2000;
                        rr.IsSuccessStatus = true;
                        return rr;
                    }
                    else
                    {
                        rr.Message = "Failed!! Property Setting NOT Updated";
                        rr.StatusCode = 3000;
                        rr.IsSuccessStatus = false;
                        return rr;
                    }

                }
                else
                {
                    var data = _mapper.Map<Supplier>(request.supplierRTO);

                    data.CreateBy = request.CreateBy;
                    data.CreateOn = request.CreateOn;
                    data.CreatePc = request.CreatePc;
                    data.CompanyId = request.CompanyId;

                    _unitOfWork.BeginTransaction();
                    await _unitOfWork.SupplierRepo.Add(data);
                    result = await _unitOfWork.SaveChangesAsync();
                    _unitOfWork.Commit();
                    if (result > 0)
                    {
                        rr.Message = "Property Setting Saved Successfully";
                        rr.StatusCode = 2000;
                        rr.IsSuccessStatus = true;
                        return rr;
                    }
                    else
                    {
                        rr.Message = "Failed!! Property Setting NOT Saved";
                        rr.StatusCode = 3000;
                        rr.IsSuccessStatus = false;
                        return rr;
                    }

                }

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
