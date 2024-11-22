using AutoMapper;
using MediatR;
using JM.Domain.CommonDTO;
using JM.Application.Common.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using JM.Application.Services.Supplier_S;

namespace JM.Application.Services.Common_S
{
    public class GetCommonComboQuery : IRequest<IEnumerable<CommonComboDto>>
    {
        public string TableName { get; set; }
        public string ValueField { get; set; }
        public string TextField { get; set; }
        public int companyid { get; set; }


    }
    public class GetCommonComboQueryValidator : AbstractValidator<GetCommonComboQuery>
    {

        public GetCommonComboQueryValidator()
        {

            RuleFor(x => x.TableName)
                .NotEmpty().WithMessage("Table Name is required");
            RuleFor(x => x.ValueField)
                .NotEmpty().WithMessage("Value Field is required");
            RuleFor(x => x.TextField)
               .NotEmpty().WithMessage("TextField is required");
            RuleFor(x => x.companyid)
               .GreaterThan(0).WithMessage("Company Id must be greater than 0.");
        }
    }
    public class GetCommonComboHandlerQuery : IRequestHandler<GetCommonComboQuery, IEnumerable<CommonComboDto>>
    {
        private readonly IUnitOfWorkJM _unitOfWork;
        public GetCommonComboHandlerQuery(IUnitOfWorkJM unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<CommonComboDto>> Handle(GetCommonComboQuery request, CancellationToken cancellationToken)
        {
            var validator = new GetCommonComboQueryValidator();
            var validationResult = validator.Validate(request);

            if (!validationResult.IsValid)
            {
                return null;
            }

            string commaSepartedString = $"{request.ValueField},{request.TextField},{request.TableName}";
            commaSepartedString += $",{"isdeleted"},{"0"}";
            return await _unitOfWork.Common.GetCommonComboData(commaSepartedString, request.companyid);
        }
    }
}
