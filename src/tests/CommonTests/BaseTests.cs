namespace CommonTests
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using FourZoas.RPG.Common.Automapper;

    public class BaseTests
    {
        static BaseTests() => Mapper.Initialize(cfg => cfg.AddProfile<DirectionMapperProfile>());
    }
}
