using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ProjPasswordCheck.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PasswordValidatorController : ControllerBase
    {
        private readonly IEnumerable<IValidationRule> _validationRules;

        public PasswordValidatorController(IEnumerable<IValidationRule> validationRules)
        {
            _validationRules = validationRules;
        }
        
        [HttpPost]
        public ActionResult<ValidationResult> ValidatePassword([FromBody] string password)
        {
            var validationResults = _validationRules.Select(rule => rule.Validate(password));
            var aggregatedResult = AggregateValidationResults(validationResults);
            if (aggregatedResult.IsValid)
                return Ok(aggregatedResult);
            else
                return BadRequest(aggregatedResult);
        }

        private ValidationResult AggregateValidationResults(IEnumerable<ValidationResult> results)
        {
            var aggregatedResult = new ValidationResult
            {
                IsValid = true,
                Errors = new List<string>()
            };

            foreach (var result in results)
            {
                if (!result.IsValid)
                {
                    aggregatedResult.IsValid = false;
                    aggregatedResult.Errors.AddRange(result.Errors);
                }
            }

            return aggregatedResult;
        }
    }

    public interface IValidationRule
    {
        ValidationResult Validate(string password);
    }

    public class LengthValidationRule : IValidationRule
    {
        public ValidationResult Validate(string password)
        {
            var errors = new List<string>();

            // Verifica o comprimento da senha
            if (password.Length < 9)
                errors.Add("A senha deve ter pelo menos nove caracteres.");

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class DigitValidationRule : IValidationRule
    {
        public ValidationResult Validate(string password)
        {
            var errors = new List<string>();

            // Verifica se contém pelo menos 1 dígito
            if (!Regex.IsMatch(password, @"\d"))
                errors.Add("A senha deve conter pelo menos um dígito.");

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class LowercaseValidationRule : IValidationRule
    {
        public ValidationResult Validate(string password)
        {
            var errors = new List<string>();

            // Verifica se contém pelo menos 1 letra minúscula
            if (!Regex.IsMatch(password, "[a-z]"))
                errors.Add("A senha deve conter pelo menos uma letra minúscula.");

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class UppercaseValidationRule : IValidationRule
    {
        public ValidationResult Validate(string password)
        {
            var errors = new List<string>();

            // Verifica se contém pelo menos 1 letra maiúscula
            if (!Regex.IsMatch(password, "[A-Z]"))
                errors.Add("A senha deve conter pelo menos uma letra maiúscula.");

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class SpecialCharacterValidationRule : IValidationRule
    {
        public ValidationResult Validate(string password)
        {
            var errors = new List<string>();

            // Verifica se contém pelo menos 1 caractere especial
            if (!Regex.IsMatch(password, @"[!@#$%^&*()-+]"))
                errors.Add("A senha deve conter pelo menos um caractere especial.");

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class NoRepeatingCharactersValidationRule : IValidationRule
    {
        public ValidationResult Validate(string password)
        {
            var errors = new List<string>();

            // Verifica se não há caracteres repetidos
            var distinctChars = new HashSet<char>(password);
            if (distinctChars.Count != password.Length)
                errors.Add("A senha não deve conter caracteres repetidos.");

            return new ValidationResult
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class SpaceValidationRule : IValidationRule
    {
        public ValidationResult Validate(string password)
        {
            var errors = new List<string>();
            // Verifica se há espaços
            if (password.Contains(' '))
                errors.Add("A senha não deve conter espaços");

            return new ValidationResult()
            {
                IsValid = errors.Count == 0,
                Errors = errors
            };
        }
    }

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public List<string> Errors { get; set; }
    }
}
