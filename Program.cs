using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StartQuest
{
    enum LEVEL
    {
        Start,
        Street,
        Bar,
        StrangerDialog,
        Fight
    }

    class Program
    {
        static void Main(string[] args)
        {
            var level = LEVEL.Start;
            var lastLevel = LEVEL.Start;
            var action = "";
            var message = "";
            while (true)
            {
                switch (level)
                {
                    case LEVEL.Start:
                        action = ShowSelectVars("Вас приветствует игра \"Одинокий рейнджер\". Выберите дальнейшие действия", new string[] { "Новая игра", "Выход" });
                        switch (action)
                        {
                            case "Новая игра":
                                level = LEVEL.Street;
                                break;
                            case "Выход":
                                return;
                        }
                        lastLevel = LEVEL.Start;
                        break;
                    case LEVEL.Street:
                        message = "";
                        if (lastLevel == LEVEL.Start)
                            message = "Где-то в этом городе засел бандит Гарри. Вам необходимо найти его и обезвредить.\n";
                        else if (lastLevel == LEVEL.Street)
                            message = "Вы постояли какое-то время, но ничего не произошло. Думаете, Гарри сам к вам выйдет с распростертыми " +
                                "объятьями?\n";
                        else if (lastLevel == LEVEL.Bar)
                            message = "Как же здесь жарко!\n";
                        action = ShowSelectVars(message + "Вы стоите на главной улице города. Перед вами стоит салун. В общем-то больше здесь ничего особо и нет.", new string[] { "Войти в салун", "Подождать" });
                        switch (action)
                        {
                            case "Войти в салун":
                                level = LEVEL.Bar;
                                break;
                            case "Подождать":
                                level = LEVEL.Street;
                                break;
                        }
                        lastLevel = LEVEL.Street;
                        break;
                    case LEVEL.Bar:
                        message = "";
                        if (lastLevel == LEVEL.Street)
                            message = "Прохлада помещения очень кстати после жаркой улицы. Вы присели за столик в углу. ";
                        action = ShowSelectVars(message + "В салуне три человека, не считая вас. Бармен стоит за стойкой и чего-то бурчит под нос." +
                                                            " Странного вида парень в углу задумчиво вертит в руках какую-то бумажонку. Прямо перед вами " +
                                                            "сидит невзрачный мужчина в шляпе.", new string[] { "Выйти из салуна", "Заговорить с барменом",
                                                                                                                "Подойти к пареньку", "Окликнуть мужчину"});
                        switch (action)
                        {
                            case "Выйти из салуна":
                                level = LEVEL.Street;
                                break;
                            case "Заговорить с барменом":
                                ShowSelectVars("\"Не знаю я никакого Гарри\" - проворчал бармен. - \"А знал бы, то уж тебе последнему бы сказал. " +
                                    "Ты и сам-то подозрительный тип. Заказывать будешь?\"", new string[] {"Отойти"});
                                break;
                            case "Подойти к пареньку":
                                level = LEVEL.StrangerDialog;
                                break;
                            case "Окликнуть мужчину":
                                ShowSelectVars("Мужчина дернул плечом, но не ответил вам. Кажется, он не расположен к разговору с вами.",
                                    new string[] { "Ну ладно." });
                                break;
                        }

                        lastLevel = LEVEL.Bar;
                        break;
                    case LEVEL.StrangerDialog:
                        action = ShowSelectVars("\"Пять-ю-пять... пять-ю-пять... Сколько же будет пять-ю-пять\" Лихорадочно бормочет парень. Может он нездоров?",
                            new string[] { "Сорок восемь!", "-5",
                                "Данное выражение, очевидно не имеет решений на множестве действительных чисел.", "Эй, пацан, очнись." });
                        switch (action)
                        {
                            case "Эй, пацан, очнись.":
                                level = LEVEL.Fight;
                                break;
                            default:
                                action = ShowSelectVars("\"Что-что?\" - парень на секунду отвлекся от своей бумажки. " +
                                    "\"Ах, отстаньте от меня со своей ерундой\" - и погрузился в дальнейшие причитания.",
                            new string[] { "Ну-ну..."});
                                level = LEVEL.Bar;
                                break;
                        }
                        lastLevel = LEVEL.StrangerDialog;
                        break;
                    case LEVEL.Fight:
                        action = ShowSelectVars("\"Гарри? Какой Гарри? Ах... да вот же он!\" - в голос орет паренек и тыкает пальцем " +
                            "в мужчину за столиком. Тот срывается с места, шляпа падает на пол, а из под плаща появляется пистолет. Что же делать?",
                            new string[] { "Выстрелить", "Кинуть чем-нибудь" });
                        switch (action)
                        {
                            case "Выстрелить":
                                ShowSelectVars("Вы потянулись за револьвером, но конечно же не успели. Когда ваши пальцы почувствовали" +
                                    " знакомую стальную рукоять противник уже держал вас на мушке. Громкий хлопок - таков был конец рейнджера.",
                                    new string[] { "Вот и все..." });
                                break;
                            case "Кинуть чем-нибудь":
                                ShowSelectVars("Вы кинули первым, что попалось под руку. А под руку вам попалась какая-то " +
                                    "тяжелая металическая штука, стоявшая на столе паренька. Метким броском вы угодили " +
                                    "Гарри прямо в лоб, но поняли, что опоздали - он уже держал вас на мушке. " +
                                    "Вы почти распрощались с жизнью, как вдруг бандит покачнулся, закатил глаза и упал." +
                                    " Тяжелая видать была та штукенция. Ну вот и все, вам осталось лишь доставить Гарри в " +
                                    "тюрьму и получить заслуженную награду. Жизнь прекрасна!",
                                    new string[] { "Вот и все!" });
                                break;
                        }
                        level = LEVEL.Start;
                        lastLevel = LEVEL.Fight;
                        break;

                }
            }
        }

        static string ShowSelectVars(string message, string[] vars)
        {
            var selected = 0;

            while (true)
            {
                RedrawSelector(message, vars, selected);

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        selected -= (selected > 0) ? 1 : 0;
                        break;
                    case ConsoleKey.DownArrow:
                        selected += (selected < vars.Length - 1) ? 1 : 0;
                        break;
                    case ConsoleKey.Enter:
                        return vars[selected];
                    default:
                        break;
                }
            }
        }

        static void RedrawSelector(string message, string[] vars, int selected)
        {
            Console.Clear();

            Console.WriteLine(message);

            for (var i = 0; i < selected; i++)
                Console.WriteLine(vars[i]);

            WriteColorLine(vars[selected], ConsoleColor.Black, ConsoleColor.White);

            for (var i = selected + 1; i < vars.Length; i++)
                Console.WriteLine(vars[i]);
        }

        static void WriteColorLine(string line, ConsoleColor color, ConsoleColor back)
        {
            var buf = Console.ForegroundColor;
            var bufBack = Console.BackgroundColor;

            Console.ForegroundColor = color;
            Console.BackgroundColor = back;

            Console.WriteLine(line);

            Console.ForegroundColor = buf;
            Console.BackgroundColor = bufBack;
        }
    }
}
