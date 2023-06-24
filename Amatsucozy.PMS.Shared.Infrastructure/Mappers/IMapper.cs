namespace Amatsucozy.PMS.Shared.Infrastructure.Mappers;

public interface IMapper<T1, T2>
    where T1 : class
    where T2 : class
{
    T2 Map(T1 model);

    void Map(T1 model1, T2 model2);

    T1 Map(T2 model);

    void Map(T2 model2, T1 model1);
}
