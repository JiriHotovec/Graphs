using System;
using Czu.Graphs.Core.Exceptions;

namespace Czu.Graphs.Core
{
    /// <summary>
    /// Immutable value object that represents graph's vertex
    /// </summary>
    public sealed class Vertex : IEquatable<Vertex>
    {
        /// <summary>
        /// Max. limit of name length
        /// </summary>
        public const int NameMaxLength = 255;

        /// <summary>
        /// Parametrized ctor
        /// </summary>
        /// <param name="name">Vertex name</param>
        /// <exception cref="ModelException">Custom exception for model validation</exception>
        public Vertex(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ModelException("Vertex name cannot be empty");
            }

            if (name.Length > NameMaxLength)
            {
                throw new ModelException($"Vertex name length must be equal or less than {NameMaxLength} chars");
            }

            Name = name;
        }

        /// <summary>
        /// Vertex name
        /// </summary>
        public string Name { get; }

        /// <inheritdoc />
        public override string ToString() => Name;

        public static implicit operator string(Vertex vertex)
        {
            return vertex.Name;
        }

        /// <inheritdoc />
        public bool Equals(Vertex other)
        {
            return string.Equals(Name, other?.Name, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            return obj is Vertex other && Equals(other);
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return StringComparer.OrdinalIgnoreCase.GetHashCode(Name);
        }

        public static bool operator ==(Vertex left, Vertex right)
        {
            return left?.Equals(right) ?? false;
        }

        public static bool operator !=(Vertex left, Vertex right)
        {
            return !left?.Equals(right) ?? false;
        }
    }
}