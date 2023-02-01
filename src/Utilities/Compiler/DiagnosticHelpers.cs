// Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the MIT license.  See License.txt in the project root for license information.

using System;
using Microsoft.CodeAnalysis;

namespace Analyzer.Utilities
{
    internal static partial class DiagnosticHelpers
    {
        public static bool TryConvertToUInt64(object? value, SpecialType specialType, out ulong convertedValue)
        {
            bool success = false;
            convertedValue = 0;
            if (value != null)
            {
                switch (specialType)
                {
                    case SpecialType.System_Int16:
                        convertedValue = unchecked((ulong)(short)value);
                        success = true;
                        break;
                    case SpecialType.System_Int32:
                        convertedValue = unchecked((ulong)(int)value);
                        success = true;
                        break;
                    case SpecialType.System_Int64:
                        convertedValue = unchecked((ulong)(long)value);
                        success = true;
                        break;
                    case SpecialType.System_UInt16:
                        convertedValue = (ushort)value;
                        success = true;
                        break;
                    case SpecialType.System_UInt32:
                        convertedValue = (uint)value;
                        success = true;
                        break;
                    case SpecialType.System_UInt64:
                        convertedValue = (ulong)value;
                        success = true;
                        break;
                    case SpecialType.System_Byte:
                        convertedValue = (byte)value;
                        success = true;
                        break;
                    case SpecialType.System_SByte:
                        convertedValue = unchecked((ulong)(sbyte)value);
                        success = true;
                        break;
                    case SpecialType.System_Char:
                        convertedValue = (char)value;
                        success = true;
                        break;
                    case SpecialType.System_Boolean:
                        convertedValue = (ulong)((bool)value ? 1 : 0);
                        success = true;
                        break;
                }
            }

            return success;
        }

