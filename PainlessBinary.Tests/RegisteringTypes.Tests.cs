﻿// ------------------------------------------------------------------------------------------------------------------------
// PainlessBinary library project (https://github.com/ahlec/PainlessBinary/), a subproject of the Pokémon Kristall project.
// This library is available to the public under the MIT license.
// ------------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using NUnit.Framework;
using PainlessBinary.Exceptions;

namespace PainlessBinary.Tests
{
    [TestFixture]
    public sealed class RegisteringTypesTests : UnitTestBase
    {
        [Test]
        public void RegisteringTypes_CannotRegisterInterface()
        {
            TypeRegistry typeRegistry = new TypeRegistry();
            Assert.Throws<TypeCannotBeRegisteredException>( () => typeRegistry.RegisterType( typeof( IList<int> ) ) );
        }

        [Test]
        public void RegisteringTypes_CannotRegisterWithoutDataTypeAttribute()
        {
            TypeRegistry typeRegistry = new TypeRegistry();
            Assert.Throws<TypeMissingMarkupException>( () => typeRegistry.RegisterType( typeof( RegisteringTypesTests ) ) );
        }
    }
}
