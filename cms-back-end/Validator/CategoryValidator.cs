using cms_back_end.Models;
using FluentValidation;

namespace cms_back_end.Validator
{
	public class CategoryValidator : AbstractValidator<Category>
	{
		public CategoryValidator()
		{
			RuleFor(x => x.Nome)
				.NotEmpty()
				.WithMessage("Campo Obrigatório");
		}
	}
}
