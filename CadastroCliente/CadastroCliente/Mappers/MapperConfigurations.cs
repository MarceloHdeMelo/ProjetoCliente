namespace CadastroCliente.Mappers
{
    public static class MapperConfigurations
    {
        private static bool _isMapped;

        public static void RegisterMappings()
        {
            if (_isMapped)
                return;

            _isMapped = true;

            AutoMapper.Mapper.Initialize(mapper =>
            {
                mapper.AddProfile<ModelToEntityMapper>();
            });
        }
    }
}