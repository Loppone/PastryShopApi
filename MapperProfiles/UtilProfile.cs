using AutoMapper;
using System;

namespace PastryShopApi.MapperProfiles
{
    public class UtilProfile : Profile
    {
        public UtilProfile()
        {
            CreateMap<DateTime, long>().ConvertUsing<DateTimeToEpochTimeConverter>();
        }

        private class DateTimeToEpochTimeConverter : ITypeConverter<DateTime, long>
        {
            public long Convert(DateTime source, long destination, ResolutionContext context)
            {
                DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                TimeSpan diff = source.ToUniversalTime() - origin.ToUniversalTime();

                return (long)Math.Floor(diff.TotalMilliseconds);
            }
        }

        public class ResolveDateNullable : ITypeConverter<DateTime?, DateTime>
        {
            public DateTime Convert(DateTime? source, DateTime destination, ResolutionContext context)
            {
                return source.HasValue ? source.Value : new DateTime(1900, 1, 1);
            }
        }
    }
}