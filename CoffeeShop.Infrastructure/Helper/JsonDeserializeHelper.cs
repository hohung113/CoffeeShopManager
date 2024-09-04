﻿using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.Infrastructure.Helper
{
    public class JsonDeserializeHelper
    {
        public static string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = JsonUpperCaseContractResolver.Instance });
        }
    }

    public class JsonUpperCaseContractResolver : DefaultContractResolver
    {
        public static readonly JsonUpperCaseContractResolver Instance = new JsonUpperCaseContractResolver();

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            property.PropertyName = property.PropertyName?.ToUpperInvariant();
            return property;
        }
    }
}
