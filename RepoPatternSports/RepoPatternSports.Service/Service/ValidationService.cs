using RepoPatternSports.Repository.DTOs;
using RepoPatternSports.Repository.Models;
using RepoPatternSports.Service.DTOs;
using RepoPatternSports.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RepoPatternSports.Service.Service
{
    public class ValidationService : IValidationService
    {
        public Task<ValidationErrorDTO> ValidateUser(RegisterDTO registerDTO)
        {
            ValidationErrorDTO response = new ValidationErrorDTO();
            response.Status = 200;
            response.Message = "Validation successful.";

            List<string> errors = new List<string>();

            if (string.IsNullOrWhiteSpace(registerDTO.Firstname))
            {
                errors.Add("Firstname is required.");
            }

            if (string.IsNullOrWhiteSpace(registerDTO.Lastname))
            {
                errors.Add("Lastname is required.");
            }

            if (string.IsNullOrWhiteSpace(registerDTO.Email))
            {
                errors.Add("Email is required.");
            }
            else if (!IsValidEmail(registerDTO.Email))
            {
                errors.Add("Invalid email format.");
            }

            if (!string.IsNullOrWhiteSpace(registerDTO.ContactNumber) && !IsValidPhoneNumber(registerDTO.ContactNumber))
            {
                errors.Add("Invalid contact number format.");
            }

            if (errors.Any())
            {
                response.Status = 400;
                response.Message = "Validation failed.";
                response.Errors = errors;
            }
            bool IsValidEmail(string email)
            {
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    return addr.Address == email;
                }
                catch
                {
                    return false;
                }
            }

            bool IsValidPhoneNumber(string phoneNumber)
            {
                // You can implement your own logic for validating phone numbers
                // This is just a simple example
                return Regex.Match(phoneNumber, @"^\d{10}$").Success;
            }

            return Task.FromResult(response);

        }

        }


    }


