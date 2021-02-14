  /*
         * Рекурсивная функция поиска индекса в заданном диапазоне массива, которая возвращает индекс элемента, имеющего ключ key,
         * если он найден. Если ключ меньше ключа элемента массив с индексом low, возвращает low, если больше
         * ключа элемента с индексом high то high. Функция реализует алгоритм бинарного поиска.
         * Данный алгоритм применять нельзя, т.к. о сортировке массива в задании не указано
         */
        static int Func1(KeyValuePair<int, string>[] a, int low, int high, int key)
        {
            int middle = low + ((high - low) / 2);

            if (low == high) return low;

            return key > a[middle].Key ? Func1(a, middle + 1, high, key) : Func1(a, low, middle, key);
        }

        /*
         * Увеличивает размер массива на 1 и добавляет в него новую пару значений типа "Число, Строка".
         * Позиция для вставки определяется функцией Func1. Перед вставкой нового элемента происходит циклическое копирование элементов вправо,
         * начиная от позиции вставки и до конца массива.
         * 
         * Рефакторинг - удалён лишний код.
         */
        static void Func2(ref KeyValuePair<int, string>[] a, int key, string value)
        {
            Array.Resize(ref a, a.Length + 1);
            var pos = Func1(a, 0, a.Length - 1, key);
            
            for (int i = a.Length - 1; i > pos; i--) a[i] = a[i - 1];

            a[pos] = new KeyValuePair<int, string>(key, value);
        }