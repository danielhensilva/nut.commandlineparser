using System;
using Nut.CommandLineParser.Extensions;

namespace Nut.CommandLineParser.Exceptions
{
    public class UnexpectedTokenException : Exception
    {
        public int Index { get; }

        public string Token { get; }

        public UnexpectedTokenException(int index, string token)
            : this(index, token, GenerateMessage(index, token))
        {
        }

        private UnexpectedTokenException(int index, string token, string message)
            : base(message) 
        {
            Index = index;
            Token = token;
        }

        private static string GenerateMessage(int index, string token)
        {
            if (index < 0)
                throw new ArgumentException("Value cannot be negative.", nameof(index));

            if (token == null)
                throw new ArgumentNullException(nameof(token));

            if (token.IsEmptyOrWhitespace())
                throw new ArgumentException("Value cannot be empty.", nameof(token));

            return $"Unexpected token {token} at index {index}.";
        }
    }
}