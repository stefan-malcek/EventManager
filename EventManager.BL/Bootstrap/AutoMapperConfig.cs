using AutoMapper;

namespace EventManager.BL.Bootstrap
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(i =>
            {
                //TODO insert mapping configuration
            });
        }
    }
}
