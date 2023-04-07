using System;
using System.Collections.Generic;
using Czu.OrientedGraph.Core.Exceptions;

namespace Czu.OrientedGraph.Core
{
    public sealed class Weight : IEquatable<Weight>, IComparable<Weight>, IComparable
    {
        public const int WeightMin = 0;
        public const int WeightMax = 1000;

        public Weight(int value = WeightMin)
        {
            if (value < WeightMin || value > WeightMax)
            {
                throw new ModelException($"Weight must be in interval <{WeightMin}, {WeightMax}>");
            }

            Value = value;
        }

        public int Value { get; }

        public override string ToString() => $"{Value}";

        public static implicit operator int(Weight weight)
        {
            return weight.Value;
        }

        public bool Equals(Weight other)
        {
            return Value == other?.Value;
        }

        public override bool Equals(object obj)
        {
            return obj is Weight other && Equals(other);
        }

        public override int GetHashCode()
        {
            return Value;
        }

        public static bool operator ==(Weight left, Weight right)
        {
            return left?.Equals(right) ?? false;
        }

        public static bool operator !=(Weight left, Weight right)
        {
            return !left?.Equals(right) ?? false;
        }

        public int CompareTo(Weight other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Value.CompareTo(other.Value);
        }

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is Weight other ? CompareTo(other) : throw new ArgumentException($"Object must be of type {nameof(Weight)}");
        }

        public static bool operator <(Weight left, Weight right)
        {
            return Comparer<Weight>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Weight left, Weight right)
        {
            return Comparer<Weight>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Weight left, Weight right)
        {
            return Comparer<Weight>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Weight left, Weight right)
        {
            return Comparer<Weight>.Default.Compare(left, right) >= 0;
        }
    }
}