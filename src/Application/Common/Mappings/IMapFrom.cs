// Copyright (c) 2023 Vladyslav Potapenko. All Rights Reserved.

using AutoMapper;

namespace RestVladiola.Application.Common.Mappings;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}