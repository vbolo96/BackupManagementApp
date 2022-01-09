using AutoMapper;
using BackupManagementApp.Dtos;
using BackupManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BackupManagementApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tape, TapeDto>();
            CreateMap<TapeDto, Tape>();

            CreateMap<BackupSystem, BackupSystemDto>();
            CreateMap<BackupSystemDto, BackupSystem>();
            CreateMap<BackupTypes, BackupTypesDto>();
            CreateMap<BackupTypesDto, BackupTypes>();
        }

    }
}