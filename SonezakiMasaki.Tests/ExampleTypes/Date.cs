﻿// ------------------------------------------------------------------------------------------------------------------------
// SonezakiMasaki library project (https://github.com/ahlec/SonezakiMasaki/), a subproject of the Pokémon Kristall project.
// This library is available to the public under the MIT license.
// ------------------------------------------------------------------------------------------------------------------------

using SonezakiMasaki.Markup;

namespace SonezakiMasaki.Tests.ExampleTypes
{
    [BinaryDataType]
    public sealed class Date
    {
        [BinaryMember( 1 )]
        public byte Day { get; set; }

        [BinaryMember( 2 )]
        public Month Month { get; set; }

        [BinaryMember( 3 )]
        public int Year { get; set; }
    }
}
