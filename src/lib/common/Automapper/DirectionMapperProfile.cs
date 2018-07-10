﻿namespace FourZoas.RPG.Common.Automapper
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;

    public class DirectionMapperProfile : Profile
    {
        public DirectionMapperProfile()
        {
            CreateMap<Direction, Directions>();
            CreateMap<Directions, Direction>();
        }
    }
}