        public static string GetMemberName(ISymbol symbol)
        {
            // For Types
            if (symbol is INamedTypeSymbol namedType &&
                namedType.IsGenericType)
            {
                return symbol.MetadataName;
            }

            // For other language constructs
            return symbol.Name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sourceType"></param>
        /// <param name="targetType"></param>
        /// <returns></returns>
        public static object? UnboxAndConvert(object? value, SpecialType sourceType, SpecialType targetType)
        {

            switch (targetType)
            {

                case SpecialType.System_Byte:
                    return UnboxAndConvertToByte(value, sourceType);
                case SpecialType.System_Double:
                    return UnboxAndConvertToDouble(value, sourceType);
                case SpecialType.System_Int16:
                    return UnboxAndConvertToInt16(value, sourceType);
                case SpecialType.System_Int32:
                    return UnboxAndConvertToInt32(value, sourceType);
                case SpecialType.System_Int64:
                    return UnboxAndConvertToInt64(value, sourceType);
                case SpecialType.System_UInt16:
                    return UnboxAndConvertToUInt16(value, sourceType);
                case SpecialType.System_UInt32:
                    return UnboxAndConvertToUInt32(value, sourceType);
                case SpecialType.System_UInt64:
                    return UnboxAndConvertToUInt64(value, sourceType);
                case SpecialType.System_SByte:
                    return UnboxAndConvertToSByte(value, sourceType);
                case SpecialType.System_Single:
                    return UnboxAndConvertToSingle(value, sourceType);
                default: return value;
            }

        }

        public static byte? UnboxAndConvertToByte(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (byte?)(double?)value;
                case SpecialType.System_Int16:
                    return (byte?)(short?)value;
                case SpecialType.System_Int32:
                    return (byte?)(int?)value;
                case SpecialType.System_Int64:
                    return (byte?)(long?)value;
                case SpecialType.System_UInt16:
                    return (byte?)(ushort?)value;
                case SpecialType.System_UInt32:
                    return (byte?)(uint?)value;
                case SpecialType.System_UInt64:
                    return (byte?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (byte?)(sbyte?)value;
                case SpecialType.System_Single:
                    return (byte?)(float?)value;
                default: return null;
            }
        }
        public static double? UnboxAndConvertToDouble(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (double?)value;
                case SpecialType.System_Int16:
                    return (short?)value;
                case SpecialType.System_Int32:
                    return (int?)value;
                case SpecialType.System_Int64:
                    return (long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (uint?)value;
                case SpecialType.System_UInt64:
                    return (ulong?)value;
                case SpecialType.System_SByte:
                    return (sbyte?)value;
                case SpecialType.System_Single:
                    return (float?)value;
                default: return null;
            }
        }

        public static short? UnboxAndConvertToInt16(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (short?)(double?)value;
                case SpecialType.System_Int16:
                    return (short?)value;
                case SpecialType.System_Int32:
                    return (short?)(int?)value;
                case SpecialType.System_Int64:
                    return (short?)(long?)value;
                case SpecialType.System_UInt16:
                    return (short?)(ushort?)value;
                case SpecialType.System_UInt32:
                    return (short?)(uint?)value;
                case SpecialType.System_UInt64:
                    return (short?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (sbyte?)value;
                case SpecialType.System_Single:
                    return (short?)(float?)value;
                default: return null;
            }
        }

        public static int? UnboxAndConvertToInt32(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (int?)(double?)value;
                case SpecialType.System_Int16:
                    return (short?)value;
                case SpecialType.System_Int32:
                    return (int?)value;
                case SpecialType.System_Int64:
                    return (int?)(long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (int?)(uint?)value;
                case SpecialType.System_UInt64:
                    return (int?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (sbyte?)value;
                case SpecialType.System_Single:
                    return (int?)(float?)value;
                default: return null;
            }
        }

        public static long? UnboxAndConvertToInt64(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (long?)(double?)value;
                case SpecialType.System_Int16:
                    return (short?)value;
                case SpecialType.System_Int32:
                    return (int?)value;
                case SpecialType.System_Int64:
                    return (long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (uint?)value;
                case SpecialType.System_UInt64:
                    return (long?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (sbyte?)value;
                case SpecialType.System_Single:
                    return (long?)(float?)value;
                default: return null;
            }
        }
        public static ushort? UnboxAndConvertToLong(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (ushort?)(double?)value;
                case SpecialType.System_Int16:
                    return (ushort?)(short?)value;
                case SpecialType.System_Int32:
                    return (ushort?)(int?)value;
                case SpecialType.System_Int64:
                    return (ushort?)(long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (ushort?)(uint?)value;
                case SpecialType.System_UInt64:
                    return (ushort?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (ushort?)(sbyte?)value;
                case SpecialType.System_Single:
                    return (ushort?)(float?)value;
                default: return null;
            }
        }

        public static uint? UnboxAndConvertToUInt32(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (uint?)(double?)value;
                case SpecialType.System_Int16:
                    return (uint?)(short?)value;
                case SpecialType.System_Int32:
                    return (uint?)(int?)value;
                case SpecialType.System_Int64:
                    return (uint?)(long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (uint?)value;
                case SpecialType.System_UInt64:
                    return (uint?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (uint?)(sbyte?)value;
                case SpecialType.System_Single:
                    return (uint?)(float?)value;
                default: return null;
            }
        }

        public static ushort? UnboxAndConvertToUInt16(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (ushort?)(double?)value;
                case SpecialType.System_Int16:
                    return (ushort?)(short?)value;
                case SpecialType.System_Int32:
                    return (ushort?)(int?)value;
                case SpecialType.System_Int64:
                    return (ushort?)(long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (ushort?)(uint?)value;
                case SpecialType.System_UInt64:
                    return (ushort?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (ushort?)(sbyte?)value;
                case SpecialType.System_Single:
                    return (ushort?)(float?)value;
                default: return null;
            }
        }

        public static ulong? UnboxAndConvertToUInt64(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (ulong?)(double?)value;
                case SpecialType.System_Int16:
                    return (ulong?)(short?)value;
                case SpecialType.System_Int32:
                    return (ulong?)(int?)value;
                case SpecialType.System_Int64:
                    return (ulong?)(long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (uint?)value;
                case SpecialType.System_UInt64:
                    return (ulong?)value;
                case SpecialType.System_SByte:
                    return (ulong?)(sbyte?)value;
                case SpecialType.System_Single:
                    return (ulong?)(float?)value;
                default: return null;
            }
        }

        public static sbyte? UnboxAndConvertToSByte(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (sbyte?)(byte?)value;
                case SpecialType.System_Double:
                    return (sbyte?)(double?)value;
                case SpecialType.System_Int16:
                    return (sbyte?)(short?)value;
                case SpecialType.System_Int32:
                    return (sbyte?)(int?)value;
                case SpecialType.System_Int64:
                    return (sbyte?)(long?)value;
                case SpecialType.System_UInt16:
                    return (sbyte?)(ushort?)value;
                case SpecialType.System_UInt32:
                    return (sbyte?)(uint?)value;
                case SpecialType.System_UInt64:
                    return (sbyte?)(ulong?)value;
                case SpecialType.System_SByte:
                    return (sbyte?)value;
                case SpecialType.System_Single:
                    return (sbyte?)(float?)value;
                default: return null;
            }
        }

        public static float? UnboxAndConvertToSingle(object? value, SpecialType sourceType)
        {
            switch (sourceType)
            {

                case SpecialType.System_Byte:
                    return (byte?)value;
                case SpecialType.System_Double:
                    return (float?)(double?)value;
                case SpecialType.System_Int16:
                    return (short?)value;
                case SpecialType.System_Int32:
                    return (int?)value;
                case SpecialType.System_Int64:
                    return (long?)value;
                case SpecialType.System_UInt16:
                    return (ushort?)value;
                case SpecialType.System_UInt32:
                    return (uint?)value;
                case SpecialType.System_UInt64:
                    return (ulong?)value;
                case SpecialType.System_SByte:
                    return (sbyte?)value;
                case SpecialType.System_Single:
                    return (float?)value;
                default: return null;
            }
        }
    }
}