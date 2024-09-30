using CARculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CARculator.DynamicServices
{
    public class DynamicClassGenerator
    {
        public Type CreateCarClass(string className)
        {
            var assemblyName = new AssemblyName("DynamicCarAssembly");
            var assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            var moduleBuilder = assemblyBuilder.DefineDynamicModule("MainModule");
            var typeBuilder = moduleBuilder.DefineType(className, TypeAttributes.Public);

            // Define fields and properties
            DefineProperty(typeBuilder, "Brand", typeof(string));
            DefineProperty(typeBuilder, "Model", typeof(string));
            DefineProperty(typeBuilder, "Generation", typeof(string));
            DefineProperty(typeBuilder, "ProductionYear", typeof(string));
            DefineProperty(typeBuilder, "Mileage", typeof(int));
            DefineProperty(typeBuilder, "AveragePrice", typeof(decimal));
            DefineProperty(typeBuilder, "FuelType", typeof(FuelType));
            DefineProperty(typeBuilder, "Transmissions", typeof(List<TransmissionType>));
            DefineProperty(typeBuilder, "Engines", typeof(List<Engine>));

            // Create the class
            return typeBuilder.CreateType();
        }

        private void DefineProperty(TypeBuilder typeBuilder, string propertyName, Type propertyType)
        {
            var fieldBuilder = typeBuilder.DefineField($"_{propertyName.ToLower()}", propertyType, FieldAttributes.Private);
            var propertyBuilder = typeBuilder.DefineProperty(propertyName, PropertyAttributes.HasDefault, propertyType, Type.EmptyTypes);

            var getMethodBuilder = typeBuilder.DefineMethod($"get_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, propertyType, Type.EmptyTypes);
            var getILGenerator = getMethodBuilder.GetILGenerator();
            getILGenerator.Emit(OpCodes.Ldarg_0);
            getILGenerator.Emit(OpCodes.Ldfld, fieldBuilder);
            getILGenerator.Emit(OpCodes.Ret);

            var setMethodBuilder = typeBuilder.DefineMethod($"set_{propertyName}", MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig, null, new[] { propertyType });
            var setILGenerator = setMethodBuilder.GetILGenerator();
            setILGenerator.Emit(OpCodes.Ldarg_0);
            setILGenerator.Emit(OpCodes.Ldarg_1);
            setILGenerator.Emit(OpCodes.Stfld, fieldBuilder);
            setILGenerator.Emit(OpCodes.Ret);

            propertyBuilder.SetGetMethod(getMethodBuilder);
            propertyBuilder.SetSetMethod(setMethodBuilder);
        }


    }
}
