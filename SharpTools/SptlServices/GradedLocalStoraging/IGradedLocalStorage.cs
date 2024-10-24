﻿using System.Text.Json.Serialization.Metadata;

namespace SptlServices.GradedLocalStoraging;

public interface IGradedLocalStorage
{
    ILocalStorageEntry<T> GetEntry<T>(string subKey, int importance, JsonTypeInfo<T> serializer);
}