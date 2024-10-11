using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace m4
{
    // Базовый интерфейс для товара, определяющий необходимые свойства и метод
    public interface IProduct
    {
        string Name { get; set; } // Название товара
        decimal Price { get; set; } // Цена товара
        int Stock { get; set; } // Количество товара на складе
        string GetDetails(); // Метод для получения деталей товара
    }

    // Класс продуктов питания, реализующий интерфейс IProduct
    public class FoodProduct : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string ExpirationDate { get; set; } // Новая характеристика: Срок годности

        // Метод для получения строки с деталями продукта
        public string GetDetails()
        {
            return $"Продукт: {Name}, Цена: {Price} BYN, Количество: {Stock}, Срок годности: {ExpirationDate}";
        }
    }

    // Класс бытовой техники, реализующий интерфейс IProduct
    public class ElectronicsProduct : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int Power { get; set; } // Новая характеристика: Мощность

        // Метод для получения строки с деталями продукта
        public string GetDetails()
        {
            return $"Техника: {Name}, Цена: {Price} BYN, Количество: {Stock}, Мощность: {Power} Вт";
        }
    }

    // Класс одежды, реализующий интерфейс IProduct
    public class ClothingProduct : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Size { get; set; } // Новая характеристика: Размер

        // Метод для получения строки с деталями продукта
        public string GetDetails()
        {
            return $"Одежда: {Name}, Цена: {Price} BYN, Количество: {Stock}, Размер: {Size}";
        }
    }

    // Класс мебели, реализующий интерфейс IProduct
    public class FurnitureProduct : IProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Material { get; set; } // Новая характеристика: Материал

        // Метод для получения строки с деталями продукта
        public string GetDetails()
        {
            return $"Мебель: {Name}, Цена: {Price} BYN, Количество: {Stock}, Материал: {Material}";
        }
    }

    // Основное окно приложения
    public partial class MainWindow : Window
    {
        // Список товаров, реализующих интерфейс IProduct
        private List<IProduct> products = new List<IProduct>();

        public MainWindow()
        {
            InitializeComponent(); // Инициализация компонентов окна
        }

        // Обработчик для добавления продуктов питания
        private void AddFoodProduct_Click(object sender, RoutedEventArgs e)
        {
            // Проверка введённых данных
            if (string.IsNullOrWhiteSpace(FoodProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FoodProductExpirationTextBox.Text) ||
                !decimal.TryParse(FoodProductPriceTextBox.Text, out decimal foodPrice) ||
                !int.TryParse(FoodProductStockTextBox.Text, out int foodStock))
            {
                MessageBox.Show("Пожалуйста, введите корректные данные для продукта питания.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Прекращение выполнения метода в случае ошибки
            }

            // Создание нового продукта и добавление его в список
            var foodProduct = new FoodProduct
            {
                Name = FoodProductNameTextBox.Text,
                Price = foodPrice,
                Stock = foodStock,
                ExpirationDate = FoodProductExpirationTextBox.Text
            };
            products.Add(foodProduct); // Добавление продукта в список
            RefreshProductList(); // Обновление отображаемого списка продуктов
        }

        // Обработчик для добавления бытовой техники
        private void AddElectronicsProduct_Click(object sender, RoutedEventArgs e)
        {
            // Проверка введённых данных
            if (string.IsNullOrWhiteSpace(ElectronicsProductNameTextBox.Text) ||
                !decimal.TryParse(ElectronicsProductPriceTextBox.Text, out decimal electronicsPrice) ||
                !int.TryParse(ElectronicsProductStockTextBox.Text, out int electronicsStock))
            {
                MessageBox.Show("Пожалуйста, введите корректные данные для бытовой техники.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Прекращение выполнения метода в случае ошибки
            }

            // Создание нового продукта и добавление его в список
            var electronicsProduct = new ElectronicsProduct
            {
                Name = ElectronicsProductNameTextBox.Text,
                Price = electronicsPrice,
                Stock = electronicsStock,
                // Добавьте код для мощности, если требуется
            };
            products.Add(electronicsProduct); // Добавление продукта в список
            RefreshProductList(); // Обновление отображаемого списка продуктов
        }

        // Обработчик для добавления одежды
        private void AddClothingProduct_Click(object sender, RoutedEventArgs e)
        {
            // Проверка введённых данных
            if (string.IsNullOrWhiteSpace(ClothingProductNameTextBox.Text) ||
                !decimal.TryParse(ClothingProductPriceTextBox.Text, out decimal clothingPrice) ||
                !int.TryParse(ClothingProductStockTextBox.Text, out int clothingStock) ||
                string.IsNullOrWhiteSpace(ClothingProductSizeComboBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректные данные для одежды.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Прекращение выполнения метода в случае ошибки
            }

            // Создание нового продукта и добавление его в список
            var clothingProduct = new ClothingProduct
            {
                Name = ClothingProductNameTextBox.Text,
                Price = clothingPrice,
                Stock = clothingStock,
                Size = ClothingProductSizeComboBox.Text
            };
            products.Add(clothingProduct); // Добавление продукта в список
            RefreshProductList(); // Обновление отображаемого списка продуктов
        }

        // Обработчик для добавления мебели
        private void AddFurnitureProduct_Click(object sender, RoutedEventArgs e)
        {
            // Проверка введённых данных
            if (string.IsNullOrWhiteSpace(FurnitureProductNameTextBox.Text) ||
                !decimal.TryParse(FurnitureProductPriceTextBox.Text, out decimal furniturePrice) ||
                !int.TryParse(FurnitureProductStockTextBox.Text, out int furnitureStock) ||
                string.IsNullOrWhiteSpace(FurnitureProductMaterialComboBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите корректные данные для мебели.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return; // Прекращение выполнения метода в случае ошибки
            }

            // Создание нового продукта и добавление его в список
            var furnitureProduct = new FurnitureProduct
            {
                Name = FurnitureProductNameTextBox.Text,
                Price = furniturePrice,
                Stock = furnitureStock,
                Material = FurnitureProductMaterialComboBox.Text
            };
            products.Add(furnitureProduct); // Добавление продукта в список
            RefreshProductList(); // Обновление отображаемого списка продуктов
        }

        // Обновление списка товаров в интерфейсе
        private void RefreshProductList()
        {
            ProductListBox.Items.Clear(); // Очистка текущего списка
            foreach (var product in products) // Перебор всех продуктов в списке
            {
                ProductListBox.Items.Add(product.GetDetails()); // Добавление деталей продукта в список
            }
        }

        // Обработчик изменения выбранного элемента в списке товаров
        private void ProductListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Проверка, выбран ли элемент
            if (ProductListBox.SelectedItem != null)
            {
                MessageBox.Show(ProductListBox.SelectedItem.ToString(), "Детали товара"); // Вывод деталей выбранного товара
            }
        }

        // Обработчик фильтрации товаров по цене
        private void PriceFilterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Проверка, введена ли корректная цена
            if (decimal.TryParse(PriceFilterTextBox.Text, out decimal priceLimit))
            {
                // Фильтрация продуктов по цене и обновление списка
                var filteredProducts = products.Where(p => p.Price <= priceLimit).ToList();
                ProductListBox.Items.Clear(); // Очистка текущего списка
                foreach (var product in filteredProducts) // Добавление отфильтрованных продуктов в список
                {
                    ProductListBox.Items.Add(product.GetDetails());
                }
            }
            else
            {
                RefreshProductList(); // Обновление списка при некорректном вводе
            }
        }
    }
}
