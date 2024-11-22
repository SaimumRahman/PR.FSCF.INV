using AutoMapper;
using FluentValidation;
using MediatR;
using JM.Domain.CommonDTO;
using JM.Infrastructure.Models;
using JM.Application.Common.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JM.Application.Services.Common_S
{
    public class CommonDeleteCommand : IRequest<ResponseResult>
    {
        public CommonDeleteDto commonDeleteDto { get; set; }
    }
    public class CommonDeleteCommandValidator : AbstractValidator<CommonDeleteCommand>
    {
        public CommonDeleteCommandValidator()
        {
            RuleFor(x => x.commonDeleteDto.TableName)
                .NotEmpty().WithMessage("Table Name cannot be empty")
                .NotNull().WithMessage("Table Name cannot be null");

            RuleFor(x => x.commonDeleteDto.ColumnName)
                .NotEmpty().WithMessage("Column Name cannot be empty")
                .NotNull().WithMessage("Column Name cannot be null");

            RuleFor(x => x.commonDeleteDto.PrimaryKey)
                .GreaterThan(0).WithMessage("Primary Key must be greater than 0");

            RuleFor(x => x.commonDeleteDto.UserId)
                .GreaterThan(0).WithMessage("User Id must be greater than 0");
            
            RuleFor(x => x.commonDeleteDto.Companyid)
                .GreaterThan(0).WithMessage("Company Id must be greater than 0");

            RuleFor(x => x.commonDeleteDto.DeletedPC)
                .NotEmpty().WithMessage("DeletedPC cannot be empty")
                .NotNull().WithMessage("DeletedPC cannot be null");
        }
    }
    public class CommonDeleteCommandHandler : IRequestHandler<CommonDeleteCommand, ResponseResult>
    {
        private readonly IUnitOfWorkJM _unitOfWork;
        public CommonDeleteCommandHandler(IUnitOfWorkJM unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ResponseResult> Handle(CommonDeleteCommand request, CancellationToken cancellationToken)
        {
            ResponseResult rr = new ResponseResult();
            try
            {
                var validator = new CommonDeleteCommandValidator();
                var validationResult = validator.Validate(request);

                if (!validationResult.IsValid)
                {
                    rr.Message = "Error: " + string.Join("\n", validationResult.Errors.Select(x => x.ErrorMessage));
                    rr.StatusCode = 1000;
                    rr.IsSuccessStatus = false;
                    return rr;
                }
                _unitOfWork.BeginTransaction();
                var result =  await _unitOfWork.Common.DeleteData(request.commonDeleteDto.TableName, request.commonDeleteDto.UserId
                                                                    , request.commonDeleteDto.DeletedPC
                                                                    , request.commonDeleteDto.ColumnName, request.commonDeleteDto.PrimaryKey,request.commonDeleteDto.Companyid);
                _unitOfWork.Commit();
                if (result > 0)
                {
                    rr.Message = "Data Deleted Successfully";
                    rr.StatusCode = 2000;
                    rr.IsSuccessStatus = true;
                    return rr;
                }
                else
                {
                    rr.Message = "Failed!! Data Not Deleted";
                    rr.StatusCode = 3000;
                    rr.IsSuccessStatus = false;
                    return rr;
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
