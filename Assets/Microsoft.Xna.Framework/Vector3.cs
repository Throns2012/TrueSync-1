using System;
using System.Text;
using TrueSync;

namespace Microsoft.Xna.Framework
{
	public struct Vector3 : IEquatable<Vector3>
	{
		private static Vector3 zero = new Vector3(0f, 0f, 0f);

		private static Vector3 one = new Vector3(1f, 1f, 1f);

		private static Vector3 unitX = new Vector3(1f, 0f, 0f);

		private static Vector3 unitY = new Vector3(0f, 1f, 0f);

		private static Vector3 unitZ = new Vector3(0f, 0f, 1f);

		private static Vector3 up = new Vector3(0f, 1f, 0f);

		private static Vector3 down = new Vector3(0f, -1f, 0f);

		private static Vector3 right = new Vector3(1f, 0f, 0f);

		private static Vector3 left = new Vector3(-1f, 0f, 0f);

		private static Vector3 forward = new Vector3(0f, 0f, -1f);

		private static Vector3 backward = new Vector3(0f, 0f, 1f);

		public FP X;

		public FP Y;

		public FP Z;

		public static Vector3 Zero
		{
			get
			{
				return Vector3.zero;
			}
		}

		public static Vector3 One
		{
			get
			{
				return Vector3.one;
			}
		}

		public static Vector3 UnitX
		{
			get
			{
				return Vector3.unitX;
			}
		}

		public static Vector3 UnitY
		{
			get
			{
				return Vector3.unitY;
			}
		}

		public static Vector3 UnitZ
		{
			get
			{
				return Vector3.unitZ;
			}
		}

		public static Vector3 Up
		{
			get
			{
				return Vector3.up;
			}
		}

		public static Vector3 Down
		{
			get
			{
				return Vector3.down;
			}
		}

		public static Vector3 Right
		{
			get
			{
				return Vector3.right;
			}
		}

		public static Vector3 Left
		{
			get
			{
				return Vector3.left;
			}
		}

		public static Vector3 Forward
		{
			get
			{
				return Vector3.forward;
			}
		}

		public static Vector3 Backward
		{
			get
			{
				return Vector3.backward;
			}
		}

		public Vector3(FP x, FP y, FP z)
		{
			this.X = x;
			this.Y = y;
			this.Z = z;
		}

		public Vector3(FP value)
		{
			this.X = value;
			this.Y = value;
			this.Z = value;
		}

		public Vector3(TSVector2 value, FP z)
		{
			this.X = value.x;
			this.Y = value.y;
			this.Z = z;
		}

		public static Vector3 Add(Vector3 value1, Vector3 value2)
		{
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static void Add(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X + value2.X;
			result.Y = value1.Y + value2.Y;
			result.Z = value1.Z + value2.Z;
		}

		public static Vector3 Barycentric(Vector3 value1, Vector3 value2, Vector3 value3, FP amount1, FP amount2)
		{
			return new Vector3(MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2), MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2), MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
		}

		public static void Barycentric(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, FP amount1, FP amount2, out Vector3 result)
		{
			result = new Vector3(MathHelper.Barycentric(value1.X, value2.X, value3.X, amount1, amount2), MathHelper.Barycentric(value1.Y, value2.Y, value3.Y, amount1, amount2), MathHelper.Barycentric(value1.Z, value2.Z, value3.Z, amount1, amount2));
		}

		public static Vector3 CatmullRom(Vector3 value1, Vector3 value2, Vector3 value3, Vector3 value4, FP amount)
		{
			return new Vector3(MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount), MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount), MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
		}

		public static void CatmullRom(ref Vector3 value1, ref Vector3 value2, ref Vector3 value3, ref Vector3 value4, FP amount, out Vector3 result)
		{
			result = new Vector3(MathHelper.CatmullRom(value1.X, value2.X, value3.X, value4.X, amount), MathHelper.CatmullRom(value1.Y, value2.Y, value3.Y, value4.Y, amount), MathHelper.CatmullRom(value1.Z, value2.Z, value3.Z, value4.Z, amount));
		}

		public static Vector3 Clamp(Vector3 value1, Vector3 min, Vector3 max)
		{
			return new Vector3(MathHelper.Clamp(value1.X, min.X, max.X), MathHelper.Clamp(value1.Y, min.Y, max.Y), MathHelper.Clamp(value1.Z, min.Z, max.Z));
		}

