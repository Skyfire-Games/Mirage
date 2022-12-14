using NUnit.Framework;

namespace Mirage.Tests.Weaver
{
    public class SyncListTests : WeaverTestBase
    {
        [Test, BatchSafe(BatchType.Success)]
        public void SyncList()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListByteValid()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListGenericAbstractInheritance()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListGenericInheritance()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListGenericInheritanceWithMultipleGeneric()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListInheritance()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListNestedStruct()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListNestedInAbstractClass()
        {
            IsSuccess();
        }

        [Test]
        public void SyncListNestedInAbstractClassWithInvalid()
        {
            HasError("Cannot generate write function for Object. Use a supported type or provide a custom write function",
                "UnityEngine.Object");

            HasError("Cannot generate read function for Object. Use a supported type or provide a custom read function",
                "UnityEngine.Object");
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListNestedInStruct()
        {
            IsSuccess();
        }

        [Test]
        public void SyncListNestedInStructWithInvalid()
        {
            HasError("Cannot generate write function for Object. Use a supported type or provide a custom write function",
                "UnityEngine.Object");

            HasError("Cannot generate read function for Object. Use a supported type or provide a custom read function",
                "UnityEngine.Object");
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListStruct()
        {
            IsSuccess();
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListErrorForGenericStruct()
        {
            IsSuccess();
        }

        [Test]
        public void SyncListErrorForInterface()
        {
            HasError("Cannot generate read function for interface MyInterface. Use a supported type or provide a custom read function",
                "SyncListTests.SyncListErrorForInterface.MyInterface");
            HasError("Cannot generate write function for interface MyInterface. Use a supported type or provide a custom write function",
                "SyncListTests.SyncListErrorForInterface.MyInterface");
        }

        [Test, BatchSafe(BatchType.Success)]
        public void SyncListErrorWhenUsingGenericListInNetworkBehaviour()
        {
            IsSuccess();
        }
    }
}
