using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using Sirena.Helpers;

namespace Sirena.Tests
{
    [TestFixture()]
    public class FareremarkRequestTests
    {
        [Test]
        public void FareremarkRequest_DeserializeResponse_ShouldNotThrowException()
        {
            var data = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <sirena>
            <answer pult=""ТЕСТ01"">
            <fareremark>
            <remark new_fare=""true"">Сокращенный текст УПТ
            &lt;b&gt;Условия применения тарифа:&lt;/b&gt; &lt;i&gt;304.СУ.2000&lt;/i&gt;
            Применяется для тарифов с кодом базового тарифа &lt;i&gt;'Y'&lt;/i&gt;, примененного как &lt;i&gt;OW (one
            -way, однонаправленный)&lt;/i&gt;.
            Вид тарифа &lt;i&gt;'Н'-нормальный&lt;/i&gt;. Тип тарифа &lt;i&gt;'EU'-ЭКОНОМИЧЕСКИЙ КЛАСС БЕЗ
            ОГРАНИЧЕНИЙ&lt;/i&gt;. Код отображения &lt;i&gt;'Н'-НОРМАЛЬНЫЙ&lt;/i&gt;.
            Коды бронирования:
            &lt;i&gt;Э,Е&lt;/i&gt;
            &lt;b&gt;50. Применение&lt;/b&gt;
            НАЗВАНИЕ УПТ - &lt;i&gt;SU CARRIER NORMAL FARES.&lt;/i&gt;
            ДАННЫЕ ТАРИФЫ ПРИМЕНЯЮТСЯ &lt;i&gt;В ПРЕДЕЛАХ&lt;/i&gt; '&lt;i&gt;РФ&lt;/i&gt;'-РОССИЙСКАЯ ФЕДЕРАЦИЯ.
            ДАННЫЕ ТАРИФЫ ПРИМЕНЯЮТСЯ ДЛЯ УЛУЧШЕННОГО ЭКОНОМИЧЕСКОГО, БИЗНЕС, ПЕРВОГО
            КЛАССА ОБСЛУЖИВАНИЯ.
            ТАРИФЫ РЕГУЛИРУЕМЫЕ ДАННЫМ УПТ МОГУТ КОМБИНИРОВАТЬСЯ ДЛЯ ПОСТРОЕНИЯ ТИПОВ
            ПЕРЕВОЗКИ В ОДНУ СТОРОНУ (OW), ТУДА-ОБРАТНО (RT), ЗАМКНУТОЙ КРУГОВОЙ (CT),
            НЕЗАМКНУТОЙ КРУГОВОЙ (OJ), НЕЗАМКНУТОЙ КРУГОВОЙ С ОТКРЫТЫМ ИЛИ С НАЗЕМНЫМ
            УЧАСТКОМ (SOJ), НЕЗАМКНУТОЙ КРУГОВОЙ С ОТКРЫТЫМ И С НАЗЕМНЫМ УЧАСТКОМ (DOJ).
            &lt;b&gt;18. Важные уведомления на билете&lt;/b&gt;
            ПЕРВОНАЧАЛЬНЫЙ И ПЕРЕОФОРМЛЕННЫЙ БИЛЕТ ДОЛЖЕН СОДЕРЖАТЬ ТЕКСТ&lt;i&gt; ""SU ONLY""&lt;/i&gt; В
            ГРАФЕ РАЗРЕШАЕТСЯ/ЗАПРЕЩАЕТСЯ (КОПИРКА).
            &lt;b&gt;19. Скидки для детей и младенцев&lt;/b&gt;
            &lt;b&gt;-----&lt;/b&gt;
            ПРИМЕНЕНИЕ СКИДКИ РАЗРЕШАЕТСЯ ДЛЯ ПАССАЖИРА '&lt;i&gt;РМГ&lt;/i&gt;'-'МЛАДЕНЕЦ БЕЗ
            ПРЕДОСТАВЛЕНИЯ МЕСТА' МЛАДШЕ &lt;i&gt;2&lt;/i&gt; ЛЕТ.
            СТОИМОСТЬ ПЕРЕВОЗКИ &lt;i&gt;0.00&lt;/i&gt; ДОЛ.
            В ГРАФЕ БАЗОВЫЙ ТАРИФ/FARE BASIS УКАЗЫВАЕТСЯ: /'&lt;i&gt;IN&lt;/i&gt;'.
            &lt;b&gt;или&lt;/b&gt;
            ПРИМЕНЕНИЕ СКИДКИ РАЗРЕШАЕТСЯ ДЛЯ ПАССАЖИРА '&lt;i&gt;РВГ&lt;/i&gt;'-'МЛАДЕНЕЦ С ПРЕДОСТАВЛЕН
            МЕСТА ПО ПРОСЬБЕ РОДИТЕЛЕЙ А ТАКЖЕ 2 3 И Т Д МЛАДЕНЕЦ СЛЕДУЮЩИЙ С ПАССАЖ'
            МЛАДШЕ &lt;i&gt;2&lt;/i&gt; ЛЕТ.
            СТОИМОСТЬ ПЕРЕВОЗКИ &lt;i&gt;50.00&lt;/i&gt; ПРОЦЕНТОВ ОТ ПРИМЕНЕННОГО ТАРИФА.
            В ГРАФЕ БАЗОВЫЙ ТАРИФ/FARE BASIS УКАЗЫВАЕТСЯ: /'&lt;i&gt;CH&lt;/i&gt;' ПЛЮС ВЕЛИЧИНА СКИДКИ.
            &lt;b&gt;или&lt;/b&gt;
            ПРИМЕНЕНИЕ СКИДКИ РАЗРЕШАЕТСЯ ДЛЯ ПАССАЖИРА '&lt;i&gt;РБГ&lt;/i&gt;'-'РЕБЕНОК СОПРОВОЖДАЕМЫЙ С
            ПРЕДОСТАВЛЕНИЕМ МЕСТА' ОТ &lt;i&gt;2&lt;/i&gt; ДО &lt;i&gt;12&lt;/i&gt; ЛЕТ.
            СТОИМОСТЬ ПЕРЕВОЗКИ &lt;i&gt;50.00&lt;/i&gt; ПРОЦЕНТОВ ОТ ПРИМЕНЕННОГО ТАРИФА.
            В ГРАФЕ БАЗОВЫЙ ТАРИФ/FARE BASIS УКАЗЫВАЕТСЯ: /'&lt;i&gt;CH&lt;/i&gt;' ПЛЮС ВЕЛИЧИНА СКИДКИ.
            &lt;b&gt;или&lt;/b&gt;
            ПРИМЕНЕНИЕ СКИДКИ РАЗРЕШАЕТСЯ ДЛЯ ПАССАЖИРА '&lt;i&gt;АГА&lt;/i&gt;'-'РЕБЕНОК НЕСОПРОВОЖДАЕМЫЙ'
            ОТ &lt;i&gt;2&lt;/i&gt; ДО &lt;i&gt;12&lt;/i&gt; ЛЕТ.
            СТОИМОСТЬ ПЕРЕВОЗКИ &lt;i&gt;100.00&lt;/i&gt; ПРОЦЕНТОВ ОТ ПРИМЕНЕННОГО ТАРИФА.
            </remark>
            </fareremark>
            </answer>
            </sirena>";

            var response = SerializationHelper.Deserialize<FareremarkResponse>(data);
            Console.WriteLine(SerializationHelper.Serialize(response));
        }
    }
}