		public static void Clamp(ref Vector3 value1, ref Vector3 min, ref Vector3 max, out Vector3 result)
		{
			result = new Vector3(MathHelper.Clamp(value1.X, min.X, max.X), MathHelper.Clamp(value1.Y, min.Y, max.Y), MathHelper.Clamp(value1.Z, min.Z, max.Z));
		}

		public static Vector3 Cross(Vector3 vector1, Vector3 vector2)
		{
			Vector3.Cross(ref vector1, ref vector2, out vector1);
			return vector1;
		}

		public static void Cross(ref Vector3 vector1, ref Vector3 vector2, out Vector3 result)
		{
			result = new Vector3(vector1.Y * vector2.Z - vector2.Y * vector1.Z, -(vector1.X * vector2.Z - vector2.X * vector1.Z), vector1.X * vector2.Y - vector2.X * vector1.Y);
		}

		public static FP Distance(Vector3 vector1, Vector3 vector2)
		{
			FP x;
			Vector3.DistanceSquared(ref vector1, ref vector2, out x);
			return FP.Sqrt(x);
		}

		public static void Distance(ref Vector3 value1, ref Vector3 value2, out FP result)
		{
			Vector3.DistanceSquared(ref value1, ref value2, out result);
			result = FP.Sqrt(result);
		}

		public static FP DistanceSquared(Vector3 value1, Vector3 value2)
		{
			FP result;
			Vector3.DistanceSquared(ref value1, ref value2, out result);
			return result;
		}

		public static void DistanceSquared(ref Vector3 value1, ref Vector3 value2, out FP result)
		{
			result = (value1.X - value2.X) * (value1.X - value2.X) + (value1.Y - value2.Y) * (value1.Y - value2.Y) + (value1.Z - value2.Z) * (value1.Z - value2.Z);
		}

