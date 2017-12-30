﻿// ------------------------------------------------------------------------------------------------------------------------
// SonezakiMasaki library project (https://github.com/ahlec/SonezakiMasaki/), a subproject of the Pokémon Kristall project.
// This library is available to the public under the MIT license.
// ------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections;
using SonezakiMasaki.IO;

namespace SonezakiMasaki.SerializableValues
{
    internal sealed class ArrayValue : ISerializableValue
    {
        readonly TypeManager _typeManager;
        readonly Type _elementType;
        readonly int _rank;
        readonly IList _array;
        readonly int _arrayLength;

        ArrayValue( TypeManager typeManager, Type arrayType, IList array, int arrayLength )
        {
            _typeManager = typeManager;
            _elementType = arrayType.GetElementType();
            _rank = arrayType.GetArrayRank();
            _array = array;
            _arrayLength = arrayLength;
        }

        public object Value => _array;

        public static ArrayValue Instantiate( TypeManager typeManager, Type fullType, SonezakiReader reader )
        {
            int arrayLength = reader.ReadInt32();
            IList array = (IList) Activator.CreateInstance( fullType, arrayLength );
            return new ArrayValue( typeManager, fullType, array, arrayLength );
        }

        public static ArrayValue WrapRawValue( TypeManager typeManager, object value )
        {
            IList array = (IList) value;
            return new ArrayValue( typeManager, value.GetType(), array, array.Count );
        }

        public void Read( SonezakiReader reader )
        {
            if ( _rank == 1 )
            {
                ReadIntoArray( reader, _array );
                return;
            }

            throw new NotImplementedException();
        }

        public void Write( SonezakiWriter writer )
        {
            writer.Write( _arrayLength );

            for ( int rank = 0; rank < _rank; ++rank )
            {
                for ( int index = 0; index < _arrayLength; ++index )
                {
                    ISerializableValue itemSerializableValue = _typeManager.WrapRawValue( _elementType, _array[index] );
                    itemSerializableValue.Write( writer );
                }
            }
        }

        void ReadIntoArray( SonezakiReader reader, IList destination )
        {
            for ( int index = 0; index < _arrayLength; ++index )
            {
                ISerializableValue itemSerializableValue = _typeManager.Instantiate( _elementType, reader );
                itemSerializableValue.Read( reader );
                destination[index] = itemSerializableValue.Value;
            }
        }
    }
}