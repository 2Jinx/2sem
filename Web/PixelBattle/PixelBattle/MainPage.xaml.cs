namespace PixelBattle
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            GeneratePage();
        }

        /// <summary>
        /// Обрабатываем нажатие кнопки входа на главной странице
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void SubmitClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                if (button.Parent is StackLayout stackLayout)
                {
                    // Получаем объект Entry для получения никнейма пользователя
                    var nameEntry = stackLayout.Children.FirstOrDefault(c => c is Entry) as Entry;

                    // Проверяем введен ли никнейм пользователя
                    // Если введен, то создаем клиент для пользователя и передаем туда никнейм,
                    // а так же переходим на страничку самой игры
                    // Иначе выводим всплывающее окно с ошибкой
                    if (!string.IsNullOrEmpty(nameEntry?.Text))
                    {
                        string nickname = nameEntry.Text;
                        nameEntry.Text = string.Empty;

                        new Client(nickname).Process();
                        await Shell.Current.GoToAsync("GamePage");
                    }
                    else
                    {
                        await DisplayAlert("Ошибка", "Неверное имя пользователя", "Oк");
                    }
                }
            }
        }
    }

    public partial class MainPage : ContentPage
    {
        /// <summary>
        /// Верстка всей главной страницы кодом
        /// Вынес отдельно для лучшей читаемости кода
        /// </summary>
        private async void GeneratePage()
        {
            // Блок с контентом для всей страницы
            var grid = new Grid();

            // Фон главной страницы
            var backgroundImage = new Image
            {
                Source = "background.png",
                Aspect = Aspect.AspectFill
            };

            grid.Children.Add(backgroundImage); // Добавили фон на экран

            // Отдельный блок для кнопки и поля с вводом никнейма
            var mainGrid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            // Устанавливаем расположение элементов в самом блоке
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            mainGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });

            // Добавляем два блока для отступа и элементов интерфейса
            var topStackLayout = new StackLayout(); // Для отступа
            var bottomStackLayout = new StackLayout // Для кнопки и поля с вводом никнейма
            {
                VerticalOptions = LayoutOptions.Center
            };

            // Поле для ввода никнейма пользователя
            var nameEntry = new Entry
            {
                Placeholder = "Введите ваше имя",
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Colors.White,
                TextColor = Colors.Black
            };
            bottomStackLayout.Children.Add(nameEntry); // Добавили поле с вводом никнейма на экран

            // Кнопка для входа в игру
            var submitButton = new Button
            {
                Text = "Войти",
                WidthRequest = 300,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Margin = new Thickness(30)
            };
            submitButton.Clicked += SubmitClicked; // Добавили обработчик событий на кнопку (на нажатие)
            bottomStackLayout.Children.Add(submitButton); // Добавили кнопку на экран

            mainGrid.Children.Add(topStackLayout);
            mainGrid.Children.Add(bottomStackLayout);

            // Перенос всего в нижнюю часть экрана
            Grid.SetRow(topStackLayout, 0); 
            Grid.SetRow(bottomStackLayout, 1); 

            grid.Children.Add(mainGrid); // Добавили все в главный блок страницы

            Content = grid; // Установили главный блок контентом страницы
        }
    }
}