		public static Vector3 Divide(Vector3 value1, Vector3 value2)
		{
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector3 Divide(Vector3 value1, FP value2)
		{
			FP y = 1 / value2;
			value1.X *= y;
			value1.Y *= y;
			value1.Z *= y;
			return value1;
		}

		public static void Divide(ref Vector3 value1, FP divisor, out Vector3 result)
		{
			FP y = 1 / divisor;
			result.X = value1.X * y;
			result.Y = value1.Y * y;
			result.Z = value1.Z * y;
		}

		public static void Divide(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X / value2.X;
			result.Y = value1.Y / value2.Y;
			result.Z = value1.Z / value2.Z;
		}

		public static FP Dot(Vector3 vector1, Vector3 vector2)
		{
			return vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
		}

		public static void Dot(ref Vector3 vector1, ref Vector3 vector2, out FP result)
		{
			result = vector1.X * vector2.X + vector1.Y * vector2.Y + vector1.Z * vector2.Z;
		}

		public override bool Equals(object obj)
		{
			return obj is Vector3 && this == (Vector3)obj;
		}

		public bool Equals(Vector3 other)
		{
			return this == other;
		}

		public override int GetHashCode()
		{
			return (int)((long)(this.X + this.Y + this.Z));
		}

		public static Vector3 Hermite(Vector3 value1, Vector3 tangent1, Vector3 value2, Vector3 tangent2, FP amount)
		{
			Vector3 result = default(Vector3);
			Vector3.Hermite(ref value1, ref tangent1, ref value2, ref tangent2, amount, out result);
			return result;
		}

		public static void Hermite(ref Vector3 value1, ref Vector3 tangent1, ref Vector3 value2, ref Vector3 tangent2, FP amount, out Vector3 result)
		{
			result.X = MathHelper.Hermite(value1.X, tangent1.X, value2.X, tangent2.X, amount);
			result.Y = MathHelper.Hermite(value1.Y, tangent1.Y, value2.Y, tangent2.Y, amount);
			result.Z = MathHelper.Hermite(value1.Z, tangent1.Z, value2.Z, tangent2.Z, amount);
		}

		public FP Length()
		{
			FP x;
			Vector3.DistanceSquared(ref this, ref Vector3.zero, out x);
			return FP.Sqrt(x);
		}

		public FP LengthSquared()
		{
			FP result;
			Vector3.DistanceSquared(ref this, ref Vector3.zero, out result);
			return result;
		}

		public static Vector3 Lerp(Vector3 value1, Vector3 value2, FP amount)
		{
			return new Vector3(MathHelper.Lerp(value1.X, value2.X, amount), MathHelper.Lerp(value1.Y, value2.Y, amount), MathHelper.Lerp(value1.Z, value2.Z, amount));
		}

		public static void Lerp(ref Vector3 value1, ref Vector3 value2, FP amount, out Vector3 result)
		{
			result = new Vector3(MathHelper.Lerp(value1.X, value2.X, amount), MathHelper.Lerp(value1.Y, value2.Y, amount), MathHelper.Lerp(value1.Z, value2.Z, amount));
		}

		public static Vector3 Max(Vector3 value1, Vector3 value2)
		{
			return new Vector3(MathHelper.Max(value1.X, value2.X), MathHelper.Max(value1.Y, value2.Y), MathHelper.Max(value1.Z, value2.Z));
		}

		public static void Max(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result = new Vector3(MathHelper.Max(value1.X, value2.X), MathHelper.Max(value1.Y, value2.Y), MathHelper.Max(value1.Z, value2.Z));
		}

		public static Vector3 Min(Vector3 value1, Vector3 value2)
		{
			return new Vector3(MathHelper.Min(value1.X, value2.X), MathHelper.Min(value1.Y, value2.Y), MathHelper.Min(value1.Z, value2.Z));
		}

		public static void Min(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result = new Vector3(MathHelper.Min(value1.X, value2.X), MathHelper.Min(value1.Y, value2.Y), MathHelper.Min(value1.Z, value2.Z));
		}

		public static Vector3 Multiply(Vector3 value1, Vector3 value2)
		{
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector3 Multiply(Vector3 value1, FP scaleFactor)
		{
			value1.X *= scaleFactor;
			value1.Y *= scaleFactor;
			value1.Z *= scaleFactor;
			return value1;
		}

		public static void Multiply(ref Vector3 value1, FP scaleFactor, out Vector3 result)
		{
			result.X = value1.X * scaleFactor;
			result.Y = value1.Y * scaleFactor;
			result.Z = value1.Z * scaleFactor;
		}

		public static void Multiply(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X * value2.X;
			result.Y = value1.Y * value2.Y;
			result.Z = value1.Z * value2.Z;
		}

		public static Vector3 Negate(Vector3 value)
		{
			value = new Vector3(-value.X, -value.Y, -value.Z);
			return value;
		}

		public static void Negate(ref Vector3 value, out Vector3 result)
		{
			result = new Vector3(-value.X, -value.Y, -value.Z);
		}

		public void Normalize()
		{
			Vector3.Normalize(ref this, out this);
		}

		public static Vector3 Normalize(Vector3 vector)
		{
			Vector3.Normalize(ref vector, out vector);
			return vector;
		}

		public static void Normalize(ref Vector3 value, out Vector3 result)
		{
			FP y;
			Vector3.Distance(ref value, ref Vector3.zero, out y);
			y = 1f / y;
			result.X = value.X * y;
			result.Y = value.Y * y;
			result.Z = value.Z * y;
		}

		public static Vector3 Reflect(Vector3 vector, Vector3 normal)
		{
			Vector3 result;
			Vector3.Reflect(ref vector, ref normal, out result);
			return result;
		}

		public static void Reflect(ref Vector3 vector, ref Vector3 normal, out Vector3 result)
		{
			FP y = Vector3.Dot(vector, normal);
			result.X = vector.X - 2f * y * normal.X;
			result.Y = vector.Y - 2f * y * normal.Y;
			result.Z = vector.Z - 2f * y * normal.Z;
		}

		public static Vector3 SmoothStep(Vector3 value1, Vector3 value2, FP amount)
		{
			return new Vector3(MathHelper.SmoothStep(value1.X, value2.X, amount), MathHelper.SmoothStep(value1.Y, value2.Y, amount), MathHelper.SmoothStep(value1.Z, value2.Z, amount));
		}

		public static void SmoothStep(ref Vector3 value1, ref Vector3 value2, FP amount, out Vector3 result)
		{
			result = new Vector3(MathHelper.SmoothStep(value1.X, value2.X, amount), MathHelper.SmoothStep(value1.Y, value2.Y, amount), MathHelper.SmoothStep(value1.Z, value2.Z, amount));
		}

		public static Vector3 Subtract(Vector3 value1, Vector3 value2)
		{
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static void Subtract(ref Vector3 value1, ref Vector3 value2, out Vector3 result)
		{
			result.X = value1.X - value2.X;
			result.Y = value1.Y - value2.Y;
			result.Z = value1.Z - value2.Z;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder(32);
			stringBuilder.Append("{X:");
			stringBuilder.Append(this.X);
			stringBuilder.Append(" Y:");
			stringBuilder.Append(this.Y);
			stringBuilder.Append(" Z:");
			stringBuilder.Append(this.Z);
			stringBuilder.Append("}");
			return stringBuilder.ToString();
		}

		public static Vector3 Transform(Vector3 position, Matrix matrix)
		{
			Vector3.Transform(ref position, ref matrix, out position);
			return position;
		}

		public static void Transform(ref Vector3 position, ref Matrix matrix, out Vector3 result)
		{
			result = new Vector3(position.X * matrix.M11 + position.Y * matrix.M21 + position.Z * matrix.M31 + matrix.M41, position.X * matrix.M12 + position.Y * matrix.M22 + position.Z * matrix.M32 + matrix.M42, position.X * matrix.M13 + position.Y * matrix.M23 + position.Z * matrix.M33 + matrix.M43);
		}

		public static void Transform(Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
		{
			throw new NotImplementedException();
		}

		public static void Transform(Vector3[] sourceArray, int sourceIndex, ref Matrix matrix, Vector3[] destinationArray, int destinationIndex, int length)
		{
			throw new NotImplementedException();
		}

		public static void TransformNormal(Vector3[] sourceArray, ref Matrix matrix, Vector3[] destinationArray)
		{
			throw new NotImplementedException();
		}

		public static void TransformNormal(Vector3[] sourceArray, int sourceIndex, ref Matrix matrix, Vector3[] destinationArray, int destinationIndex, int length)
		{
			throw new NotImplementedException();
		}

		public static Vector3 TransformNormal(Vector3 normal, Matrix matrix)
		{
			Vector3.TransformNormal(ref normal, ref matrix, out normal);
			return normal;
		}

		public static void TransformNormal(ref Vector3 normal, ref Matrix matrix, out Vector3 result)
		{
			result = new Vector3(normal.X * matrix.M11 + normal.Y * matrix.M21 + normal.Z * matrix.M31, normal.X * matrix.M12 + normal.Y * matrix.M22 + normal.Z * matrix.M32, normal.X * matrix.M13 + normal.Y * matrix.M23 + normal.Z * matrix.M33);
		}

		public static bool operator ==(Vector3 value1, Vector3 value2)
		{
			return value1.X == value2.X && value1.Y == value2.Y && value1.Z == value2.Z;
		}

		public static bool operator !=(Vector3 value1, Vector3 value2)
		{
			return !(value1 == value2);
		}

		public static Vector3 operator +(Vector3 value1, Vector3 value2)
		{
			value1.X += value2.X;
			value1.Y += value2.Y;
			value1.Z += value2.Z;
			return value1;
		}

		public static Vector3 operator -(Vector3 value)
		{
			value = new Vector3(-value.X, -value.Y, -value.Z);
			return value;
		}

		public static Vector3 operator -(Vector3 value1, Vector3 value2)
		{
			value1.X -= value2.X;
			value1.Y -= value2.Y;
			value1.Z -= value2.Z;
			return value1;
		}

		public static Vector3 operator *(Vector3 value1, Vector3 value2)
		{
			value1.X *= value2.X;
			value1.Y *= value2.Y;
			value1.Z *= value2.Z;
			return value1;
		}

		public static Vector3 operator *(Vector3 value, FP scaleFactor)
		{
			value.X *= scaleFactor;
			value.Y *= scaleFactor;
			value.Z *= scaleFactor;
			return value;
		}

		public static Vector3 operator *(FP scaleFactor, Vector3 value)
		{
			value.X *= scaleFactor;
			value.Y *= scaleFactor;
			value.Z *= scaleFactor;
			return value;
		}

		public static Vector3 operator /(Vector3 value1, Vector3 value2)
		{
			value1.X /= value2.X;
			value1.Y /= value2.Y;
			value1.Z /= value2.Z;
			return value1;
		}

		public static Vector3 operator /(Vector3 value, FP divider)
		{
			FP y = 1 / divider;
			value.X *= y;
			value.Y *= y;
			value.Z *= y;
			return value;
		}
	}
}
