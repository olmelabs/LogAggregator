using System;
using AutoMapper;
using MongoDB.Bson;
using OlmeLabs.LogAggregator.Models;

namespace OlmeLabs.LogAggregator
{
    public class AutomapperConfig
    {
        public static void RegisterMappings()
        {

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<NewLogEntry, LogEntry>()
                    .ForMember(d => d.Id, opt => opt.Ignore())
                    .ForMember(d => d.StoreDate, opt => opt.MapFrom(src => DateTime.Now));

                cfg.CreateMap<SearchOptionsModel, SearchOptions>();

                cfg.CreateMap<LogEntry, BsonLogEntry>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(src => ObjectId.Parse(src.Id)));

                cfg.CreateMap<BsonLogEntry, LogEntry>()
                    .ForMember(d => d.Id, opt => opt.MapFrom(src => src.Id.ToString()));

                //.ForMember(d => d.Env, opt => opt.MapFrom(src => src.Env))
                //.ForMember(d => d.Sys, opt => opt.MapFrom(src => src.Sys))
                //.ForMember(d => d.StoreDate, opt => opt.MapFrom(src => src.StoreDate))
                //.ForMember(d => d.Content, opt => opt.MapFrom(src => src.Content));
            });
        }
    }
}