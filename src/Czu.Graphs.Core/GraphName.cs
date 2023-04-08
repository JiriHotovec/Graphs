﻿using System;
using Czu.Graphs.Core.Exceptions;

namespace Czu.Graphs.Core
{
    /// <summary>
    /// Object represents graph name
    /// </summary>
    public sealed class GraphName : IEquatable<GraphName>
    {
        /// <summary>
        /// Max. limit for name length
        /// </summary>
        public const int NameMaxLength = 255;

        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="value">Graph name</param>
        /// <exception cref="ModelException">Custom exception for model validation</exception>
        public GraphName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ModelException($"Graph name cannot be empty");
            }

            if (value.Length > NameMaxLength)
            {
                throw new ModelException($"Graph name length must be equal or less than {NameMaxLength} chars");
            }

            Value = value;
        }

        /// <summary>
        /// Value of the name
        /// </summary>
        public string Value { get; }

        /// <inheritdoc />
        public override string ToString() => Value;

        public static implicit operator string(GraphName vertex)
        {
            return vertex.Value;
        }

        /// <inheritdoc />
        public bool Equals(GraphName other)
        {
            return string.Equals(Value, other?.Value, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is GraphName other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Value);
        }

        public static bool operator ==(GraphName left, GraphName right)
        {
            return left?.Equals(right) ?? false;
        }

        public static bool operator !=(GraphName left, GraphName right)
        {
            return !left?.Equals(right) ?? false;
        }
    }
}