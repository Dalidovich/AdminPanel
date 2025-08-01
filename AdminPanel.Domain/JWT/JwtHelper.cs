﻿using Microsoft.IdentityModel.Tokens;

namespace AdminPanel.Domain.JWT
{
    public static class JwtHelper
    {
        public static bool CustomLifeTimeValidator(DateTime? nbf, DateTime? exp, SecurityToken tokenToValidate, TokenValidationParameters @param)
        {
            return exp != null ? exp > DateTime.UtcNow : false;
        }
    }
}
